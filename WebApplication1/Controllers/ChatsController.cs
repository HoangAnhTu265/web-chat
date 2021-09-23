using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ChatsController : Controller
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        // GET: Chats
        public ActionResult Index()
        {
            if (Session["LoginUser"] == null || string.IsNullOrEmpty(Session["LoginUser"].ToString()))
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AllChat()
        {
            return View(client.GetAllChat().OrderByDescending(c => c.Id).ToList());
        }

        [HttpPost]
        public ActionResult Index(string ChatContent)
        {
            if (client.SendMessage(ChatContent, Session["LoginUser"].ToString()))
            {
                return Content("Success");
            } else
            {
                return Content("Fail");
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ServiceReference1.Account a)
        {
            if (client.Login(a.Username, a.Password))
            {
                Session["LoginUser"] = a.Username;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ServiceReference1.Account a)
        {
            if (client.Register(a.Username, a.Password))
            {
                Session["LoginUser"] = a.Username;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
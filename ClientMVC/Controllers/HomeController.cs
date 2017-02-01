using ClientMVC.Models;
using RabbitMQManeger.RabbitMQClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        const string ADDRESSE = "10.10.41.178";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(PostModel item)
        {
            IClientRabbitMQ client = new ClientRabbitMQ();
            client.InitConnection(new RabbitMQManager.UserRabbitMQ("user", "password", ADDRESSE));
            client.Send(item.Queue, item.Message);
            return RedirectToAction("Index");
        }
    }
}
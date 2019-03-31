using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Homework.Models;

namespace ASP.NET_Homework.Controllers
{
    public class HomeController : Controller
    {
        static List<Task> Tasks = new List<Task>();
        static int id = 0;
        static int  GetId()
        {
            return ++id;
        }
        public ActionResult Index()
        {
            ViewBag.Tasks = Tasks;

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Tasks.Remove(Tasks.Find(b => b.ID == id));
            ViewBag.Tasks = Tasks;


            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        public ActionResult Add(string TaskText)
        {
            if (Tasks.Find(b => b.Text == TaskText) == null)
                Tasks.Add(new Task() { ID=GetId(),Finished = false, Text = TaskText });
            ///new ModelError("Такая задача уже существует");
            ViewBag.Tasks = Tasks;


            return View("~/Views/Home/Index.cshtml");
        }
        [HttpGet]
        public ActionResult Finish(int id)
        {
            Task EditTask = Tasks.Find(b => b.ID == id);
            if (EditTask != null)
                EditTask.Finished = !EditTask.Finished;
            ///new ModelError("Такая задача уже существует");
            ViewBag.Tasks = Tasks;


            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Tasks.Remove(Tasks.Find(b => b == task));
            TempData.Add("TempTask", Tasks.Find(b => b.ID==id));


            return View("~/Views/Home/Edit.cshtml");
        }
        [HttpPost]
        public ActionResult Edit(string Text)
        {
            Tasks.Remove((Task)TempData["TempTask"]);

            Add(Text);
            ViewBag.Tasks = Tasks;

            return View("~/Views/Home/Index.cshtml");


        }

    }
}
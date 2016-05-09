using System.Web.Mvc;
using System;
using Dailydive.DataAccess;
using Dailydive.Contracts.Dto.Domain;

namespace Dailydive.Controllers
{
    public class HomeController : Controller
    {
        protected static DailyDiveDataAccess DataAccess = new DailyDiveDataAccess();

        //Task:
        public ActionResult Index()
        {
            try
            {
                var allTask = DataAccess.ViewAllTask();

                return View(allTask);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult AddTask(Task task)
        {
            try
            {
                DataAccess.AddNewTask(task);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }

        }

        public ActionResult EditTask(int id)
        {
            try
            {
                var task = DataAccess.LookUpTask(id);

                return View(task);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult UpdateTask(Task task)
        {
            try
            {
                DataAccess.UpdateTask(task);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }

        }

        public ActionResult RemoveTask(int id)
        {
            try
            {
                DataAccess.RemoveTask(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult SearchTask(string searchFor)
        {
            try
            {
                var results = DataAccess.SearchTask(searchFor);

                return View("Index", results);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        //Task History:
        public ActionResult ViewTaskHistory()
        {
            try
            {
                var allTaskHistory = DataAccess.ViewTaskHistory();

                return View(allTaskHistory);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult AddTaskHistory()
        {
            try
            {
                var allTask = DataAccess.ViewAllTask();

                return View(allTask);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }        
        }

        [HttpPost]
        public ActionResult AddTaskHistory(TaskHistory TaskHistory)
        {
            try
            {
                DataAccess.AddTaskHistory(TaskHistory);

                return RedirectToAction("ViewTaskHistory");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult EditTaskHistory(int id)
        {
            try
            {
                var item = DataAccess.LookUpTaskHistoryId(id);

                return View(item);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult UpdateTaskHistory(TaskHistory TaskHistory)
        {
            try
            {
                DataAccess.UpdateTaskHistory(TaskHistory);

                return RedirectToAction("ViewTaskHistory");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }           
        }

        public ActionResult RemoveTaskHistory(int id)
        {
            try
            {
                DataAccess.RemoveTaskHistory(id);

                return RedirectToAction("ViewTaskHistory");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }

        public ActionResult SearchTaskHistory(string taskName)
        {
            try
            {
                var results = DataAccess.SearchTaskHistory(taskName);

                return View("ViewTaskHistory", results);
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;

                return View("Error");
            }
        }
    }
}
using MidLabExam.Auth;
using MidLabExam.DTOs;
using MidLabExam.EF;
using MidLabExam.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MidLabExam.Controllers
{
    [UserAccess]
    public class TaskController : Controller
    {
        // GET: Task

        DbEntities2 db = new DbEntities2();
        TaskMapper taskMapper = new TaskMapper();
        [HttpGet]
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();
            var mappedTasks = taskMapper.Map(tasks);
            // Load categories into ViewBag
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");

            return View(mappedTasks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View(new TaskDTO());
        }

        [HttpPost]
        public ActionResult Create(TaskDTO task,int CategoryId)
        {

            if (ModelState.IsValid)
            {
                var mappedTask = taskMapper.Map(task);
                mappedTask.CreatedAt = DateTime.Now; 
                
                db.Tasks.Add(mappedTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = db.Categories.ToList();
            var task = db.Tasks.Find(id);
            //include category navigation property
            db.Entry(task).Reference(t => t.Category).Load();
            var mappedTask = taskMapper.Map(task);
            return View(mappedTask);
        }

        [HttpPost]
        public ActionResult Edit(TaskDTO task)
        {
            ViewBag.Categories = db.Categories.ToList();
            if (ModelState.IsValid)
            {
                var taskExists = db.Tasks.Find(task.Id);
                if (taskExists != null)
                {
                    taskExists.PriorityLevel = task.PriorityLevel;
                    taskExists.Status = task.Status;
                    taskExists.Title = task.Title;
                    taskExists.DueDate = task.DueDate;
                    taskExists.UpdatedAt = DateTime.Now;
                    taskExists.CategoryId = task.CategoryId;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);


        }

       
        public ActionResult Delete(int id)
        {
            var existingTask = db.Tasks.Find(id);
            if (existingTask != null)
            {
                db.Tasks.Remove(existingTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Task not found";
            return RedirectToAction("Index");
        }

        //mark as completed
        public ActionResult MarkAsComplete(int id)
        {
            var existingTask = db.Tasks.Find(id);
            if (existingTask != null)
            {
                existingTask.Status = "Complete";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Task not found";
            return RedirectToAction("Index");
        }

        //completed tasks
        [HttpGet]
        public ActionResult CompletedTasks()
        {
            var tasks = db.Tasks.Where(t => t.Status == "Complete").ToList();
            var mappedTasks = taskMapper.Map(tasks);
            foreach (var task in tasks)
            {
                db.Entry(task).Reference(t => t.Category).Load();
            }

            return View("Index",mappedTasks);
        }

        //Incomplete tasks
        [HttpGet]
        public ActionResult IncompleteTasks()
        {
            var tasks = db.Tasks.Where(t => t.Status != "Complete").ToList();
            var mappedTasks = taskMapper.Map(tasks);
            foreach (var task in tasks)
            {
                db.Entry(task).Reference(t => t.Category).Load();
            }

            return View("Index", mappedTasks);
        }
    }
}
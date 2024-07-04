using MidLabExam.DTOs;
using MidLabExam.EF;
using MidLabExam.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidLabExam.Controllers
{
    public class AuthController : Controller
    {
        DbEntities2 db = new DbEntities2();
        UserMapper Usermapper = new UserMapper();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            if(Request["ReturnUrl"] !=null) {
                ViewBag.URL = Request["ReturnUrl"];
            }
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Index(LoginDTO user,string Url)
        {

            if (ModelState.IsValid)
            {
                var validUser = db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
                if (validUser == null)
                {
                    TempData["Msg"] = "Invalid Email or Password";
                    return View(user);

                }
                Session["User"] = validUser;

                if (Url != null && !Url.Equals(""))
                {
                    TempData["Auth"] = $"Sorry,{user.Email} Permission Denied";
                    return Redirect(Url);
                }
                else
                {
                   
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(user);




        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new RegistrationDTO());
        }

        [HttpPost]
        public ActionResult Registration(RegistrationDTO user)
        {
            if (ModelState.IsValid)
            {
                var mappedUser = Usermapper.Map(user);
                var emailExist = db.Users.Where(u=>u.Email == mappedUser.Email).FirstOrDefault();
                if(emailExist !=null)
                {
                    TempData["Msg"] = "Email already exist";
                    return View(new RegistrationDTO());
                }
                mappedUser.AccessId = 2;
                db.Users.Add(mappedUser);
                db.SaveChanges();
                TempData["Msg"] = $"Welcome to Onboard {mappedUser.Name}";
                return RedirectToAction("Index", "Home");
            }
            return View(new RegistrationDTO());


            
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

    }

    }
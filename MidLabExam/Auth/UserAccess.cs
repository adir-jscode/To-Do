using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidLabExam.Auth
{
    public class UserAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user =(User) httpContext.Session["User"];
            if(user !=null && user.AccessGroup.Name.Equals("User"))
            {
                return true;
            }
            return false;
        }
    }
}
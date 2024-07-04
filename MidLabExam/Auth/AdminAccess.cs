using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidLabExam.Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var admin =(User)httpContext.Session["User"];
            if (admin != null && admin.AccessGroup.Name.Equals("Admin"))
            {
                return true;
            }
            return false;
        }
    }
}
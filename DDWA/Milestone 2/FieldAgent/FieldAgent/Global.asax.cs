using FieldAgent.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FieldAgent;
using FieldAgent.Data;
using System.Web.Services.Description;
using FieldAgent.Controllers;

namespace FieldAgent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
        }
    }
}

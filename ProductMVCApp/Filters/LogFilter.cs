using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductMVCApp.Filters
{
    public class LogFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogControllerActionMethods(filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception!=null)
            {
                string errorMessage = filterContext.Exception.Message;
            }
        }



        private void LogControllerActionMethods(RouteData routeData)
        {
            var controllerName = routeData.Values["Controller"];
            var actionMethods = routeData.Values["action"];
        }
    }
}
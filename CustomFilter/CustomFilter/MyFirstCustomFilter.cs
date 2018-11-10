using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFilter
{
    public class MyFirstCustomFilter: ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //You may fetch data from database here 
            filterContext.Controller.ViewBag.GreetMesssage = "Hello Foo";
            base.OnResultExecuting(filterContext);
        }


        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage4 = "Custom Action Filter: Message from OnResultExecuted method.";
        }

        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            filterContext.RouteData.Values["controller"] = "Values";
            filterContext.RouteData.Values["Action"] = "Index";
            filterContext.Result = new RedirectToRouteResult(filterContext.RouteData.Values);

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"] as string;
            var actionName = filterContext.RouteData.Values["action"] as string;
            if ((controllerName.ToLower() == "home") && (actionName.ToLower() == "index"))
            {
                var urlHelper = new UrlHelper(filterContext.HttpContext.Request.RequestContext);
                var url = urlHelper.Action("Details", "Values", new { id = 5  });
              //  filterContext.Controller.TempData["CartMode"] = isShoppingCart;
                filterContext.Result = new RedirectResult(url.ToLower(), false);
                return;
            }

        }
    }
}
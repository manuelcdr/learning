using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filters
{
    public class AutorizationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool logado = Convert.ToBoolean(filterContext.HttpContext.Session["logado"]);
            if (logado)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                                new { controller = "Login", action = "Index" }
                            )
                    );
            }
        }
    }
}
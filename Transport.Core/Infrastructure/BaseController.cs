using System;
using System.Web;
using System.Web.Mvc;
using Transport.Core.Validation;

namespace Transport.Core.Infrastructure
{
    public class BaseController : Controller
    {
        protected JsonResult JsonValidationResult(ValidationResult validation, object data = null)
        {
            return Json(new { vailidation = validation, data = data }, JsonRequestBehavior.AllowGet);
        }

        protected string GetFullExceptionText(Exception ex)
        {
            string result = ex.Message;
            if (ex is HttpRequestValidationException)
            {
                result = "Potenciali pavojinga uzklausa buvo aptikta is kliento puses";

                int fIndex = ex.Message.IndexOf("(");
                int sIndex = ex.Message.IndexOf("=");

                if (fIndex > 0 && sIndex > 0)
                    result += " " + ex.Message.Substring(fIndex, sIndex - fIndex) + ")";

            }

            if (ex.InnerException != null)
            {
                result += "<br /><br /><a style=\"font-weight:bold;\">InnerException:</a><br />" + ex.InnerException.Message;

                if (ex.InnerException.InnerException != null)
                    result += "<br /><br /><a style=\"font-weight:bold;\">InnerInnerException:</a><br />" + ex.InnerException.InnerException.Message;
            }

            return result;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;

            filterContext.ExceptionHandled = true;
            string ex = "";

            if (Request.IsAuthenticated)
            {
                filterContext.HttpContext.Response.StatusCode = 500;

                ex = GetFullExceptionText(exception);

                filterContext.Result = new JsonResult { Data = new MvcHtmlString(ex).ToHtmlString() };
            }
            else
            {
                var result = View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(
                        exception,
                        filterContext.RouteData.Values["controller"].ToString(),
                        filterContext.RouteData.Values["action"].ToString()
                    ));

                filterContext.Result = result;
            }
        }
    }
}
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace REST.Models
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null) {
                return;
            }
            if (actionExecutedContext.Exception is ValidationException) {
                actionExecutedContext.Response = actionExecutedContext.Request
                     .CreateResponse(HttpStatusCode.BadRequest, ((ValidationException)actionExecutedContext.Exception).Errors);
            }
        }
    }
}
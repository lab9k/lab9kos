using Microsoft.AspNetCore.Mvc.Filters;

namespace lab9kos.Filters
{
    public class AjaxFilter : ActionFilterAttribute
    {
        private bool _isXmlRequest;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request != null && context.HttpContext.Request.Headers["X-Requested-With"] ==
                "XMLHttpRequest")
            {
                _isXmlRequest = true;
            }
            context.ActionArguments["isAjax"] = _isXmlRequest;
            base.OnActionExecuting(context);
        }
    }
}
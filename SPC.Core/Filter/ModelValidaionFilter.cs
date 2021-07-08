using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SPC.Core.Dtos;

namespace SPC.Core.Filter
{
    public class ModelValidaionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                       .Values
                       .SelectMany(x => x.Errors.Select(p => p.ErrorMessage))
                       .ToList();
                if (errors.Count > 0)
                {
                    context.Result= new OkObjectResult(new BadOpResult(string.Join(",", errors.ToArray())));
                }
                else
                {
                    context.Result = new OkResult();
                }
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
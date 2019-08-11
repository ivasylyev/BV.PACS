using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BV.PACS.WEB.Server.Filters
{
    public class PacsExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var exceptionStack = context.Exception.StackTrace;
            var exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = $"Action: '{actionName}', Exception: {Environment.NewLine} {exceptionMessage} {Environment.NewLine} {exceptionStack}"
            };
            context.ExceptionHandled = true;
        }
    }
}
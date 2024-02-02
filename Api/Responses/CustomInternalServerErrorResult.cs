using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Responses {
    internal class CustomInternalServerErrorResult : IActionResult {
        private readonly string _json;

        public CustomInternalServerErrorResult(string json) {
            _json = json;
        }

        public Task ExecuteResultAsync(ActionContext context) {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            context.HttpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_json);
            return context.HttpContext.Response.WriteAsync(_json);
        }
    }
}

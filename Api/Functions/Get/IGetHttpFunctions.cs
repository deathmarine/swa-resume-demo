using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMSWAResumeAPI.Functions.Get {
    public interface IGetHttpFunctions {
        Task<IActionResult> GetHealth(HttpRequest req, ILogger log);
        Task<IActionResult> GetSetup(HttpRequest req, ILogger log);
        Task<IActionResult> GetPerson(HttpRequest req, ILogger log);
        Task<IActionResult> GetExperience(HttpRequest req, ILogger log);
        Task<IActionResult> GetEducation(HttpRequest req, ILogger log);
        Task<IActionResult> GetAwards(HttpRequest req, ILogger log);
        Task<IActionResult> GetCertifications(HttpRequest req, ILogger log);
        Task<IActionResult> GetProjects(HttpRequest req, ILogger log);
        Task<IActionResult> GetBlob(HttpRequest req, ILogger log);
        Task<IActionResult> GetQRCode(HttpRequest req, ILogger log);
    }
}

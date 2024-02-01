using JMSWAResume.Models;
using JMSWAResume.Pages.Resume;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace JMSWAResume.Services {
    public class APIService: APIServiceAbstract {
        public APIService(HttpClient httpClient, ILogger<APIService> logger) {
            _httpClient = httpClient;
            _logger = logger;
        }
        

    }
}

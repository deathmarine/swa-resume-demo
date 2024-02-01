using JMSWAResume.Models;
using System.Text.Json;
using System.Text;

namespace JMSWAResume.Services {
    public class APITestService: APIServiceAbstract {

        public APITestService(IHttpClientFactory factory, ILogger<APIService> logger) {
            _httpClient = factory.CreateClient("dev_api");
            _logger = logger;
        }
    }
}

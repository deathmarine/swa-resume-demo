
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace JMSWAResume.Logging {
    public class APILoggingProvider: ILoggerProvider {

        private ILogger _logger;
        private readonly APILoggerConfiguration _currentConfig;
        private readonly HttpClient _client;
        public APILoggingProvider(IOptionsMonitor<APILoggerConfiguration> config) {
            _currentConfig = config.CurrentValue;

            //Hated doing this, but it was the only way I could get a Client here.
            //I tried using the HttpClientFactory, but it was not working.
            //Tried Scoping a client to the provider, but it was not working.
            //Tried using addHttpClient to the Extension, but it was not working.
            //Tried Scoping a clientFactory to the Extension, but it was not working.
            
            _client = new HttpClient() { BaseAddress = new Uri(_currentConfig.BaseAddress)};
        }
        public ILogger CreateLogger(string categoryName) {
            _logger = new APILogger(categoryName , GetCurrentConfig, _client);
            return _logger;
        }
        private APILoggerConfiguration GetCurrentConfig() => _currentConfig;
        public void Dispose() {
            _logger = null;
            _client.Dispose();
        }
    }
}

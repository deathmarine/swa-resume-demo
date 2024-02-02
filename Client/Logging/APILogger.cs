using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JMSWAResume.Logging {
    public class APILogger: ILogger {
        private readonly APILoggerConfiguration _currentConfig;
        private readonly HttpClient _client;
        private readonly string _categoryName;

    public APILogger(string categoryName, Func<APILoggerConfiguration> getCurrentConfig, HttpClient client) {
            _categoryName = categoryName;
            _currentConfig = getCurrentConfig();
            _client = client;
        }
#nullable enable
#pragma warning disable CS8633 
#pragma warning disable CS8766 
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;
#pragma warning restore CS8766 
#pragma warning restore CS8633 
#nullable disable
        public bool IsEnabled(LogLevel logLevel) {
            if(_currentConfig.Filter.Contains(logLevel))
                return false;
            return true;
        }

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            Console.WriteLine($"[{logLevel}] {_categoryName}[{eventId}] {formatter(state, exception)}");
            var model = new LoggingModel() {
                LogLevel = logLevel.ToString(),
                CategoryName = _categoryName,
                Message = formatter(state, exception),
                //Exception = exception.StackTrace ?? ""
            };
            var json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            //await _client.PostAsync("api/Log", new StringContent(json, Encoding.UTF8, "application/json"));
            await Task.Run(() => { });

        }

        public void Dispose() {
            _client.Dispose();
        }
    }
}

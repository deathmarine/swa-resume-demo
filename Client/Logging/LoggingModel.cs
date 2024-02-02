
namespace JMSWAResume.Logging {
    public class LoggingModel {
        public string LogLevel {
            get; set;
        }
        public string CategoryName {
            get; set;
        }
        public string Message {
            get; set;
        }
        public string Exception {
            get; set;
        }

        public LogLevel GetLogLevel() {
            switch (LogLevel) {
                case "Trace": return Microsoft.Extensions.Logging.LogLevel.Trace;
                case "Debug": return Microsoft.Extensions.Logging.LogLevel.Debug;
                case "Information": return Microsoft.Extensions.Logging.LogLevel.Information;
                case "Warning": return Microsoft.Extensions.Logging.LogLevel.Warning;
                case "Error": return Microsoft.Extensions.Logging.LogLevel.Error;
                case "Critical": return Microsoft.Extensions.Logging.LogLevel.Critical;
                case "None": return Microsoft.Extensions.Logging.LogLevel.None;
                default: return Microsoft.Extensions.Logging.LogLevel.None;
            }
        }
        public static LogLevel[] GetAllLogLevels() {
                   return new LogLevel[] {
                Microsoft.Extensions.Logging.LogLevel.Trace,
                Microsoft.Extensions.Logging.LogLevel.Debug,
                Microsoft.Extensions.Logging.LogLevel.Information,
                Microsoft.Extensions.Logging.LogLevel.Warning,
                Microsoft.Extensions.Logging.LogLevel.Error,
                Microsoft.Extensions.Logging.LogLevel.Critical,
                Microsoft.Extensions.Logging.LogLevel.None
            };
        }
    }
}

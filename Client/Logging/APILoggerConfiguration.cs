namespace JMSWAResume.Logging {
    public class APILoggerConfiguration {
        public string BaseAddress {
            get; set;
        }
        public List<LogLevel> Filter = new List<LogLevel>();
        public string FactoryName {
            get; set;
        }
    }
}

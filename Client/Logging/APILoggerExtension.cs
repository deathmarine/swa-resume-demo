using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace JMSWAResume.Logging {
    public static class APILoggerExtension {

        public static ILoggingBuilder AddAPILogger(
            this ILoggingBuilder builder) {
            builder.AddConfiguration();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, APILoggingProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <APILoggerConfiguration, APILoggingProvider>(builder.Services);
            return builder;
        }
        public static ILoggingBuilder AddAPILogger(
        this ILoggingBuilder builder,
        Action<APILoggerConfiguration> configure) {
            builder.AddAPILogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}

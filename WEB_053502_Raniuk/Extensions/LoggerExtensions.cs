using WEB_Raniuk_053502.Services;

namespace WEB_Raniuk_053502.Extensions
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }

        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string path)
        {
            builder.AddProvider(new FileLoggerProvider(path));
            return builder;
        }
    }
}
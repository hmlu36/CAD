using Anotar.Log4Net;
using Microsoft.Extensions.Logging;
using System;

/// <summary>
/// 紀錄entity framework query log
/// 參考 https://ef.readthedocs.io/en/staging/miscellaneous/logging.html
/// </summary>
namespace Dotnet.Utils.Logger {
    public class EFLoggerProvider : ILoggerProvider {

        public ILogger CreateLogger(string categoryName) {
            return new EFLogger();
        }

        public void Dispose() { }

        private class EFLogger : ILogger {
            public bool IsEnabled(LogLevel logLevel) {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
                switch (logLevel) {
                    case LogLevel.Critical:
                        LogTo.Fatal(formatter(state, exception));
                        break;
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                        LogTo.Debug(formatter(state, exception));
                        break;
                    case LogLevel.Error:
                        LogTo.Error(formatter(state, exception));
                        break;
                    case LogLevel.Information:
                        LogTo.Info(formatter(state, exception));
                        break;
                    case LogLevel.Warning:
                        LogTo.Warn(formatter(state, exception));
                        break;
                }
            }

            public IDisposable BeginScope<TState>(TState state) {
                return null;
            }
        }
    }
}

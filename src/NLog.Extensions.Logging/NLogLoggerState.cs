using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace NLog.Extensions.Logging
{
    public class NLogLoggerState : INLogLoggerState, Microsoft.Extensions.Logging.ILogger
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public NLogLoggerState()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        /// <param name="logger"></param>
        public NLogLoggerState(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
            EventProperties = new Dictionary<object, object>();
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public NLogLoggerState(Microsoft.Extensions.Logging.ILogger logger, IDictionary<object, object> eventProperties)
        {
            _logger = logger;
            EventProperties = eventProperties;
        }

        /// <summary>
        /// Properties of the logevent
        /// </summary>
        public IDictionary<object, object> EventProperties { get; }

        /// <summary>Writes a log entry.</summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <c>string</c> message of the <paramref name="state" /> and <paramref name="exception" />.</param>
        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            NLogLogger.LogEvent(_logger, eventId, state, exception, formatter, EventProperties);
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel" /> is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns><c>true</c> if enabled.</returns>
        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }

        /// <summary>Begins a logical operation scope.</summary>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }
    }
}
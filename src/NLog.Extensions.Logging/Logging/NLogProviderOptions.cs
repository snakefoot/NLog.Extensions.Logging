﻿namespace NLog.Extensions.Logging
{
    /// <summary>
    /// Options for logging to NLog with 
    /// </summary>
    public class NLogProviderOptions
    {
        /// <summary>
        /// Separator between for EventId.Id and EventId.Name. Default to _
        /// </summary>
        public string EventIdSeparator { get; set; } = "_";

        /// <summary>
        /// Skip allocation of <see cref="LogEventInfo.Properties" />-dictionary
        /// </summary>
        /// <remarks>
        /// using
        ///     <c>default(EventId)</c></remarks>
        public bool IgnoreEmptyEventId { get; set; } = true;

        /// <summary>
        /// Enable structured logging by capturing message template parameters with support for "@" and "$". Enables use of ${message:raw=true}
        /// </summary>
        public bool CaptureMessageTemplates { get; set; } = true;

        /// <summary>
        /// Enable capture of properties from the ILogger-State-object, both in <see cref="Microsoft.Extensions.Logging.ILogger.Log{TState}"/> and <see cref="Microsoft.Extensions.Logging.ILogger.BeginScope{TState}"/>
        /// </summary>
        public bool CaptureMessageProperties { get; set; } = true;

        /// <summary>
        /// Use the NLog engine for parsing the message template (again) and format using the NLog formatter
        /// </summary>
        public bool ParseMessageTemplates { get; set; }

        /// <summary>
        /// Enable capture of scope information and inject into <see cref="NestedDiagnosticsLogicalContext" /> and <see cref="MappedDiagnosticsLogicalContext" />
        /// </summary>
        public bool IncludeScopes { get; set; } = true;

        /// <summary>
        /// Shutdown NLog on dispose of the <see cref="NLogLoggerProvider"/>
        /// </summary>
        public bool ShutdownOnDispose { get; set; }

        /// <summary>
        /// Enable additional capture of the entire <see cref="Microsoft.Extensions.Logging.EventId"/> as "EventId"-property.
        /// </summary>
        /// <remarks>
        /// Enabling capture of the entire "EventId" will increase memory allocation and gives a performance hit. Faster to use "EventId_Id" + "EventId_Name".
        /// </remarks>
        public bool CaptureEntireEventId { get; set; }

        /// <summary>Initializes a new instance NLogProviderOptions with default values.</summary>
        public NLogProviderOptions()
        {
        }

        /// <summary>
        /// Default options
        /// </summary>
        internal static readonly NLogProviderOptions Default = new NLogProviderOptions();
    }
}

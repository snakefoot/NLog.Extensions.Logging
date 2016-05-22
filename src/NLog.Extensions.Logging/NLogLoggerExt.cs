using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLog.Extensions.Logging
{
    public static class NLogLoggerExt
    {
        public static INLogLoggerState WithProperty(this Microsoft.Extensions.Logging.ILogger logger, object name, object value)
        {
            var state = new NLogLoggerState(logger);
            state.EventProperties.Add(name, value);
            return state;
        }

        public static INLogLoggerState WithProperties(this Microsoft.Extensions.Logging.ILogger logger, IDictionary<object, object> eventProperties)
        {
            var state = new NLogLoggerState(logger, eventProperties);
            return state;
        }

    }
}

using Serilog.Core;
using Serilog.Events;
using System;

namespace Serilog.Enrichers.EventCode
{
    public class EventCodeEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent is null)
                throw new ArgumentNullException(nameof(logEvent));

            if (propertyFactory is null)
                throw new ArgumentNullException(nameof(propertyFactory));

            var hash = string.Format("{0:X}", GetDeterministicHashCode(logEvent.MessageTemplate.Text));
            var eventId = propertyFactory.CreateProperty("EventCode", hash);
            logEvent.AddPropertyIfAbsent(eventId);
        }

        private static string GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                int hash = hash1 + (hash2 * 1566083941);

                return string.Format("{0:X}", hash);
            }
        }
    }
}

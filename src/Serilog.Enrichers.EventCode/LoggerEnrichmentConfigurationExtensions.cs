using Serilog.Configuration;
using System;

namespace Serilog.Enrichers.EventCode
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers related to memory.
    /// capabilities.
    /// </summary>
    public static class LoggerEnrichmentConfigurationExtensions
    {
        /// <summary>
        /// Enrich log events with event code field.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithEventCode(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<EventCodeEnricher>();
        }
    }
}

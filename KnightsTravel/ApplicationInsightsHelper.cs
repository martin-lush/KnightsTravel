using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;

namespace KnightsTravel
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class ApplicationInsightsHelper
    {
        public static TelemetryClient GenerateApplicationInsightsService(string instrumentationKey)
        {
            using (TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault())
            {
                configuration.InstrumentationKey = instrumentationKey;

                using (var telemetryModule = new DependencyTrackingTelemetryModule())
                {
                    telemetryModule.Initialize(configuration);
                }

                return new TelemetryClient(configuration);
            }
        }
    }
}

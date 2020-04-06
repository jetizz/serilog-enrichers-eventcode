# Serilog.Enrichers.EventCode
Adds EventCode to log events, based on deterministic hash of messageTemplate field.

![Build](https://github.com/jetizz/serilog-enrichers-eventcode/workflows/Build%20and%20test/badge.svg)
![Nuget](https://img.shields.io/nuget/v/Serilog.Enrichers.EventCode)


## Usage
To use the enricher, install the NuGet package:

```
Install-Package Serilog.Enrichers.EventCode
```

Then modify your logging configuration:

```csharp
new LoggerConfiguration()
    .Enrich.WithEventCode();
```
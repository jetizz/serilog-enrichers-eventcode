# Serilog.Enrichers.EventCode
Adds EventCode to log events, based on deterministic hash of messageTemplate field.

![Build](https://github.com/jetizz/serilog-enrichers-eventcode/workflows/Build/badge.svg)
[![Nuget](https://img.shields.io/nuget/v/Serilog.Enrichers.EventCode.svg)](https://www.nuget.org/packages/Serilog.Enrichers.EventCode/)

## Idea
> Code based on this article: https://nblumhardt.com/2015/10/assigning-event-types-to-serilog-events/

Gives unique event code field to events, based on message template. To avoid dependencies, internal GetHashCode is used to calculate _unique_ event code. Since GetHashCode gives different result each time application is started, small deterministic version of the code is included. EventCode field is finally converted to hex, giving values such as: 
```
EventCode   4791F864
EventCode   F01BA992
EventCode   690292AA
```

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
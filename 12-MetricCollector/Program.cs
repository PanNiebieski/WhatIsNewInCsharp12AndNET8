using Microsoft.Extensions.Telemetry.Testing.Metering;
using Microsoft.Extensions.Time.Testing;
using System.Diagnostics.Metrics;
using Xunit;

//The MetricCollector class can now record metric measurements along with timestamps.
//Additionally, the class offers the flexibility to use any desired time provider for
//accurate timestamp generation.

const string CounterName = "MyCounter";

var now = DateTimeOffset.Now;

var timeProvider = new FakeTimeProvider(now);

using var meter = new Meter(Guid.NewGuid().ToString());
var counter = meter.CreateCounter<long>(CounterName);
using var collector = new MetricCollector<long>(counter, timeProvider);

Assert.Empty(collector.GetMeasurementSnapshot());
Assert.Null(collector.LastMeasurement);

counter.Add(3);

// verify the update was recorded
Assert.Equal(counter, collector.Instrument);
Assert.NotNull(collector.LastMeasurement);

Assert.Single(collector.GetMeasurementSnapshot());
Assert.Same(collector.GetMeasurementSnapshot().Last(), collector.LastMeasurement);
Assert.Equal(3, collector.LastMeasurement.Value);
Assert.Empty(collector.LastMeasurement.Tags);
Assert.Equal(now, collector.LastMeasurement.Timestamp);

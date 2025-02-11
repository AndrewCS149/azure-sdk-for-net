// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(DataBoxOrderCompletedEventDataConverter))]
    public partial class DataBoxOrderCompletedEventData
    {
        internal static DataBoxOrderCompletedEventData DeserializeDataBoxOrderCompletedEventData(JsonElement element)
        {
            Optional<string> serialNumber = default;
            Optional<DataBoxStageName> stageName = default;
            Optional<DateTimeOffset> stageTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serialNumber"))
                {
                    serialNumber = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("stageName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    stageName = new DataBoxStageName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("stageTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    stageTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new DataBoxOrderCompletedEventData(serialNumber.Value, Optional.ToNullable(stageName), Optional.ToNullable(stageTime));
        }

        internal partial class DataBoxOrderCompletedEventDataConverter : JsonConverter<DataBoxOrderCompletedEventData>
        {
            public override void Write(Utf8JsonWriter writer, DataBoxOrderCompletedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
            public override DataBoxOrderCompletedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDataBoxOrderCompletedEventData(document.RootElement);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.SignalR;

namespace Azure.ResourceManager.SignalR.Models
{
    internal partial class SignalRPrivateEndpointConnectionListResult
    {
        internal static SignalRPrivateEndpointConnectionListResult DeserializeSignalRPrivateEndpointConnectionListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SignalRPrivateEndpointConnectionData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SignalRPrivateEndpointConnectionData> array = new List<SignalRPrivateEndpointConnectionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SignalRPrivateEndpointConnectionData.DeserializeSignalRPrivateEndpointConnectionData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SignalRPrivateEndpointConnectionListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CustomerInsights;

namespace Azure.ResourceManager.CustomerInsights.Models
{
    /// <summary> The response of list profile operation. </summary>
    internal partial class ProfileListResult
    {
        /// <summary> Initializes a new instance of ProfileListResult. </summary>
        internal ProfileListResult()
        {
            Value = new ChangeTrackingList<ProfileResourceFormatData>();
        }

        /// <summary> Initializes a new instance of ProfileListResult. </summary>
        /// <param name="value"> Results of the list operation. </param>
        /// <param name="nextLink"> Link to the next set of results. </param>
        internal ProfileListResult(IReadOnlyList<ProfileResourceFormatData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Results of the list operation. </summary>
        public IReadOnlyList<ProfileResourceFormatData> Value { get; }
        /// <summary> Link to the next set of results. </summary>
        public string NextLink { get; }
    }
}

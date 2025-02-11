// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

[assembly: CodeGenSuppressType("SecurityInsightsAlertRuleTemplateResource")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A Class representing a SecurityInsightsAlertRuleTemplate along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SecurityInsightsAlertRuleTemplateResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSecurityInsightsAlertRuleTemplateResource method.
    /// Otherwise you can get one from its parent resource <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> using the GetSecurityInsightsAlertRuleTemplate method.
    /// </summary>
    public partial class SecurityInsightsAlertRuleTemplateResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SecurityInsightsAlertRuleTemplateResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string alertRuleTemplateId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRuleTemplates/{alertRuleTemplateId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _securityInsightsAlertRuleTemplateAlertRuleTemplatesClientDiagnostics;
        private readonly AlertRuleTemplatesRestOperations _securityInsightsAlertRuleTemplateAlertRuleTemplatesRestClient;
        private readonly SecurityInsightsAlertRuleTemplateData _data;

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAlertRuleTemplateResource"/> class for mocking. </summary>
        protected SecurityInsightsAlertRuleTemplateResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SecurityInsightsAlertRuleTemplateResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SecurityInsightsAlertRuleTemplateResource(ArmClient client, SecurityInsightsAlertRuleTemplateData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsAlertRuleTemplateResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SecurityInsightsAlertRuleTemplateResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityInsightsAlertRuleTemplateAlertRuleTemplatesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string securityInsightsAlertRuleTemplateAlertRuleTemplatesApiVersion);
            _securityInsightsAlertRuleTemplateAlertRuleTemplatesRestClient = new AlertRuleTemplatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsAlertRuleTemplateAlertRuleTemplatesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.SecurityInsights/alertRuleTemplates";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SecurityInsightsAlertRuleTemplateData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the alert rule template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRuleTemplates/{alertRuleTemplateId}
        /// Operation Id: AlertRuleTemplates_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityInsightsAlertRuleTemplateResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsAlertRuleTemplateAlertRuleTemplatesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleTemplateResource.Get");
            scope.Start();
            try
            {
                var response = await _securityInsightsAlertRuleTemplateAlertRuleTemplatesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAlertRuleTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the alert rule template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRuleTemplates/{alertRuleTemplateId}
        /// Operation Id: AlertRuleTemplates_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityInsightsAlertRuleTemplateResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsAlertRuleTemplateAlertRuleTemplatesClientDiagnostics.CreateScope("SecurityInsightsAlertRuleTemplateResource.Get");
            scope.Start();
            try
            {
                var response = _securityInsightsAlertRuleTemplateAlertRuleTemplatesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsAlertRuleTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

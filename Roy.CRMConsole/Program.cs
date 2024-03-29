using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using System.Net.Sockets;

namespace Roy.CRMConsole
{
    internal class Program
    {
        /// <summary>
        /// for this code to run install Microsoft.CrmSdk.XrmTooling.CoreAssembly from nuget org
        /// </summary>
        /// <param name="connectionString"></param>
        /// <remarks>Both CrmServiceClient and OrganizationWebProxyClient implements IOrganizationService
        /// OrganizationWebProxyClient is not disposable and should only be used if the code uses early bound classes. In that case we need
        /// OrganizationWebProxyClient to generate the context object. if your application uses late bound using disposable CrmServiceClient is sufficient</remarks>

        public static IOrganizationService Connect(string connectionString)
        {
            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient != null ? crmServiceClient.OrganizationWebProxyClient as IOrganizationService
                : throw new Exception("Failed to Create Connection");

        }

        public void ConnectionWithClientSecret()
        {
            string clientId = "";
            string clientSecret = "";
            string dataverseURL = "";

            string connectionString = $"AuthType=ClientSecret;" + // more on https://docs.microsoft.com/en-us/powerapps/developer/data-platform/xrm-tooling/use-connection-strings-xrm-tooling-connect#connection-string-parameters 
                                   $"url={dataverseURL};" +
                                   $"ClientId={clientId};" +
                                   $"ClientSecret={clientSecret};" +
                                   $"RequireNewInstance=false;";
        }
        static void Main(string[] args)
        {
        }
        
    }
}

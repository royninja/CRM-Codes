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
using System.Configuration;

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
        /// CrmClientService to generate the context object. if your application uses late bound using disposable CrmServiceClient is sufficient</remarks>

        public static IOrganizationService ConnectionWithCredentials()
        { 

            Uri serviceUri = new Uri("https://roy.crm8.dynamics.com");
            string userName = "";
            string password = "";

            string conn = $@"
            Url = {serviceUri};
            AuthType = OAuth;
            UserName = {userName};
            Password = {password};
            AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
            RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
            LoginPrompt=Auto;
            RequireNewInstance = True";

            var service = new CrmServiceClient(conn);

            return service;

        }

        /// <summary>
        /// for this code to run install Microsoft.CrmSdk.XrmTooling.CoreAssembly from nuget org
        /// </summary>
        /// <param name="connectionString"></param>
        /// <remarks>Both CrmServiceClient and OrganizationWebProxyClient implements IOrganizationService
        /// OrganizationWebProxyClient is not disposable and should only be used if the code uses early bound classes. In that case we need
        /// OrganizationWebProxyClient to generate the context object. if your application uses late bound using disposable CrmServiceClient is sufficient</remarks>

        public static IOrganizationService ConnectionWithClientSecret()
        {
            string organizationUri = ConfigurationManager.AppSettings["organizationURL"].ToString();
            string clientId = ConfigurationManager.AppSettings["organizationURL"].ToString();
            string clientSecret = ConfigurationManager.AppSettings["organizationURL"].ToString(); //valid for 6 months
            CrmServiceClient connection = new CrmServiceClient($@"AuthType=ClientSecret;url={organizationUri};ClientId={clientId};ClientSecret={clientSecret}");

            return connection.OrganizationWebProxyClient != null ? connection.OrganizationWebProxyClient : (IOrganizationService)connection.OrganizationServiceProxy;
        }
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionWithClientSecret();
            try
            {

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.ServiceProxy
{
    public class HttpsConnector<T>
    {
        public BasicHttpsBinding myBinding { get; set; }
        
        public EndpointAddress myEndpoint { get; set; }
        private ChannelFactory<T> mychannel { get; set;}
        private RemoteCertificateValidationCallback rm { get; set; }
        private Boolean isAvoidedSSL { get; set; }

        #region Hack  for Avoiding SSL Policies
        private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        #endregion

        /// <summary>
        /// Initializes a Default Connector with HTTPS
        /// </summary>
        /// <param name="Url"></param>
        public HttpsConnector(String Url)
        {
            myBinding = new BasicHttpsBinding();
            isAvoidedSSL = false;
            myEndpoint = new EndpointAddress(Url);

        }
        /// <summary>
        /// Initializes a Default Connector with HTTPS, if AvoidSSLErrors is True, 
        /// The service avoid security exceptions if the server didn't have SSL policies Well Configured
        /// </summary>
        /// <param name="Url"></param>
        public HttpsConnector(String Url, Boolean AvoidSSLErrors)
        {
            if (AvoidSSLErrors) rm = new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            myBinding = new BasicHttpsBinding();
            myEndpoint = new EndpointAddress(Url);

        }

        /// <summary>
        /// Returns Instance of the Contract Service Proxy
        /// </summary>
        /// <returns></returns>
        public T GetProxy()
        {
            mychannel = new ChannelFactory<T>(myBinding, myEndpoint);
            if (isAvoidedSSL) ServicePointManager.ServerCertificateValidationCallback += rm;
            return mychannel.CreateChannel();
        }

        /// <summary>
        /// Close The Contract Service Proxy
        /// </summary>
        public void CloseConnection()
        {
            mychannel.Close();
            if (isAvoidedSSL) ServicePointManager.ServerCertificateValidationCallback -= rm;
        }

        
    }
}

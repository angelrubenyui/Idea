using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.ServiceProxy
{
    public class HttpConnector<T>
    {
        public BasicHttpBinding myBinding { get; set; }
        public EndpointAddress myEndpoint { get; set; }
        private ChannelFactory<T> mychannel { get; set;}
        
        /// <summary>
        /// Initializes a Default Service Proxy Connector with HTTP
        /// </summary>
        /// <param name="Url"></param>
        public HttpConnector(String Url)
        {
            myBinding = new BasicHttpBinding();
            myEndpoint = new EndpointAddress(Url);

        }

        /// <summary>
        /// Returns Instance of the Contract Service Proxy
        /// </summary>
        /// <returns></returns>
        public T GetProxy()
        {
            mychannel = new ChannelFactory<T>(myBinding, myEndpoint);
            return mychannel.CreateChannel();
        }

        /// <summary>
        /// Close The Contract Service Proxy
        /// </summary>
        public void CloseConnection()
        {
            mychannel.Close();
        }
    }
}

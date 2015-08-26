using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Infrastructure.Core.ServiceProxy
{
    internal class ChannelProxy<TChannel> where TChannel : class
    {
        public static ChannelProxy<TChannel> Instance = new ChannelProxy<TChannel>();
        protected String EndPointConfigurationName = typeof(TChannel).Name;
        private ChannelFactory<TChannel> factory;

        static ChannelProxy() { }

        protected ChannelFactory<TChannel> Factory {
            get {
                if (this.factory != null && this.factory.State == CommunicationState.Faulted) {
                    this.factory.Abort();
                    this.factory = null;
                }
                if (this.factory != null && (this.factory.State==CommunicationState.Closed || this.factory.State== CommunicationState.Closing)) {
                    this.factory = null;
                }
                if (null == this.factory) {
                    this.factory = new ChannelFactory<TChannel>(this.EndPointConfigurationName);
                }

                return this.factory;
            }
        }

        public TChannel GetChannel() {
            return this.Factory.CreateChannel();
        }

        public void PutChannel(TChannel channel) {
            ICommunicationObject commObj = channel as ICommunicationObject;
            if (commObj != null) {
                switch (commObj.State) { 
                    case CommunicationState.Created:
                    case CommunicationState.Opening:
                    case CommunicationState.Opened:
                        commObj.Close();
                        break;
                    case CommunicationState.Faulted:
                        commObj.Abort();
                        break;
                }
            }
        }
    }
}

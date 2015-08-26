using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;

namespace Infrastructure.Core.ServiceProxy
{
    internal class ServiceProxy<TChannel> : RealProxy
        where TChannel : class
    {
        public ServiceProxy()
            : base(typeof(TChannel))
        { }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodReturnMessage returnMsg = null;
            IMethodCallMessage callMsg = msg as IMethodCallMessage;

            Object[] objArray = new Object[callMsg.ArgCount];
            callMsg.Args.CopyTo(objArray, 0);
            //old method
            //TChannel channel = new ChannelFactory<TChannel>(typeof(TChannel).Name).CreateChannel();
            TChannel channel = ChannelProxy<TChannel>.Instance.GetChannel();
            try
            {
                var returnObj = callMsg.MethodBase.Invoke(channel, objArray);
                returnMsg = new ReturnMessage(returnObj, objArray, callMsg.ArgCount, callMsg.LogicalCallContext, callMsg);
            }
            catch (Exception ex)
            {
                var exception = ex;
                if (exception.InnerException != null) exception = ex.InnerException;
                returnMsg = new ReturnMessage(exception, callMsg);
            }
            finally
            {
                ChannelProxy<TChannel>.Instance.PutChannel(channel);
                //old method
                //var commObj = channel as ICommunicationObject;
                //if (commObj != null) {
                //    try
                //    {
                //        commObj.Close();
                //    }
                //    catch (CommunicationException ex)
                //    {
                //        commObj.Abort();
                //    }
                //    catch (TimeoutException ex)
                //    {
                //        commObj.Abort();
                //    }
                //    catch (Exception ex) {
                //        commObj.Abort();
                //        throw;
                //    }
                //}
            }

            return returnMsg;
        }
    }
}

using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace DevUtility.Out.Net.WCF
{
    public class WCFHelper
    {
        #region Create Service

        public static T CreateService<T>(string url, string bindingType)
        {
            EndpointAddress address = new EndpointAddress(url);
            Binding binding = CreateBinding(bindingType);
            ChannelFactory<T> channelFactory = new ChannelFactory<T>(binding, address);
            return channelFactory.CreateChannel();
        }

        #endregion

        #region Create Binding

        public static Binding CreateBinding(string bindingType)
        {
            BindingType type = EnumHelper.GetType<BindingType>(bindingType);
            return CreateBinding(type);
        }

        public static Binding CreateBinding(BindingType bindingType)
        {
            return CreateBinding(bindingType, 1048576);
        }

        public static Binding CreateBinding(BindingType bindingType, long maxReceivedMessageSize)
        {
            Binding binding = null;

            if (bindingType == BindingType.Unknow)
            {
                return binding;
            }

            switch (bindingType)
            {
                case BindingType.BasicHttpBinding:
                    BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                    basicHttpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = basicHttpBinding;
                    break;

                case BindingType.NetNamedPipeBinding:
                    NetNamedPipeBinding netNamedPipeBinding = new NetNamedPipeBinding();
                    netNamedPipeBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = netNamedPipeBinding;
                    break;

                case BindingType.NetPeerTcpBinding:
                    NetPeerTcpBinding netPeerTcpBinding = new NetPeerTcpBinding();
                    netPeerTcpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = netPeerTcpBinding;
                    break;

                case BindingType.NetTcpBinding:
                    NetTcpBinding netTcpBinding = new NetTcpBinding();
                    netTcpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = netTcpBinding;
                    break;

                case BindingType.WSDualHttpBinding:
                    WSDualHttpBinding wsDualHttpBinding = new WSDualHttpBinding();
                    wsDualHttpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = wsDualHttpBinding;
                    break;

                case BindingType.WSFederationHttpBinding:
                    WSFederationHttpBinding wsFederationHttpBinding = new WSFederationHttpBinding();
                    wsFederationHttpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = wsFederationHttpBinding;
                    break;

                case BindingType.WSHttpBinding:
                    WSHttpBinding wsHttpBinding = new WSHttpBinding();
                    wsHttpBinding.MaxReceivedMessageSize = maxReceivedMessageSize;
                    binding = wsHttpBinding;
                    break;
            }

            return binding;
        }

        #endregion
    }
}
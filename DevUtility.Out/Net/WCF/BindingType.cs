using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.WCF
{
    public enum BindingType
    {
        Unknow,
        BasicHttpBinding,
        NetNamedPipeBinding,
        NetPeerTcpBinding,
        NetTcpBinding,
        WSDualHttpBinding,
        WSFederationHttpBinding,
        WSHttpBinding
    }
}
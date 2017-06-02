using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.WCF
{
    [ServiceContract]
    public interface IPushMessage
    {
        [OperationContract]
        void Push(string message);
    }
}
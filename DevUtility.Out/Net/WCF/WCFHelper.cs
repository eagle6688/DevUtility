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
        #region Create Binding

        public static Binding CreateBinding(BindingType bindingType)
        {
            Binding binding = null;

            switch (bindingType)
            {
                case BindingType.BasicHttpBinding:
                    binding = new BasicHttpBinding();
                    break;
            }

            return binding;
        }

        #endregion
    }
}
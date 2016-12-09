using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevUtility.Win.Services.AppService
{
    public class AppServiceHelper
    {
        #region Run

        public static void Run(BaseAppService service)
        {
            AppServiceContainer appServiceContainer = new AppServiceContainer(service, true);
            appServiceContainer.Start();
        }

        #endregion

        #region Run thread

        public static void RunThread(BaseAppService service)
        {
            AppServiceContainer appServiceContainer = new AppServiceContainer(service, true);
            ThreadStart threadStart = new ThreadStart(appServiceContainer.Start);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        public static void RunThread(BaseAppService service, bool enableButtonAfterExcute)
        {
            AppServiceContainer appServiceContainer = new AppServiceContainer(service, enableButtonAfterExcute);
            ThreadStart threadStart = new ThreadStart(appServiceContainer.Start);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        #endregion

        #region Open form

        public static void OpenForm(string formName)
        {
            var form = System.Windows.Forms.Application.OpenForms[formName];

            if (form != null)
            {
                form.Show();
            }
        }

        #endregion
    }
}
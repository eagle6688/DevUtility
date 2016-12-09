using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Win.Services.AppService
{
    public class AppServiceContainer
    {
        #region Variable

        BaseAppService service;

        bool enableButtonAfterExcute;

        #endregion

        #region Constructor

        public AppServiceContainer(BaseAppService service, bool enableButtonAfterExcute)
        {
            this.service = service;
            this.enableButtonAfterExcute = enableButtonAfterExcute;
        }

        #endregion

        #region Start

        public void Start()
        {
            service.EnableButton(false);
            service.Start();

            if (enableButtonAfterExcute)
            {
                service.EnableButton(true);
            }
        }

        #endregion
    }
}
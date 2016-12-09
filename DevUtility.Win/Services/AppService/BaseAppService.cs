using DevUtility.Win.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Win.Services.AppService
{
    public abstract class BaseAppService
    {
        #region Properties

        public LogEventDelegate LogEvent { set; get; }

        public TextBoxService AppTextBoxService { set; get; }

        public ButtonService AppButtonService { set; get; }

        #endregion

        #region Constructor

        public BaseAppService() { }

        #endregion

        #region Methods

        public abstract void Start();

        #endregion

        #region Services

        protected void DisplayMessage(string message, bool isLog = false)
        {
            if (AppTextBoxService != null)
            {
                AppTextBoxService.SafeAppend(message);
            }

            if (isLog)
            {
                if (LogEvent != null)
                {
                    LogEvent(message);
                }
                else
                {
                    DevUtility.Com.Application.Log.LogHelper.Info(null, message);
                }
            }
        }

        protected StringBuilder GetTextBoxValue()
        {
            if (AppTextBoxService == null)
            {
                return new StringBuilder("");
            }

            return AppTextBoxService.GetTextBoxValue();
        }

        public void EnableButton(bool isEnabled)
        {
            if (AppButtonService != null)
            {
                AppButtonService.SafeEnableButton(isEnabled);
            }
        }

        protected void Log(string content)
        {
            if (LogEvent != null)
            {
                LogEvent(content);
            }
        }

        #endregion
    }
}
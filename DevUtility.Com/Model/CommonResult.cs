using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Model
{
    public class CommonResult<TResult>
    {
        #region Variables

        string message = "";

        List<string> messages = new List<string>();

        Dictionary<string, string> messagesDic = new Dictionary<string, string>();

        #endregion

        #region Properties

        public bool IsSucceeded { set; get; }

        public object Message
        {
            get
            {
                if (!string.IsNullOrEmpty(message))
                {
                    return message;
                }

                if (messages.Count > 0)
                {
                    return messages;
                }

                if (messagesDic.Count > 0)
                {
                    return messagesDic;
                }

                return null;
            }
        }

        public TResult Data { set; get; }

        #endregion

        #region Constructor

        public CommonResult()
        {
            IsSucceeded = true;
            Data = default(TResult);
        }

        #endregion

        #region Set Error Message

        public void SetErrorMessage(string message)
        {
            IsSucceeded = false;
            this.message = message;
        }

        #endregion

        #region Append error message

        public void AddErrorMessage(string message)
        {
            IsSucceeded = false;
            messages.Add(message);
        }

        #endregion

        #region Add dictionary error

        public void AddDictionaryError(string name, string message)
        {
            IsSucceeded = false;

            if (messagesDic.ContainsKey(name))
            {
                messagesDic[name] = message;
            }
            else
            {
                messagesDic.Add(name, message);
            }
        }

        #endregion
    }
}
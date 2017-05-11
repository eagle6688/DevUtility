using DevUtility.Com.Extension.SystemExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Model
{
    public class OperationResult
    {
        #region Properties

        public bool IsSucceeded { set; get; }

        public string Message { set; get; }

        public object Data { set; get; }

        #endregion

        #region Variables

        StringBuilder message = new StringBuilder();

        #endregion

        #region Constructor

        public OperationResult()
        {
            IsSucceeded = true;
            Message = "";
            Data = null;
        }

        #endregion

        #region Set Message

        public void SetMessage(string message)
        {
            Message = message;
        }

        #endregion

        #region Set Error Message

        public void SetErrorMessage(Exception exception)
        {
            IsSucceeded = false;
            Message = exception.ToExceptionString();
        }

        public void SetErrorMessage(string message)
        {
            IsSucceeded = false;
            Message = message;
        }

        #endregion

        #region Append message

        public void AppendMessage(string message, string separator = "")
        {
            if (!string.IsNullOrEmpty(Message))
            {
                this.message.Append(Message);

                if (!string.IsNullOrEmpty(separator))
                {
                    this.message.Append(separator);
                }
            }

            this.message.Append(message);
            Message = this.message.ToString();
            this.message.Clear();
        }

        public void AppendErrorMessage(string message, string separator = "")
        {
            IsSucceeded = false;
            AppendMessage(message, separator);
        }

        #endregion

        #region Add dictionary error

        public void AddDictionaryError(string name, string message)
        {
            IsSucceeded = false;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            if (Data != null)
            {
                dictionary = Data as Dictionary<string, string>;
            }

            if (dictionary.ContainsKey(name))
            {
                dictionary[name] = message;
            }
            else
            {
                dictionary.Add(name, message);
            }

            Data = dictionary;
        }

        #endregion

        #region Get OperationResult

        public OperationResult GetOperationResult()
        {
            return new OperationResult()
            {
                IsSucceeded = IsSucceeded,
                Message = Message,
                Data = Data
            };
        }

        #endregion
    }
}
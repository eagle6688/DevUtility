﻿using DevUtility.Com.Base.Reflection;
using DevUtility.Com.Extension.SystemExt;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Base.Reflection
{
    public class AssemblyLoadService : BaseAppService
    {
        #region Variables

        string path;

        #endregion

        #region Constructor

        public AssemblyLoadService(string path)
        {
            this.path = path;
        }

        #endregion

        #region Start

        public override void Start()
        {
            try
            {
                path = "DevUtility.Out";
                string assemblyName = AssemblyHelper.GetAssemblyName(path);
                DisplayMessage(assemblyName);
                Assembly assembly = Assembly.Load(assemblyName);
                DisplayMessage(assembly.FullName);

                Type type = assembly.GetType("DevUtility.Out.Net.FTP.FTPHelper");
                DisplayMessage(type.Name);

                var t = AssemblyHelper.GetType(path, "DevUtility.Out.Net.FTP.FTPHelper");
                DisplayMessage(t.Name);
                MethodInfo methodInfo = t.GetMethod("UploadOverMove");

                foreach (var p in methodInfo.GetParameters())
                {
                    DisplayMessage(string.Format("Type: {0}, Name: {1}", p.ParameterType.FullName, p.Name));
                }

                DisplayMessage(string.Format("Return type: {0}", methodInfo.ReturnType.FullName));

                var t1 = AssemblyHelper.GetType("DevUtility.Test.WinForm.MainForm");
                DisplayMessage(t1.Name);
            }
            catch (Exception exception)
            {
                DisplayMessage(exception.ToExceptionString());
            }
        }

        #endregion
    }
}
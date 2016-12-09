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
    public class AssemblyLoadFileService : BaseAppService
    {
        #region Variables

        string path;

        #endregion

        #region Constructor

        public AssemblyLoadFileService(string path)
        {
            this.path = path;
        }

        #endregion

        #region Start

        public override void Start()
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(path);
                DisplayMessage(assembly.FullName);
            }
            catch (Exception exception)
            {
                DisplayMessage(exception.ToExceptionString());
            }
        }

        #endregion
    }
}
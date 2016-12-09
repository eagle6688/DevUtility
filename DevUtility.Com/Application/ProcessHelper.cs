using DevUtility.Com.Extension.SystemExt;
using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application
{
    public class ProcessHelper
    {
        #region Excute bat

        public static OperationResult ExcuteBat(string workingDirectory, string fileName)
        {
            OperationResult result = new OperationResult();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = "/K " + fileName;
            processStartInfo.WorkingDirectory = workingDirectory;
            processStartInfo.CreateNoWindow = true;

            try
            {
                using (Process process = Process.Start(processStartInfo))
                {
                    using (StreamReader streamReader = process.StandardOutput)
                    {
                        result.Data = streamReader.ReadToEnd().Trim();
                    }
                }
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception.ToExceptionContent().ToString());
            }
            
            return result;
        }

        #endregion

        #region Excute cmd

        public static OperationResult ExcuteCmd(string command)
        {
            OperationResult result = new OperationResult();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.Verb = "RunAs";

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;

                try
                {
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.WriteLine("exit");
                    result.Data = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                }
                catch (Exception exception)
                {
                    result.SetErrorMessage(exception.ToExceptionContent().ToString());
                }
            }

            return result;
        }

        #endregion
    }
}
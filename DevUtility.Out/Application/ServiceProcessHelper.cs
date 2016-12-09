using DevUtility.Com.Application.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DevUtility.Out.Application
{
    public class ServiceProcessHelper
    {
        #region Is existed

        public static bool IsExisted(string serviceName)
        {
            return GetServiceNames().Exists(q => q == serviceName);
        }

        #endregion

        #region Is running

        public static bool IsRunning(string serviceName)
        {
            string status = GetStatus(serviceName);

            if (status == "Running")
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Start

        public static bool Start(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);

            try
            {
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return false;
            }
        }

        public static bool Start(string serviceName, TimeSpan timeout)
        {
            ServiceController serviceController = new ServiceController(serviceName);

            try
            {
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return false;
            }
        }

        #endregion

        #region Stop

        public static bool Stop(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);

            if (serviceController.CanStop)
            {
                try
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                    return true;
                }
                catch (Exception exception)
                {
                    LogHelper.Error(exception);
                }
            }

            return false;
        }

        #endregion

        #region Get services

        public static List<string> GetServiceNames()
        {
            return ServiceController.GetServices().Select(q => q.ServiceName).ToList();
        }

        public static List<ServiceController> GetServices()
        {
            return ServiceController.GetServices().ToList();
        }

        #endregion

        #region Get Status

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns>ContinuePending, Paused, PausePending, Running, StartPending, Stopped, StopPending</returns>
        public static string GetStatus(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);

            try
            {
                return serviceController.Status.ToString();
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return "";
            }
        }

        #endregion
    }
}
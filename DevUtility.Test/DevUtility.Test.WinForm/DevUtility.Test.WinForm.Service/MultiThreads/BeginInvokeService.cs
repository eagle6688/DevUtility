using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.MultiThreads
{
    delegate int BeginInvokeTaskDelegate(int milliseconds);

    /// <summary>
    /// EndInvoke determines weather blocked UI.
    /// </summary>
    public class BeginInvokeService : BaseAppService
    {
        public override void Start()
        {
            //Will block UI
            ExcuteTask1();

            //Do not block UI
            ExcuteTask2();
        }

        private void ExcuteTask1()
        {
            var beginInvokeTask = new BeginInvokeTaskDelegate(BeginInvokeTask1);
            var asyncResult = beginInvokeTask.BeginInvoke(2000, null, null);

            int result = beginInvokeTask.EndInvoke(asyncResult);
            DisplayMessage(result.ToString());
        }

        private void ExcuteTask2()
        {
            var beginInvokeTask = new BeginInvokeTaskDelegate(BeginInvokeTask2);
            beginInvokeTask.BeginInvoke(2000, MethodCompleted, beginInvokeTask);
        }

        private int BeginInvokeTask1(int milliseconds)
        {
            DisplayMessage("Start Task1...");
            Thread.Sleep(milliseconds);

            Random random = new Random();
            int num = random.Next(10000);
            DisplayMessage("Finish Task1!");
            return num;
        }

        private int BeginInvokeTask2(int milliseconds)
        {
            DisplayMessage("Start Task2...");
            Thread.Sleep(milliseconds);

            Random random = new Random();
            int num = random.Next(10000);
            DisplayMessage("Finish Task2!");
            return num;
        }

        private void MethodCompleted(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
            {
                return;
            }

            int result = (asyncResult.AsyncState as BeginInvokeTaskDelegate).EndInvoke(asyncResult);
            DisplayMessage(result.ToString());
        }
    }
}
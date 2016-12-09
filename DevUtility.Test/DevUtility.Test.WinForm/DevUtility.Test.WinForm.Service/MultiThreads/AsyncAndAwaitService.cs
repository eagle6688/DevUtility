using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.MultiThreads
{
    public class AsyncAndAwaitService : BaseAppService
    {
        public override void Start()
        {
            AsyncMethod();
            DisplayMessage("Step A");
            DisplayMessage(Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private async void AsyncMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                DisplayMessage("Step B");
                DisplayMessage(Thread.CurrentThread.ManagedThreadId.ToString());
            });

            DisplayMessage("Step C");
            DisplayMessage(Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
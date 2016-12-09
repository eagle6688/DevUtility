using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Monitor
{
    public class FilesMonitor : IDisposable
    {
        #region Variable

        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        #endregion

        #region Properties

        public OnFileCreateEventDelegate OnFileCreateEvent { set; get; }

        public OnFileChangeEventDelegate OnFileChangeEvent { set; get; }

        public OnFileDeleteEventDelegate OnFileDeleteEvent { set; get; }

        public OnFileRenamedEventDelegate OnFileRenamedEvent { set; get; }

        #endregion

        #region Constructor

        public FilesMonitor(string watcherPath, string watcherFilter = "*.*", bool isEnableRaising = true, bool includeSubdirectories = true)
        {
            fileSystemWatcher.Path = watcherPath;
            fileSystemWatcher.Filter = watcherFilter;
            fileSystemWatcher.EnableRaisingEvents = isEnableRaising;
            fileSystemWatcher.IncludeSubdirectories = includeSubdirectories;
            fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
        }

        #endregion

        #region Init

        public void Init()
        {
            fileSystemWatcher.BeginInit();
            fileSystemWatcher.Created += new FileSystemEventHandler(OnFileCreate);
            fileSystemWatcher.Changed += new FileSystemEventHandler(OnFileChange);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(OnFileDelete);
            fileSystemWatcher.Renamed += new RenamedEventHandler(OnFileRenamed);
            fileSystemWatcher.EndInit();
        }

        #endregion

        #region On file create

        private void OnFileCreate(object sender, FileSystemEventArgs e)
        {
            if (OnFileCreateEvent != null)
            {
                OnFileCreateEvent(sender, e);
            }
        }

        #endregion

        #region On file change

        private void OnFileChange(object sender, FileSystemEventArgs e)
        {
            if (OnFileChangeEvent != null)
            {
                OnFileChangeEvent(sender, e);
            }
        }

        #endregion

        #region On file delete

        private void OnFileDelete(object sender, FileSystemEventArgs e)
        {
            if (OnFileDeleteEvent != null)
            {
                OnFileDeleteEvent(sender, e);
            }
        }

        #endregion

        #region On file renamed

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            if (OnFileRenamedEvent != null)
            {
                OnFileRenamedEvent(sender, e);
            }
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (fileSystemWatcher != null)
                {
                    fileSystemWatcher.Dispose();
                    fileSystemWatcher = null;
                }
            }

            OnFileCreateEvent = null;
            OnFileChangeEvent = null;
            OnFileDeleteEvent = null;
            OnFileRenamedEvent = null;
        }

        #endregion
    }
}
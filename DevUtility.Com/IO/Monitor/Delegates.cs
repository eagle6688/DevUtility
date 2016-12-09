using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevUtility.Com.IO.Monitor
{
    public delegate void OnFileCreateEventDelegate(object sender, FileSystemEventArgs e);

    public delegate void OnFileChangeEventDelegate(object sender, FileSystemEventArgs e);

    public delegate void OnFileDeleteEventDelegate(object sender, FileSystemEventArgs e);

    public delegate void OnFileRenamedEventDelegate(object sender, RenamedEventArgs e);
}
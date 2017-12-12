using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.UWP
{
    class FileAccessHelper
    {

        public static String GetLocalFilePath(String filename)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            return System.IO.Path.Combine(path, filename);
        }

    }
}

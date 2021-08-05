using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Common.Files
{
    public static class FileHandlers
    {
        public static string ReadStringFromFile(string path)
        {
            StreamReader r = new StreamReader(path);
            string jsonString = r.ReadToEnd();
            return jsonString;
        }
    }
}

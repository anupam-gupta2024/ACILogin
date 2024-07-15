using System;
using System.IO;
using System.Text;

namespace Utility
{
    public sealed class Log : ILog
    {
        private Log() { }

        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        public static Log getInstance { get { return instance.Value; } }

        public void LogException(string message)
        {
            string filename = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString("ddMMyyyy").Replace("/", "").Replace(" ", "_"));
            string logFilepath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filename);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(string.Format("Date & Time: {0}", DateTime.Now.ToString()));
            sb.AppendLine(message);

            string oldText = string.Empty;
            if (File.Exists(logFilepath))
                oldText = File.ReadAllText(logFilepath);

            using (StreamWriter sw = new StreamWriter(logFilepath, false))
            {
                sw.WriteLine(sb.ToString());
                if (!string.IsNullOrEmpty(oldText)) sw.WriteLine(oldText);
                sw.Flush();
            }
        }

        //public static void InsertText(string path, string newText)
        //{
        //    if (File.Exists(path))
        //    {
        //        string oldText = File.ReadAllText(path);
        //        using (var sw = new StreamWriter(path, false))
        //        {
        //            sw.WriteLine(newText);
        //            sw.WriteLine(oldText);
        //        }
        //    }
        //    else File.WriteAllText(path, newText);
        //}

        //public static void InsertLarge(string path, string newText)
        //{
        //    if (!File.Exists(path))
        //    {
        //        File.WriteAllText(path, newText);
        //        return;
        //    }

        //    var pathDir = Path.GetDirectoryName(path);
        //    var tempPath = Path.Combine(pathDir, Guid.NewGuid().ToString("N"));
        //    using (var stream = new FileStream(tempPath, FileMode.Create,
        //        FileAccess.Write, FileShare.None, 4 * 1024 * 1024))
        //    {
        //        using (var sw = new StreamWriter(stream))
        //        {
        //            sw.WriteLine(newText);
        //            sw.Flush();
        //            using (var old = File.OpenRead(path)) old.CopyTo(sw.BaseStream);
        //        }
        //    }
        //    File.Delete(path);
        //    File.Move(tempPath, path);
        //}
    }
}

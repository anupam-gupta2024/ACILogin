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
            string filename = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString("ddMMyyyy").Replace("/","").Replace(" ","_"));
            string logFilepath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filename);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter sw = new StreamWriter(logFilepath, true))
            {
                sw.WriteLine(sb.ToString());
                sw.Flush();
            }
        }
    }
}

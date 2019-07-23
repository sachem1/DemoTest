using System;
using System.IO;
using System.Text;

namespace Jiesen.Common
{
    public class LogManager
    {
        public static void AppendLogFile(string message)
        {
            var fileUrl = AppDomain.CurrentDomain.BaseDirectory + "Log//" + DateTime.Now.ToString("yyyy-MM-dd HH") +
                          ".txt";

            using (FileStream fs = new FileStream(fileUrl, FileMode.OpenOrCreate))
            {
                message = message + $"当前时间是:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n";
                var bytes = Encoding.UTF8.GetBytes(message);
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush(true);
            }
        }
    }
}

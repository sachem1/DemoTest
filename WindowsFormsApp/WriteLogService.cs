using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class WriteLogService
    {
        public void AppendLogFile()
        {
            var fileUrl = AppDomain.CurrentDomain.BaseDirectory +"Log//"+  DateTime.Now.ToString("yyyy-MM-dd HH") + ".txt";
            
            using(FileStream fs=new FileStream(fileUrl,FileMode.OpenOrCreate))
            {
                string log = $"当前时间是:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n";
                var bytes = Encoding.UTF8.GetBytes(log);
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush(true);
            }

        }
    }
}

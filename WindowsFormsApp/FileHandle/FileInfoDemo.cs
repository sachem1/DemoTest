using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.FileHandle
{
    /*
        File:静态类,FileInfo需要实例化
        1.如果单次操作,那么File方法效率比FileInfo 更高
        2.File类的静态方法对所有方法操作需要执行安全检查,如果多次重用某个对象进行操作,则用FileInfo实例方法,毕竟不是每次都需要安全检查
        3.所以执行方法的次数决定使用哪个类
        4.file,directory可以控制多个文件所以进行每次安全检查，而FileInfo,DirectoryInfo只能控制一个文件信息只进行一次安全处理。 
    */
    public class FileInfoDemo
    {
        public void WriteLog()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "//Log";
            var fileUrl = Path.Combine(path, $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileInfo fileInfo = new FileInfo(fileUrl);
            var fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var info = Encoding.UTF8.GetBytes($"当前时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush(true);
            fileStream.Close();
        }


        /*
         FileStream 类主要用于文件的读写，不仅能读写普通的文本文件，还可以读取图像文件、声音文件等不同格式的文件。
         FileStream 类操作的是字节和字节数组，而 StreamReader 或 StreamWriter 操作的是字符数据。
         字符数据易于使用， 但是有些操作，比如随机文件访问(访问文件中间某点的数据)，就必须由FileStream对象执行
         StreamReader 或 StreamWriter 通过使用特定编码在字符与字节之间进行转换，提供了高效的流读写功能，可以直接用字符串进行读写，而不用转换成字节数组。
         默认情况下，StreamReader 和 StreamWriter 类都使用 UTF-8编码。UTF-8编码正确处理 Unicode 字符并确保操作系统的本地化版本之间保持一致。
    
         
         */
    }
}

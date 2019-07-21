using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.FileHandle
{
    /// <summary>
    /// DirectoryInfo 类能创建该类的实例，通过类的实例访问类成员。
    /// </summary>
    public class DirectoryInfoDemo
    {
        public void CreateDirectory()
        {
            var path = "D://Demo";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            directoryInfo.Create();
            directoryInfo.CreateSubdirectory("test");
            var subDirectorys=directoryInfo.GetDirectories();
            foreach (var item in subDirectorys)
            {
                item.Delete(true);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IPdfManage
    {
        string ReadPdf(string fileUrl);

        void GeneratePdf();
    }
}

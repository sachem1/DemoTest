using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.FileHandle;

namespace WindowsFormsApp
{
    public partial class winForm : Form
    {
        public winForm()
        {
            InitializeComponent();
        }

        private void winForm_Load(object sender, EventArgs e)
        {
            BuildButton();

            try
            {
                //DirectoryInfoDemo directory = new DirectoryInfoDemo();
                //directory.CreateDirectory();

                //FileInfoDemo fileInfoDemo=new FileInfoDemo();
                //fileInfoDemo.WriteLog();

                WriteLogService writeLogService = new WriteLogService();
                writeLogService.AppendLogFile();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBaidu_Click(object sender, EventArgs e)
        {
            var html = GetBaiduHtml().Result;
            Console.WriteLine($"baidu--->{html}");
        }

        private async Task<string> GetBaiduHtml()
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync("http://baidu.com");
        }

        private void BuildButton()
        {
            Button button = new Button();
            button.Location = new System.Drawing.Point(this.btnBaidu.Location.X + 30, this.btnBaidu.Location.Y + 50);
            button.Name = "btn_test";
            button.Size = new System.Drawing.Size(80, 50);
            button.TabIndex = 2;
            button.Text = @"测试";
            button.UseVisualStyleBackColor = true;
            button.Click += async (o, e) =>
            {
                var html = await GetBaiduHtml();
                Console.WriteLine($@"baidu--->taskId:{Task.CurrentId},{html}");
            };
            this.Controls.Add(button);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            var url = "http://localhost:14873/home/GrabBill?requestId=";
            Parallel.For(0, 4, i => { Spide(url, i); });
        }

        private static void Spide(string url, int i)
        {
            HttpWebRequest client = WebRequest.CreateHttp(url + i);
            client.Method = "GET";
            using (WebResponse webResponse = client.GetResponse())
            {
                using (var stream = webResponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        var msg = reader.ReadToEnd();
                        Console.WriteLine($"接受到消息:{msg}");
                    }
                }
            }
            Thread.Sleep(100);
        }


        private void WaitTask()
        {
            var t = new TaskCompletionSource<bool>();


            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                }));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("任务完成!");

            //Console.WriteLine("任务失败!");

        }

        private void btnInstallService_Click(object sender, EventArgs e)
        {
            string url = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319";
        }

        private void btn_StopTask_Click(object sender, EventArgs e)
        {

        }

        private void btn_StartTask_Click(object sender, EventArgs e)
        {

        }

        private void btn_asyncTask_Click(object sender, EventArgs e)
        {
            WaitTask();
        }
    }
}

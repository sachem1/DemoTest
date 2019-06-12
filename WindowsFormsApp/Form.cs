﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            button.Text = "测试";
            button.UseVisualStyleBackColor = true;
            button.Click += async (o, e) =>
            {
                var html = await GetBaiduHtml();
                Console.WriteLine($"baidu--->taskId:{Task.CurrentId},{html}");
            };
            this.Controls.Add(button);
        }
    }
}

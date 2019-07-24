namespace WindowsFormsApp
{
    partial class winForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBaidu = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btn_StartTask = new System.Windows.Forms.Button();
            this.btn_StopTask = new System.Windows.Forms.Button();
            this.btnInstallService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBaidu
            // 
            this.btnBaidu.Location = new System.Drawing.Point(70, 49);
            this.btnBaidu.Name = "btnBaidu";
            this.btnBaidu.Size = new System.Drawing.Size(75, 23);
            this.btnBaidu.TabIndex = 0;
            this.btnBaidu.Text = "获取百度HTML";
            this.btnBaidu.UseVisualStyleBackColor = true;
            this.btnBaidu.Click += new System.EventHandler(this.btnBaidu_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(240, 49);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "批量请求";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btn_StartTask
            // 
            this.btn_StartTask.Location = new System.Drawing.Point(70, 399);
            this.btn_StartTask.Name = "btn_StartTask";
            this.btn_StartTask.Size = new System.Drawing.Size(75, 23);
            this.btn_StartTask.TabIndex = 0;
            this.btn_StartTask.Text = "开启任务";
            this.btn_StartTask.UseVisualStyleBackColor = true;
            this.btn_StartTask.Click += new System.EventHandler(this.btn_StartTask_Click);
            // 
            // btn_StopTask
            // 
            this.btn_StopTask.Location = new System.Drawing.Point(167, 399);
            this.btn_StopTask.Name = "btn_StopTask";
            this.btn_StopTask.Size = new System.Drawing.Size(75, 23);
            this.btn_StopTask.TabIndex = 0;
            this.btn_StopTask.Text = "停止任务";
            this.btn_StopTask.UseVisualStyleBackColor = true;
            this.btn_StopTask.Click += new System.EventHandler(this.btn_StopTask_Click);
            // 
            // btnInstallService
            // 
            this.btnInstallService.Location = new System.Drawing.Point(70, 359);
            this.btnInstallService.Name = "btnInstallService";
            this.btnInstallService.Size = new System.Drawing.Size(75, 23);
            this.btnInstallService.TabIndex = 0;
            this.btnInstallService.Text = "安装服务";
            this.btnInstallService.UseVisualStyleBackColor = true;
            this.btnInstallService.Click += new System.EventHandler(this.btnInstallService_Click);
            // 
            // winForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btn_StopTask);
            this.Controls.Add(this.btnInstallService);
            this.Controls.Add(this.btn_StartTask);
            this.Controls.Add(this.btnBaidu);
            this.Name = "winForm";
            this.Text = "Form";
            this.Load += new System.EventHandler(this.winForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBaidu;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btn_StartTask;
        private System.Windows.Forms.Button btn_StopTask;
        private System.Windows.Forms.Button btnInstallService;
    }
}


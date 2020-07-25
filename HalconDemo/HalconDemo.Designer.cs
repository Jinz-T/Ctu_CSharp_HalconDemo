namespace HalconDemo
{
    partial class HalconDemo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalconDemo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_GetOnceImage = new System.Windows.Forms.ToolStripSplitButton();
            this.Action_CameraSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboBox_CameraList = new System.Windows.Forms.ToolStripComboBox();
            this.Action_ColorType = new System.Windows.Forms.ToolStripComboBox();
            this.Action_ConnectCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_ThreadGetImage = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_DrawROI = new System.Windows.Forms.ToolStripSplitButton();
            this.Action_ClearROI = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_CreateModel = new System.Windows.Forms.ToolStripSplitButton();
            this.模板编号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_Model1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_Model2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_Model3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Action_ClearModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Action_RunModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Action_Calib = new System.Windows.Forms.ToolStripButton();
            this.Action_Exit = new System.Windows.Forms.ToolStripButton();
            this.PixelLabel = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Lab_ShowMes = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hv_Window = new HalconDotNet.HWindowControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_CalibMes = new System.Windows.Forms.Label();
            this.Btn_CheckCalib = new System.Windows.Forms.Button();
            this.LineEdit_CheckY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LineEdit_CheckX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_SaveCalib = new System.Windows.Forms.Button();
            this.Calib_dataView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Calib_dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_GetOnceImage,
            this.Action_DrawROI,
            this.Btn_CreateModel,
            this.toolStripSeparator1,
            this.Action_Calib,
            this.Action_Exit,
            this.PixelLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Btn_GetOnceImage
            // 
            this.Btn_GetOnceImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_GetOnceImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Action_CameraSetting,
            this.Action_ThreadGetImage});
            this.Btn_GetOnceImage.Image = ((System.Drawing.Image)(resources.GetObject("Btn_GetOnceImage.Image")));
            this.Btn_GetOnceImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_GetOnceImage.Name = "Btn_GetOnceImage";
            this.Btn_GetOnceImage.Size = new System.Drawing.Size(32, 22);
            this.Btn_GetOnceImage.Text = "拍照";
            this.Btn_GetOnceImage.ButtonClick += new System.EventHandler(this.Btn_GetOnceImage_ButtonClick);
            // 
            // Action_CameraSetting
            // 
            this.Action_CameraSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboBox_CameraList,
            this.Action_ColorType,
            this.Action_ConnectCamera});
            this.Action_CameraSetting.Image = ((System.Drawing.Image)(resources.GetObject("Action_CameraSetting.Image")));
            this.Action_CameraSetting.Name = "Action_CameraSetting";
            this.Action_CameraSetting.Size = new System.Drawing.Size(124, 22);
            this.Action_CameraSetting.Text = "相机设置";
            // 
            // ComboBox_CameraList
            // 
            this.ComboBox_CameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CameraList.Name = "ComboBox_CameraList";
            this.ComboBox_CameraList.Size = new System.Drawing.Size(121, 25);
            // 
            // Action_ColorType
            // 
            this.Action_ColorType.AutoSize = false;
            this.Action_ColorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Action_ColorType.Items.AddRange(new object[] {
            "gray",
            "rgb"});
            this.Action_ColorType.Name = "Action_ColorType";
            this.Action_ColorType.Size = new System.Drawing.Size(121, 25);
            // 
            // Action_ConnectCamera
            // 
            this.Action_ConnectCamera.Image = ((System.Drawing.Image)(resources.GetObject("Action_ConnectCamera.Image")));
            this.Action_ConnectCamera.Name = "Action_ConnectCamera";
            this.Action_ConnectCamera.Size = new System.Drawing.Size(181, 22);
            this.Action_ConnectCamera.Text = "连接";
            this.Action_ConnectCamera.Click += new System.EventHandler(this.Action_ConnectCamera_Click);
            // 
            // Action_ThreadGetImage
            // 
            this.Action_ThreadGetImage.Image = ((System.Drawing.Image)(resources.GetObject("Action_ThreadGetImage.Image")));
            this.Action_ThreadGetImage.Name = "Action_ThreadGetImage";
            this.Action_ThreadGetImage.Size = new System.Drawing.Size(124, 22);
            this.Action_ThreadGetImage.Text = "开始预览";
            this.Action_ThreadGetImage.Click += new System.EventHandler(this.Action_ThreadGetImage_Click);
            // 
            // Action_DrawROI
            // 
            this.Action_DrawROI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Action_DrawROI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Action_ClearROI});
            this.Action_DrawROI.Image = ((System.Drawing.Image)(resources.GetObject("Action_DrawROI.Image")));
            this.Action_DrawROI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Action_DrawROI.Name = "Action_DrawROI";
            this.Action_DrawROI.Size = new System.Drawing.Size(32, 22);
            this.Action_DrawROI.Text = "绘制ROI";
            this.Action_DrawROI.ButtonClick += new System.EventHandler(this.Action_DrawROI_ButtonClick);
            // 
            // Action_ClearROI
            // 
            this.Action_ClearROI.Image = ((System.Drawing.Image)(resources.GetObject("Action_ClearROI.Image")));
            this.Action_ClearROI.Name = "Action_ClearROI";
            this.Action_ClearROI.Size = new System.Drawing.Size(122, 22);
            this.Action_ClearROI.Text = "清除ROI";
            this.Action_ClearROI.Click += new System.EventHandler(this.Action_ClearROI_Click);
            // 
            // Btn_CreateModel
            // 
            this.Btn_CreateModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_CreateModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模板编号ToolStripMenuItem,
            this.Action_ClearModel,
            this.toolStripMenuItem1,
            this.Action_RunModel});
            this.Btn_CreateModel.Image = ((System.Drawing.Image)(resources.GetObject("Btn_CreateModel.Image")));
            this.Btn_CreateModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_CreateModel.Name = "Btn_CreateModel";
            this.Btn_CreateModel.Size = new System.Drawing.Size(32, 22);
            this.Btn_CreateModel.Text = "创建模板";
            this.Btn_CreateModel.ButtonClick += new System.EventHandler(this.Btn_CreateModel_ButtonClick);
            // 
            // 模板编号ToolStripMenuItem
            // 
            this.模板编号ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Action_Model1,
            this.Action_Model2,
            this.Action_Model3});
            this.模板编号ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("模板编号ToolStripMenuItem.Image")));
            this.模板编号ToolStripMenuItem.Name = "模板编号ToolStripMenuItem";
            this.模板编号ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.模板编号ToolStripMenuItem.Text = "模板编号";
            // 
            // Action_Model1
            // 
            this.Action_Model1.Checked = true;
            this.Action_Model1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Action_Model1.Name = "Action_Model1";
            this.Action_Model1.Size = new System.Drawing.Size(107, 22);
            this.Action_Model1.Text = "模板1";
            this.Action_Model1.Click += new System.EventHandler(this.Action_Model_Click);
            // 
            // Action_Model2
            // 
            this.Action_Model2.Name = "Action_Model2";
            this.Action_Model2.Size = new System.Drawing.Size(107, 22);
            this.Action_Model2.Text = "模板2";
            this.Action_Model2.Click += new System.EventHandler(this.Action_Model_Click);
            // 
            // Action_Model3
            // 
            this.Action_Model3.Name = "Action_Model3";
            this.Action_Model3.Size = new System.Drawing.Size(107, 22);
            this.Action_Model3.Text = "模板3";
            this.Action_Model3.Click += new System.EventHandler(this.Action_Model_Click);
            // 
            // Action_ClearModel
            // 
            this.Action_ClearModel.Image = ((System.Drawing.Image)(resources.GetObject("Action_ClearModel.Image")));
            this.Action_ClearModel.Name = "Action_ClearModel";
            this.Action_ClearModel.Size = new System.Drawing.Size(124, 22);
            this.Action_ClearModel.Text = "清除模板";
            this.Action_ClearModel.Click += new System.EventHandler(this.Action_ClearModel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // Action_RunModel
            // 
            this.Action_RunModel.Image = ((System.Drawing.Image)(resources.GetObject("Action_RunModel.Image")));
            this.Action_RunModel.Name = "Action_RunModel";
            this.Action_RunModel.Size = new System.Drawing.Size(124, 22);
            this.Action_RunModel.Text = "执行";
            this.Action_RunModel.Click += new System.EventHandler(this.Action_RunModel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Action_Calib
            // 
            this.Action_Calib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Action_Calib.Image = ((System.Drawing.Image)(resources.GetObject("Action_Calib.Image")));
            this.Action_Calib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Action_Calib.Name = "Action_Calib";
            this.Action_Calib.Size = new System.Drawing.Size(23, 22);
            this.Action_Calib.Text = "toolStripButton1";
            this.Action_Calib.Click += new System.EventHandler(this.Action_Calib_Click);
            // 
            // Action_Exit
            // 
            this.Action_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Action_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Action_Exit.Image = ((System.Drawing.Image)(resources.GetObject("Action_Exit.Image")));
            this.Action_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Action_Exit.Name = "Action_Exit";
            this.Action_Exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Action_Exit.Size = new System.Drawing.Size(23, 22);
            this.Action_Exit.Text = "退出";
            this.Action_Exit.Click += new System.EventHandler(this.Action_Exit_Click);
            // 
            // PixelLabel
            // 
            this.PixelLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PixelLabel.Name = "PixelLabel";
            this.PixelLabel.Size = new System.Drawing.Size(77, 22);
            this.PixelLabel.Text = "[-1,-1]->[-1]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lab_ShowMes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Lab_ShowMes
            // 
            this.Lab_ShowMes.Name = "Lab_ShowMes";
            this.Lab_ShowMes.Size = new System.Drawing.Size(35, 17);
            this.Lab_ShowMes.Text = "mes:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.hv_Window);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 430);
            this.panel2.TabIndex = 4;
            // 
            // hv_Window
            // 
            this.hv_Window.BackColor = System.Drawing.Color.Black;
            this.hv_Window.BorderColor = System.Drawing.Color.Black;
            this.hv_Window.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hv_Window.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hv_Window.Location = new System.Drawing.Point(0, 0);
            this.hv_Window.Name = "hv_Window";
            this.hv_Window.Size = new System.Drawing.Size(335, 430);
            this.hv_Window.TabIndex = 5;
            this.hv_Window.WindowSize = new System.Drawing.Size(335, 430);
            this.hv_Window.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hv_Window_HMouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.Lab_CalibMes);
            this.panel3.Controls.Add(this.Btn_CheckCalib);
            this.panel3.Controls.Add(this.LineEdit_CheckY);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.LineEdit_CheckX);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Btn_SaveCalib);
            this.panel3.Controls.Add(this.Calib_dataView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(335, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 430);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // Lab_CalibMes
            // 
            this.Lab_CalibMes.AutoSize = true;
            this.Lab_CalibMes.Location = new System.Drawing.Point(19, 396);
            this.Lab_CalibMes.Name = "Lab_CalibMes";
            this.Lab_CalibMes.Size = new System.Drawing.Size(35, 12);
            this.Lab_CalibMes.TabIndex = 13;
            this.Lab_CalibMes.Text = "-1,-1";
            // 
            // Btn_CheckCalib
            // 
            this.Btn_CheckCalib.Location = new System.Drawing.Point(261, 362);
            this.Btn_CheckCalib.Name = "Btn_CheckCalib";
            this.Btn_CheckCalib.Size = new System.Drawing.Size(57, 23);
            this.Btn_CheckCalib.TabIndex = 12;
            this.Btn_CheckCalib.Text = "转化";
            this.Btn_CheckCalib.UseVisualStyleBackColor = true;
            this.Btn_CheckCalib.Click += new System.EventHandler(this.Btn_CheckCalib_Click);
            // 
            // LineEdit_CheckY
            // 
            this.LineEdit_CheckY.Location = new System.Drawing.Point(237, 323);
            this.LineEdit_CheckY.Name = "LineEdit_CheckY";
            this.LineEdit_CheckY.Size = new System.Drawing.Size(78, 21);
            this.LineEdit_CheckY.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "像素值Y：";
            // 
            // LineEdit_CheckX
            // 
            this.LineEdit_CheckX.Location = new System.Drawing.Point(80, 323);
            this.LineEdit_CheckX.Name = "LineEdit_CheckX";
            this.LineEdit_CheckX.Size = new System.Drawing.Size(79, 21);
            this.LineEdit_CheckX.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "测试";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "像素值X：";
            // 
            // Btn_SaveCalib
            // 
            this.Btn_SaveCalib.Location = new System.Drawing.Point(243, 264);
            this.Btn_SaveCalib.Name = "Btn_SaveCalib";
            this.Btn_SaveCalib.Size = new System.Drawing.Size(75, 23);
            this.Btn_SaveCalib.TabIndex = 6;
            this.Btn_SaveCalib.Text = "保存";
            this.Btn_SaveCalib.UseVisualStyleBackColor = true;
            this.Btn_SaveCalib.Click += new System.EventHandler(this.Btn_SaveCalib_Click);
            // 
            // Calib_dataView
            // 
            this.Calib_dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Calib_dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Calib_dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.Calib_dataView.Location = new System.Drawing.Point(3, 3);
            this.Calib_dataView.Name = "Calib_dataView";
            this.Calib_dataView.RowTemplate.Height = 23;
            this.Calib_dataView.Size = new System.Drawing.Size(335, 255);
            this.Calib_dataView.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Image_X";
            this.Column1.Name = "Column1";
            this.Column1.Width = 72;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Image_Y";
            this.Column2.Name = "Column2";
            this.Column2.Width = 72;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Robot_X";
            this.Column3.Name = "Column3";
            this.Column3.Width = 72;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Robot_Y";
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // HalconDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 477);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HalconDemo";
            this.Text = "机器人视觉系统";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Calib_dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton Btn_GetOnceImage;
        private System.Windows.Forms.ToolStripMenuItem Action_CameraSetting;
        private System.Windows.Forms.ToolStripComboBox ComboBox_CameraList;
        private System.Windows.Forms.ToolStripComboBox Action_ColorType;
        private System.Windows.Forms.ToolStripMenuItem Action_ConnectCamera;
        private System.Windows.Forms.ToolStripMenuItem Action_ThreadGetImage;
        private System.Windows.Forms.ToolStripSplitButton Action_DrawROI;
        private System.Windows.Forms.ToolStripMenuItem Action_ClearROI;
        private System.Windows.Forms.ToolStripSplitButton Btn_CreateModel;
        private System.Windows.Forms.ToolStripMenuItem 模板编号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Action_Model1;
        private System.Windows.Forms.ToolStripMenuItem Action_Model2;
        private System.Windows.Forms.ToolStripMenuItem Action_Model3;
        private System.Windows.Forms.ToolStripMenuItem Action_ClearModel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Action_RunModel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel Lab_ShowMes;
        private System.Windows.Forms.Panel panel2;
        private HalconDotNet.HWindowControl hv_Window;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox LineEdit_CheckX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_SaveCalib;
        private System.Windows.Forms.DataGridView Calib_dataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label Lab_CalibMes;
        private System.Windows.Forms.Button Btn_CheckCalib;
        private System.Windows.Forms.TextBox LineEdit_CheckY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton Action_Calib;
        private System.Windows.Forms.ToolStripButton Action_Exit;
        private System.Windows.Forms.ToolStripLabel PixelLabel;

    }
}


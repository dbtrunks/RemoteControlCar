namespace RRC_Forms
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.tb_log = new System.Windows.Forms.TextBox();
            this.pb_screen = new System.Windows.Forms.PictureBox();
            this.lb_log = new System.Windows.Forms.Label();
            this.btn_onOff = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_screen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(12, 279);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(440, 270);
            this.tb_log.TabIndex = 1;
            this.tb_log.TextChanged += new System.EventHandler(this.tb_log_TextChanged);
            // 
            // pb_screen
            // 
            this.pb_screen.Image = ((System.Drawing.Image)(resources.GetObject("pb_screen.Image")));
            this.pb_screen.Location = new System.Drawing.Point(74, 12);
            this.pb_screen.Name = "pb_screen";
            this.pb_screen.Size = new System.Drawing.Size(320, 240);
            this.pb_screen.TabIndex = 0;
            this.pb_screen.TabStop = false;
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Location = new System.Drawing.Point(12, 263);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(28, 13);
            this.lb_log.TabIndex = 2;
            this.lb_log.Text = "Log:";
            // 
            // btn_onOff
            // 
            this.btn_onOff.BackColor = System.Drawing.Color.Lime;
            this.btn_onOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_onOff.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_onOff.Location = new System.Drawing.Point(146, 16);
            this.btn_onOff.Name = "btn_onOff";
            this.btn_onOff.Size = new System.Drawing.Size(138, 36);
            this.btn_onOff.TabIndex = 3;
            this.btn_onOff.TabStop = false;
            this.btn_onOff.Text = "Połącz";
            this.btn_onOff.UseVisualStyleBackColor = false;
            this.btn_onOff.Click += new System.EventHandler(this.Btn_onOff_Click);
            // 
            // btn_up
            // 
            this.btn_up.Location = new System.Drawing.Point(198, 429);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(40, 40);
            this.btn_up.TabIndex = 4;
            this.btn_up.TabStop = false;
            this.btn_up.Text = "/\\";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.Btn_Click);
            this.btn_up.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Btn_Key);
            this.btn_up.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Btn_Key);
            this.btn_up.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Btn_Key);
            this.btn_up.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn_Key);
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(198, 475);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(40, 40);
            this.btn_down.TabIndex = 5;
            this.btn_down.TabStop = false;
            this.btn_down.Text = "\\/";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(244, 475);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(40, 40);
            this.btn_right.TabIndex = 6;
            this.btn_right.TabStop = false;
            this.btn_right.Text = ">";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(152, 475);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(40, 40);
            this.btn_left.TabIndex = 7;
            this.btn_left.TabStop = false;
            this.btn_left.Text = "<";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.Btn_Click);
            this.btn_left.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Btn_Key);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_up);
            this.panel1.Controls.Add(this.btn_onOff);
            this.panel1.Controls.Add(this.btn_left);
            this.panel1.Controls.Add(this.btn_down);
            this.panel1.Controls.Add(this.btn_right);
            this.panel1.Location = new System.Drawing.Point(468, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 537);
            this.panel1.TabIndex = 8;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_log);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.pb_screen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "RemoteControlCar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb_screen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_screen;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.Button btn_onOff;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_log;
    }
}


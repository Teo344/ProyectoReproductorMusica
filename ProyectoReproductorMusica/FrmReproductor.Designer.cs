﻿namespace ProyectoReproductorMusica
{
    partial class FrmReproductor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReproductor));
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.picFinish = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.picForward = new System.Windows.Forms.PictureBox();
            this.picPause = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picPlay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.Desktop;
            this.picCanvas.Location = new System.Drawing.Point(45, 22);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(885, 325);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // picFinish
            // 
            this.picFinish.BackColor = System.Drawing.Color.Transparent;
            this.picFinish.Image = ((System.Drawing.Image)(resources.GetObject("picFinish.Image")));
            this.picFinish.Location = new System.Drawing.Point(750, 448);
            this.picFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picFinish.Name = "picFinish";
            this.picFinish.Size = new System.Drawing.Size(70, 72);
            this.picFinish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFinish.TabIndex = 2;
            this.picFinish.TabStop = false;
            this.picFinish.Click += new System.EventHandler(this.picFinish_Click);
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(344, 448);
            this.picBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(75, 72);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 3;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // picForward
            // 
            this.picForward.BackColor = System.Drawing.Color.Transparent;
            this.picForward.Image = ((System.Drawing.Image)(resources.GetObject("picForward.Image")));
            this.picForward.Location = new System.Drawing.Point(645, 448);
            this.picForward.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picForward.Name = "picForward";
            this.picForward.Size = new System.Drawing.Size(84, 72);
            this.picForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picForward.TabIndex = 4;
            this.picForward.TabStop = false;
            this.picForward.Click += new System.EventHandler(this.picForward_Click);
            // 
            // picPause
            // 
            this.picPause.BackColor = System.Drawing.Color.Transparent;
            this.picPause.Image = ((System.Drawing.Image)(resources.GetObject("picPause.Image")));
            this.picPause.Location = new System.Drawing.Point(541, 448);
            this.picPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPause.Name = "picPause";
            this.picPause.Size = new System.Drawing.Size(79, 72);
            this.picPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPause.TabIndex = 5;
            this.picPause.TabStop = false;
            this.picPause.Click += new System.EventHandler(this.picPause_Click);
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Image = ((System.Drawing.Image)(resources.GetObject("picHome.Image")));
            this.picHome.Location = new System.Drawing.Point(251, 448);
            this.picHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(75, 72);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 6;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // picPlay
            // 
            this.picPlay.BackColor = System.Drawing.Color.Transparent;
            this.picPlay.Image = ((System.Drawing.Image)(resources.GetObject("picPlay.Image")));
            this.picPlay.Location = new System.Drawing.Point(443, 448);
            this.picPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPlay.Name = "picPlay";
            this.picPlay.Size = new System.Drawing.Size(75, 72);
            this.picPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlay.TabIndex = 7;
            this.picPlay.TabStop = false;
            this.picPlay.Click += new System.EventHandler(this.picPlay_Click);
            // 
            // FrmReproductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(962, 531);
            this.Controls.Add(this.picPlay);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.picPause);
            this.Controls.Add(this.picForward);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.picFinish);
            this.Controls.Add(this.picCanvas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReproductor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReproductor";
            this.Load += new System.EventHandler(this.FrmReproductor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.PictureBox picFinish;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox picForward;
        private System.Windows.Forms.PictureBox picPause;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.PictureBox picPlay;
    }
}
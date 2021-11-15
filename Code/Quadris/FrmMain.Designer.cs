
namespace Quadris {
  partial class FrmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panBoard = new System.Windows.Forms.Panel();
            this.tmrFps = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNextPiece = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Paused = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panBoard
            // 
            this.panBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panBoard.Location = new System.Drawing.Point(210, 111);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(292, 355);
            this.panBoard.TabIndex = 1;
            // 
            // tmrFps
            // 
            this.tmrFps.Enabled = true;
            this.tmrFps.Interval = 500;
            this.tmrFps.Tick += new System.EventHandler(this.tmrFps_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(36, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 86);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblNextPiece
            // 
            this.lblNextPiece.AutoSize = true;
            this.lblNextPiece.BackColor = System.Drawing.Color.Transparent;
            this.lblNextPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPiece.ForeColor = System.Drawing.Color.White;
            this.lblNextPiece.Location = new System.Drawing.Point(29, 26);
            this.lblNextPiece.Name = "lblNextPiece";
            this.lblNextPiece.Size = new System.Drawing.Size(118, 24);
            this.lblNextPiece.TabIndex = 3;
            this.lblNextPiece.Text = "Next Piece:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(621, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hold";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(625, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 86);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(252, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lines Cleared: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(399, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "0";
            // 
            // Paused
            // 
            this.Paused.AutoSize = true;
            this.Paused.BackColor = System.Drawing.Color.Black;
            this.Paused.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Paused.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Paused.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paused.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Paused.Location = new System.Drawing.Point(-114, 257);
            this.Paused.Name = "Paused";
            this.Paused.Padding = new System.Windows.Forms.Padding(350, 10, 350, 10);
            this.Paused.Size = new System.Drawing.Size(998, 95);
            this.Paused.TabIndex = 8;
            this.Paused.Text = "PAUSED";
            this.Paused.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Paused.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Quadris.Properties.Resources.Game_Tetris_Backgrounds;
            this.ClientSize = new System.Drawing.Size(770, 609);
            this.Controls.Add(this.Paused);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNextPiece);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panBoard);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FrmMain";
            this.Text = "Quadris!";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel panBoard;
    private System.Windows.Forms.Timer tmrFps;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lblNextPiece;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Paused;
    }
}


namespace FighterJetCam
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.willian = new System.Windows.Forms.PictureBox();
            this.ship = new System.Windows.Forms.PictureBox();
            this.alien = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.willian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Khmer M2", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(213, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 104);
            this.label2.TabIndex = 6;
            this.label2.Text = "     ​​​​​​    លេងដូចអាចម៍!\r\nទុកឲកាសម្ដងទៀតEnter​មក";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Khmer M2", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(252, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 104);
            this.label3.TabIndex = 8;
            this.label3.Text = "     ​​​​​​  អស្ចារ្យណាស់ប្រូ!!\r\n         កាក BOSS";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::FighterJetCam.Properties.Resources.player_img;
            this.player.Location = new System.Drawing.Point(357, 558);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(46, 45);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::FighterJetCam.Properties.Resources.Aliendie;
            this.pictureBox3.Location = new System.Drawing.Point(357, 120);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(131, 125);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // willian
            // 
            this.willian.BackColor = System.Drawing.Color.Transparent;
            this.willian.Image = global::FighterJetCam.Properties.Resources.willain;
            this.willian.Location = new System.Drawing.Point(313, 42);
            this.willian.Name = "willian";
            this.willian.Size = new System.Drawing.Size(161, 90);
            this.willian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.willian.TabIndex = 7;
            this.willian.TabStop = false;
            this.willian.Tag = "enemy";
            // 
            // ship
            // 
            this.ship.BackColor = System.Drawing.Color.Transparent;
            this.ship.Image = global::FighterJetCam.Properties.Resources.ship_gif;
            this.ship.Location = new System.Drawing.Point(561, 72);
            this.ship.Name = "ship";
            this.ship.Size = new System.Drawing.Size(50, 27);
            this.ship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ship.TabIndex = 2;
            this.ship.TabStop = false;
            this.ship.Tag = "enemy";
            // 
            // alien
            // 
            this.alien.BackColor = System.Drawing.Color.Transparent;
            this.alien.Image = global::FighterJetCam.Properties.Resources.alien_gif;
            this.alien.Location = new System.Drawing.Point(147, 193);
            this.alien.Name = "alien";
            this.alien.Size = new System.Drawing.Size(60, 60);
            this.alien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.alien.TabIndex = 1;
            this.alien.TabStop = false;
            this.alien.Tag = "enemy";
            this.alien.Click += new System.EventHandler(this.alien_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FighterJetCam.Properties.Resources.Stars_img;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 385);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "stars";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FighterJetCam.Properties.Resources.Stars_img;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 341);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(802, 342);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "stars";
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Khmer CN Phnom Sampao", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(26, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "score: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 715);
            this.Controls.Add(this.player);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.willian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ship);
            this.Controls.Add(this.alien);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Text = "ass";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.willian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox alien;
        private System.Windows.Forms.PictureBox ship;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox willian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
    }
}


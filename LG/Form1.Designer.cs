namespace LG
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.WorkField = new System.Windows.Forms.PictureBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.PauseButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
			this.SpeedTB = new System.Windows.Forms.MaskedTextBox();
			this.CounterPB = new System.Windows.Forms.PictureBox();
			this.countLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.WorkField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CounterPB)).BeginInit();
			this.SuspendLayout();
			// 
			// WorkField
			// 
			this.WorkField.BackColor = System.Drawing.SystemColors.Window;
			this.WorkField.Location = new System.Drawing.Point(12, 12);
			this.WorkField.Name = "WorkField";
			this.WorkField.Size = new System.Drawing.Size(600, 600);
			this.WorkField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.WorkField.TabIndex = 0;
			this.WorkField.TabStop = false;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(672, 12);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(181, 36);
			this.StartButton.TabIndex = 18;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PauseButton
			// 
			this.PauseButton.Location = new System.Drawing.Point(672, 79);
			this.PauseButton.Name = "PauseButton";
			this.PauseButton.Size = new System.Drawing.Size(181, 36);
			this.PauseButton.TabIndex = 19;
			this.PauseButton.Text = "Pause";
			this.PauseButton.UseVisualStyleBackColor = true;
			this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(618, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Enter =>";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(626, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Esc =>";
			// 
			// SpeedTrackBar
			// 
			this.SpeedTrackBar.Location = new System.Drawing.Point(621, 146);
			this.SpeedTrackBar.Maximum = 500;
			this.SpeedTrackBar.Minimum = 10;
			this.SpeedTrackBar.Name = "SpeedTrackBar";
			this.SpeedTrackBar.Size = new System.Drawing.Size(156, 45);
			this.SpeedTrackBar.TabIndex = 22;
			this.SpeedTrackBar.Value = 500;
			this.SpeedTrackBar.ValueChanged += new System.EventHandler(this.SpeedTrackBar_ValueChanged);
			this.SpeedTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpeedTrackBar_MouseDown);
			this.SpeedTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SpeedTrackBar_MouseUp);
			// 
			// SpeedTB
			// 
			this.SpeedTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SpeedTB.Location = new System.Drawing.Point(783, 155);
			this.SpeedTB.Mask = "0000";
			this.SpeedTB.Name = "SpeedTB";
			this.SpeedTB.Size = new System.Drawing.Size(70, 26);
			this.SpeedTB.TabIndex = 23;
			this.SpeedTB.Text = "200";
			this.SpeedTB.TextChanged += new System.EventHandler(this.SpeedTB_TextChanged);
			// 
			// CounterPB
			// 
			this.CounterPB.BackColor = System.Drawing.Color.Gold;
			this.CounterPB.Location = new System.Drawing.Point(659, 231);
			this.CounterPB.Name = "CounterPB";
			this.CounterPB.Size = new System.Drawing.Size(35, 35);
			this.CounterPB.TabIndex = 24;
			this.CounterPB.TabStop = false;
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.countLabel.Location = new System.Drawing.Point(700, 246);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(88, 20);
			this.countLabel.TabIndex = 25;
			this.countLabel.Text = "0 съедено";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 618);
			this.Controls.Add(this.countLabel);
			this.Controls.Add(this.CounterPB);
			this.Controls.Add(this.SpeedTB);
			this.Controls.Add(this.SpeedTrackBar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PauseButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.WorkField);
			this.Name = "Form1";
			this.Text = "Zmeyka";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.WorkField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CounterPB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox WorkField;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button PauseButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar SpeedTrackBar;
		private System.Windows.Forms.MaskedTextBox SpeedTB;
		private System.Windows.Forms.PictureBox CounterPB;
		private System.Windows.Forms.Label countLabel;
	}
}


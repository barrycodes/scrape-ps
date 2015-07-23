namespace MainInterface
{
	partial class OptionsForm
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
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.durationPercentControl = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.delaySecondsControl = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.delayRandomSecondsControl = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.scheduleStartTimeControl = new System.Windows.Forms.DateTimePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.scheduleStopTimeControl = new System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.delayCloseWindowControl = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.durationPercentControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.delaySecondsControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.delayRandomSecondsControl)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.delayCloseWindowControl)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(464, 317);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(383, 317);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.delayRandomSecondsControl);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.delaySecondsControl);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.durationPercentControl);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(282, 185);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Delay before each recording";
			// 
			// durationPercentControl
			// 
			this.durationPercentControl.Location = new System.Drawing.Point(18, 29);
			this.durationPercentControl.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
			this.durationPercentControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.durationPercentControl.Name = "durationPercentControl";
			this.durationPercentControl.Size = new System.Drawing.Size(55, 20);
			this.durationPercentControl.TabIndex = 0;
			this.durationPercentControl.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(79, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(189, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "% of the duration of previous video clip";
			// 
			// delaySecondsControl
			// 
			this.delaySecondsControl.Location = new System.Drawing.Point(18, 88);
			this.delaySecondsControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.delaySecondsControl.Name = "delaySecondsControl";
			this.delaySecondsControl.Size = new System.Drawing.Size(66, 20);
			this.delaySecondsControl.TabIndex = 2;
			this.delaySecondsControl.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "PLUS";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(90, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "seconds";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(178, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "seconds";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 123);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "PLUS";
			// 
			// delayRandomSecondsControl
			// 
			this.delayRandomSecondsControl.Location = new System.Drawing.Point(123, 150);
			this.delayRandomSecondsControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.delayRandomSecondsControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.delayRandomSecondsControl.Name = "delayRandomSecondsControl";
			this.delayRandomSecondsControl.Size = new System.Drawing.Size(49, 20);
			this.delayRandomSecondsControl.TabIndex = 5;
			this.delayRandomSecondsControl.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Random delay up to";
			// 
			// scheduleStartTimeControl
			// 
			this.scheduleStartTimeControl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.scheduleStartTimeControl.Location = new System.Drawing.Point(89, 29);
			this.scheduleStartTimeControl.Name = "scheduleStartTimeControl";
			this.scheduleStartTimeControl.ShowUpDown = true;
			this.scheduleStartTimeControl.Size = new System.Drawing.Size(114, 20);
			this.scheduleStartTimeControl.TabIndex = 3;
			this.scheduleStartTimeControl.Value = new System.DateTime(2015, 7, 23, 7, 0, 0, 0);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.scheduleStopTimeControl);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.scheduleStartTimeControl);
			this.groupBox2.Location = new System.Drawing.Point(312, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(225, 185);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Schedule";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 31);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Daily start";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(20, 61);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Daily stop";
			// 
			// scheduleStopTimeControl
			// 
			this.scheduleStopTimeControl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.scheduleStopTimeControl.Location = new System.Drawing.Point(89, 55);
			this.scheduleStopTimeControl.Name = "scheduleStopTimeControl";
			this.scheduleStopTimeControl.ShowUpDown = true;
			this.scheduleStopTimeControl.Size = new System.Drawing.Size(114, 20);
			this.scheduleStopTimeControl.TabIndex = 7;
			this.scheduleStopTimeControl.Value = new System.DateTime(2015, 7, 23, 20, 0, 0, 0);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.delayCloseWindowControl);
			this.groupBox3.Location = new System.Drawing.Point(12, 215);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(525, 69);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Delay before closing Video Player window";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(87, 31);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "milliseconds";
			// 
			// delayCloseWindowControl
			// 
			this.delayCloseWindowControl.Location = new System.Drawing.Point(15, 29);
			this.delayCloseWindowControl.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.delayCloseWindowControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.delayCloseWindowControl.Name = "delayCloseWindowControl";
			this.delayCloseWindowControl.Size = new System.Drawing.Size(66, 20);
			this.delayCloseWindowControl.TabIndex = 5;
			this.delayCloseWindowControl.Value = new decimal(new int[] {
            3300,
            0,
            0,
            0});
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(551, 352);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.durationPercentControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.delaySecondsControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.delayRandomSecondsControl)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.delayCloseWindowControl)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown delayRandomSecondsControl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown delaySecondsControl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown durationPercentControl;
		private System.Windows.Forms.DateTimePicker scheduleStartTimeControl;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker scheduleStopTimeControl;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown delayCloseWindowControl;
	}
}
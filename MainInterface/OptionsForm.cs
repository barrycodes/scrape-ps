using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainInterface
{
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		public MainForm.MySettings Settings
		{
			get
			{
				return new MainForm.MySettings {
					DelayPercent = (int)durationPercentControl.Value,
					DelaySeconds = (int)delaySecondsControl.Value,
					DelayRandomSeconds = (int)delayRandomSecondsControl.Value,
					DelayCloseWindowMilliseconds = (int)delayCloseWindowControl.Value,
					ScheduleStartTime = scheduleStartTimeControl.Value,
					ScheduleStopTime = scheduleStopTimeControl.Value,
				};
			}
			set
			{
				durationPercentControl.Value = value.DelayPercent;
				delaySecondsControl.Value = value.DelaySeconds;
				delayRandomSecondsControl.Value = value.DelayRandomSeconds;
				delayCloseWindowControl.Value = value.DelayCloseWindowMilliseconds;
				scheduleStartTimeControl.Value = value.ScheduleStartTime;
				scheduleStopTimeControl.Value = value.ScheduleStopTime;
			}
		}
	}
}

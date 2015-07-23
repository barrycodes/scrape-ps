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
	public partial class WebBrowserForm : Form
	{
		public WebBrowserForm()
		{
			InitializeComponent();
		}

		private void goButton_Click(object sender, EventArgs e)
		{
			webBrowser1.Url = new Uri(uriTextBox.Text);
		}
	}
}

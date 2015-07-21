using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using mshtml;

namespace MainInterface
{
    public partial class MainForm : Form
    {
		[Serializable]
		private class MySettings
		{
		}

		private FileVersionInfo assemblyInfo;

		private bool intentionalClose;

		private MySettings settings;
		
        public MainForm()
        {
            InitializeComponent();

			intentionalClose = false;

			assemblyInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			LoadSettings();
        }

		private void LoadSettings()
		{
			settings = (MySettings)CommonTypes.SettingsManager.LoadSettings(assemblyInfo.CompanyName, assemblyInfo.ProductName) ?? new MySettings();
		}

		private void StoreSettings()
		{
			CommonTypes.SettingsManager.StoreSettings(assemblyInfo.CompanyName, assemblyInfo.ProductName, settings);
		}


		private void HideMe()
		{
			Hide();
			WindowState = FormWindowState.Minimized;
		}

		private void ShowMe()
		{
			WindowState = FormWindowState.Normal;
			Show();
			Activate();
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (!intentionalClose)
			{
				bool cancel = false;

				switch (e.CloseReason)
				{
					case CloseReason.UserClosing: cancel = true; break;
					default: cancel = false; break;
				}
				if (cancel)
				{
					e.Cancel = true;
					HideMe();
				}
			}
        }

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowMe();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			intentionalClose = true;
			Close();
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			ShowMe();
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == Platform.PlatformApi.WM_SHOWME)
				ShowMe();
			base.WndProc(ref m);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (AboutBox1 form = new AboutBox1())
				form.ShowDialog();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			StoreSettings();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			webBrowser1.Url = new Uri(@"http://www.pluralsight.com");
		}

		private void InjectScript(string scriptName, string scriptContents, bool runScript = false)
		{
			var scriptElement = webBrowser1.Document.CreateElement("script");
			((IHTMLScriptElement)scriptElement.DomElement).text = "function " + scriptName + "() { " + scriptContents + "}";
			webBrowser1.Document.GetElementsByTagName("head")[0].AppendChild(scriptElement);
			if (runScript)
				webBrowser1.Document.InvokeScript(scriptName);
		}
		private int mode = -1;

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mode = 1;
			timer1.Start();
			webBrowser1.Url = new Uri(@"http://www.pluralsight.com/courses/developing-extensible-software");
		}

		private const string Script1 = @"

				$(document).ready(function () {
					setTimeout(function () {
						
						alert('arr!');
						var moduleContainer = $('#table-of-contents > div.row > div.small-12 > div.section-container');

						alert(moduleContainer.length);

						var expandAll = function () {
							var modules = moduleContainer.children('div.section');
							alert(modules.length);
							modules.each(function () {
								$(this).click();
							});
						};

						expandAll();

					}, 5000);
				});
				
				//var fnGet

			";

string scr1 = @"$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > p.title > a.ng-binding').click();";
string scr2 = @"$('#table-of-contents > div > div > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > a > h5').click();";
string scr3 = @"alert($('#table-of-contents > div > div > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > a[ng-click] > h5.ng-binding').text());";
string scr4 = @"alert($('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > div.action-icon-list > span.toc-time').text());";
string scr5 = @"$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > p.title > a.ng-binding').click();";


		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (mode >= 0)
			{
				switch (mode)
				{
					case 1: InjectScript("someName0", Script1, true); break;
				}
				if (++mode > 100)
					mode = 0;
			}
		}
    }
}
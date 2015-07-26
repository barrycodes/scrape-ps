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
using System.IO;

namespace MainInterface
{
    public partial class MainForm : Form
    {
		[Serializable]
		public class MySettings
		{
			public int DelayPercent { get; set; }
			public int DelaySeconds { get; set; }
			public int DelayRandomSeconds { get; set; }
			public int DelayCloseWindowMilliseconds { get; set; }
			public DateTime ScheduleStartTime { get; set; }
			public DateTime ScheduleStopTime { get; set; }
			public static MySettings Default
			{
				get
				{
					return new MySettings
					{
						DelayPercent = 100,
						DelaySeconds = 5,
						DelayRandomSeconds = 60,
						DelayCloseWindowMilliseconds = 3300,
						ScheduleStartTime = DateTime.Now.Date + TimeSpan.FromHours(7),
						ScheduleStopTime = DateTime.Now.Date + TimeSpan.FromHours(20),
					};
				}
			}
		}

		private FileVersionInfo assemblyInfo;

		private bool intentionalClose;

		private MySettings settings;

		private Random random;

        public MainForm()
        {
            InitializeComponent();

			intentionalClose = false;
			random = new Random();

			assemblyInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			LoadSettings();

			timer2.Interval = settings.DelayCloseWindowMilliseconds;
        }

		private void LoadSettings()
		{
			settings =
				(MySettings)CommonTypes.SettingsManager.LoadSettings(assemblyInfo.CompanyName, assemblyInfo.ProductName)
					?? MySettings.Default;
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

		private class WishlistItem
		{
			public string Url { get; set; }
			public int StartIndex { get; set; }
			public WishlistItem(string url, int startIndex = 0)
			{
				Url = url;
				StartIndex = startIndex;
			}
		}

		private Queue<WishlistItem> wishlist;
		private WishlistItem currentWishItem;

		private WishlistItem[] LoadWishlist()
		{
			List<WishlistItem> results = new List<WishlistItem>();
			using (FileStream readFile = new FileStream("wishlist.txt", FileMode.Open, FileAccess.Read))
			{
				using (StreamReader reader = new StreamReader(readFile))
				{
					string textline = reader.ReadLine();
					while (textline != null)
					{
						if (textline.Length > 0 && !textline.StartsWith(";"))
						{
							string[] parts = textline.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
							int startIndex = 0;
							if (parts.Length >= 2)
								startIndex = int.Parse(parts[1]);

							results.Add(new WishlistItem(parts[0], startIndex));
						}
						textline = reader.ReadLine();
					}
				}
			}
			return results.ToArray();
		}

		private void NextWishlistItem()
		{
			if (wishlist.Count >= 1)
			{
				currentWishItem = wishlist.Dequeue();

				allVideosIndex = currentWishItem.StartIndex;

				StartPage(currentWishItem.Url);
			}
			else
			{
				timer1.Stop();
			}
		}

		private void StopAll()
		{
			timer1.Stop();
			initialized = false;
		}

		private void StartAll()
		{
			wishlist = new Queue<WishlistItem>(LoadWishlist());

			NextWishlistItem();
		}

		private void StartPage(string url)
		{
			timer1.Stop();
			initialized = false;
			timer1.Interval = 5000;
			timer1.Start();
			webBrowser1.Url = new Uri(url);
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StartAll();
			// StartPage(@"http://www.pluralsight.com/courses/developing-extensible-software");
		}

//        private const string Script1 = @"
//
//				$(document).ready(function () {
//					setTimeout(function () {
//						
//						//alert('arr!');
//						var moduleContainer = $('#table-of-contents > div.row > div.small-12 > div.section-container');
//
//						//alert(moduleContainer.length);
//
//						var expandAll = function () {
//							var modules = moduleContainer.children('div.section');
//							//alert(modules.length);
//							modules.each(function () {
//								$(this).click();
//							});
//						};
//
//						expandAll();
//
//					}, 5000);
//				});
//				
//				//var fnGet
//
//			";

//        private const string Script_All = @"
//
//		function ClickItem() {
//			var clipIndex = arguments[0];
//			$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section > div.content > ul > li > a').eq(clipIndex).click();
//		}
//		
//		function GetAllTimes() {
//			var results = [];
//			var allItems = $('#table-of-contents > div.row > div.small-12 > div.section-container > div.section > div.content > ul > li > div.action-icon-list > span.toc-time');
//			allItems.each(function () {
//				var timeText = $(this).text();
//				var splits = timeText.split(':');
//				var seconds = (+splits[0]) * 60 + (+splits[1]);
//				results.push(seconds);
//			});
//			return JSON.stringify(results);
//		}
//
//		";

//string scr1 = @"$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > p.title > a.ng-binding').click();";
//string scr2 = @"$('#table-of-contents > div > div > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > a > h5').click();";
//string scr3 = @"alert($('#table-of-contents > div > div > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > a[ng-click] > h5.ng-binding').text());";
//string scr4 = @"alert($('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > div.content:nth-child(3) > ul > li > div.action-icon-list > span.toc-time').text());";
//string scr5 = @"$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > p.title > a.ng-binding').click();";


		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
		}

		private bool initialized;

		private void Initialize()
		{
			ScriptHelper.InjectScript(webBrowser1);
			allVideos = ScriptHelper.GetAllVideosInfo(webBrowser1);
			timer1.Interval = 2000;
		}

		private void NextStep()
		{
			if (allVideosIndex < allVideos.Length)
			{
				int delaySeconds = 0;

				ScriptHelper.VideoInfo info = allVideos[allVideosIndex];

				int clipDuration = info.DurationSeconds;
				delaySeconds += (int)((float)clipDuration * ((float)settings.DelayPercent / 100F));

				int randomSeconds = 1;
				if (settings.DelayRandomSeconds > 1)
					randomSeconds = random.Next(settings.DelayRandomSeconds);
				delaySeconds += randomSeconds;

				delaySeconds += settings.DelaySeconds;

				timer1.Interval = (int)TimeSpan.FromSeconds(delaySeconds).TotalMilliseconds;

				info.TriggerTime = DateTime.Now;
				ScriptHelper.ClickItem(webBrowser1, allVideosIndex);
				timer2.Start();

				++allVideosIndex;
			}
			else
			{
				timer1.Stop();
				ConcludeWishlistItem();
				NextWishlistItem();
			}
		}

		private void ConcludeWishlistItem()
		{
			try
			{
				DirectoryInfo recordingFolder =
					new DirectoryInfo(
						Path.Combine(
							Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
							"WMR Recordings"));

				var files = recordingFolder.GetFiles();

				foreach (var info in allVideos)
				{
					if (!string.IsNullOrWhiteSpace(info.Name) && info.TriggerTime != DateTime.MinValue)
					{
						try
						{
							var foundFile = files.First(f => Math.Abs((f.CreationTime - info.TriggerTime).Ticks) < TimeSpan.FromSeconds(7).Ticks);

							if (foundFile != null)
							{
								string path = foundFile.FullName;
								foundFile.MoveTo(info.Name + foundFile.Extension);
							}
						}
						catch { }
					}
				}
			}
			catch { }
		}

		private ScriptHelper.VideoInfo[] allVideos;
		private int allVideosIndex;

		private void timer1_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			if (now.TimeOfDay >= settings.ScheduleStartTime.TimeOfDay && now.TimeOfDay < settings.ScheduleStopTime.TimeOfDay)
			{
				if (!initialized)
				{
					Initialize();

					initialized = true;
				}
				else
				{
					NextStep();
				}
			}
		}

		private void ClosePlayer()
		{
			Platform.PlatformApi.WindowInfo[] windows = Platform.PlatformApi.GetAllWindowsInfo(false);
			foreach (Platform.PlatformApi.WindowInfo window in windows)
				if (window.Title.StartsWith("http://www.pluralsight") && window.Title.EndsWith("Internet Explorer"))
				{
					Platform.User32.PostMessage(window.Handle, Platform.PlatformApi.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
				}
		}

		private void closePlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClosePlayer();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			timer2.Stop();
			ClosePlayer();
		}

		private void newbrowserWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WebBrowserForm form = new WebBrowserForm();
			form.Show();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopAll();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OptionsForm form = new OptionsForm())
			{
				form.Settings = settings;
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					settings = form.Settings;
			}
		}
    }
}
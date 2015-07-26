using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace MainInterface
{
	public static class ScriptHelper
	{
		// main container
		// #table-of-contents > div.row > div > div.section-container
		//
		// module names
		// #table-of-contents > div.row > div > div.section-container > div.section > p.title > a
		//
		// video links
		// #table-of-contents > div.row > div > div.section-container > div.section > div.content > ul > li > a
		//
		// video names
		// #table-of-contents > div.row > div > div.section-container > div.section > div.content > ul > li > a > h5
		//
		// video times
		// #table-of-contents > div.row > div > div.section-container > div.section > div.content > ul > li > div > span.toc-time
		
		private const string script1 = @"

			function ClickItem() {
				var clipIndex = arguments[0];
				$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section > div.content > ul > li > a')
					.eq(clipIndex)
					.click();
			}

			function GetAllModuleNames() {
				var results = '';
				var allItems = $('#table-of-contents > div.row > div > div.section-container > div.section > p.title > a');
				allItems.each(function() {
					results += '\t' + $(this).text();
				});
				return results;
			}

			function GetAllVideoNames() {
				var results = '';
				var allItems = $('#table-of-contents > div.row > div > div.section-container > div.section > div.content > ul > li > a > h5');
				allItems.each(function() {
					results += '\t' + $(this).text();
				});
				return results;
			}

			function GetAllModuleCounts() {
				var results = [];
				var allModules = $('#table-of-contents > div.row > div > div.section-container > div.section');
				allModules.each(function() {
					var thisModule = $(this);
					var childVideos = thisModule.find('div.content > ul > li > a');
					results.push(childVideos.length);
				});
				return JSON.stringify(results);
			}

			function GetAllTimes() {
				var results = [];
				var allItems = $('#table-of-contents > div.row > div.small-12 > div.section-container > div.section > div.content > ul > li > div.action-icon-list > span.toc-time');
				allItems.each(function () {
					var timeText = $(this).text();
					var splits = timeText.split(':');
					var seconds = (+splits[0]) * 60 + (+splits[1]);
					results.push(seconds);
				});
				return JSON.stringify(results);
			}

			function GetTheCourseTitle() {
				return $('body > div[ng-controller] > div[ng-controller] > section.hero > div.row > div.small-12 > h1.course-title').text();
			}

			function GetTheAuthor() {
				return $('body > div[ng-controller] > div[ng-controller] > section.band > div.row > div > div.author-byline > span.value > span > a[ng-href]').text();
			}

			function GetTheDescription() {
				return $('body > div[ng-controller] > div[ng-controller] > section.hero > div.row > div.small-12 > p.hero-content').text();
			}

			function GetTheDate() {
				return $('body > div[ng-controller] > div[ng-controller] > section.band > div.row > div.columns > ul.line-list > li.icon > span.value').text();
			}
		";

		public static void InjectScript(WebBrowser wb)
		{
			var scriptElement = wb.Document.CreateElement("script");
			((IHTMLScriptElement)scriptElement.DomElement).text = script1;
			wb.Document.GetElementsByTagName("head")[0].AppendChild(scriptElement);
		}

		public static void ClickItem(WebBrowser wb, int index)
		{
			wb.Document.InvokeScript("ClickItem", new object[] { index });
		}

		private static string[] GetStrings(WebBrowser wb, string methodName)
		{
			string[] results = null;

			string json = (string)wb.Document.InvokeScript(methodName);
			results = json.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
			results = results.Select(s => s.Trim()).ToArray();
			return results;
		}

		private static int[] GetInts(WebBrowser wb, string methodName)
		{
			string json = (string)wb.Document.InvokeScript(methodName);
			string[] text = json.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
			int[] results = text.Select(s => int.Parse(s)).ToArray();
			return results;
		}

		private static string GetString(WebBrowser wb, string methodName)
		{
			return (string)wb.Document.InvokeScript(methodName);
		}

		private static string[] GetAllModuleNames(WebBrowser wb)
		{
			return GetStrings(wb, "GetAllModuleNames");
		}

		private static string[] GetAllVideoNames(WebBrowser wb)
		{
			return GetStrings(wb, "GetAllVideoNames");
		}

		private static int[] GetAllModuleCounts(WebBrowser wb)
		{
			return GetInts(wb, "GetAllModuleCounts");
		}

		public class CourseInfo
		{
			public VideoInfo[] Videos { get; set; }
			public string Title { get; set; }
			public string Author { get; set; }
			public string ReleaseDate { get; set; }
			public string ShortDescription { get; set; }
			public string LongDescription { get; set; }
		}

		public class VideoInfo
		{
			public int DurationSeconds { get; set; }
			public string Name { get; set; }
			public DateTime TriggerTime { get; set; }
		}

		private static string FixFilename(string name)
		{
			// < > " : / \ | ? *
			name =
				name.Replace("<", "-")
				.Replace(">", "-")
				.Replace("\"", "'")
				.Replace(":", " - ")
				.Replace("/", "-")
				.Replace("\\", "-")
				.Replace("|", "-")
				.Replace("?", "")
				.Replace("*", "");

			while (name.Contains("  "))
				name = name.Replace("  ", " ");

			return name;
		}

		public static CourseInfo GetCourseInfo(WebBrowser wb)
		{
			VideoInfo[] videos = GetAllVideosInfo(wb);
			return new CourseInfo
			{
				 Videos = videos,
				 Title = GetString(wb, "GetTheCourseTitle"),
				 Author = GetString(wb, "GetTheAuthor"),
				 ShortDescription = GetString(wb, "GetTheDescription"),
				 ReleaseDate = GetString(wb, "GetTheDate"),
			};
		}

		public static VideoInfo[] GetAllVideosInfo(WebBrowser wb)
		{
			VideoInfo[] results = null;

			int[] times = GetAllTimes(wb);
			string[] moduleNames = GetAllModuleNames(wb);
			string[] videoNames = GetAllVideoNames(wb);
			int[] moduleCounts = GetAllModuleCounts(wb);

			results = new VideoInfo[times.Length];

			int vIterator = 0;

			for (int i = 0; i < moduleCounts.Length; ++i)
			{
				int count = moduleCounts[i];
				string moduleName = moduleNames[i];
				for (int j = 0; j < count; ++j)
				{
					string resultName =
						string.Format(
							"{0:00}{1:00} - {2} - {3}",
							i+1,
							j+1,
							moduleNames,
							videoNames[vIterator]);

					// < > " : / \ | ? *
					resultName = FixFilename(resultName);

					results[vIterator] =
						new VideoInfo
						{
							Name = resultName,
							DurationSeconds = times[vIterator],
						};

					vIterator++;
				}
			}

			return results;
		}

		private static int[] GetAllTimes(WebBrowser wb)
		{
			return GetInts(wb, "GetAllTimes");
		}
	}
}
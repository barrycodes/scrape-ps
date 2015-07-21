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
		private const string script1 = @"

			function ClickItem() {
				var clipIndex = arguments[0];
				$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section > div.content > ul > li > a')
					.eq(clipIndex)
					.click();
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
		";

		public static void InjectScript(WebBrowser webBrowser1)
		{
			var scriptElement = webBrowser1.Document.CreateElement("script");
			((IHTMLScriptElement)scriptElement.DomElement).text = script1;
			webBrowser1.Document.GetElementsByTagName("head")[0].AppendChild(scriptElement);
		}

		public static void ClickItem(WebBrowser webBrowser1, int index)
		{
			webBrowser1.Document.InvokeScript("ClickItem", new object[] { index });
		}

		public static int[] GetAllTimes(WebBrowser webBrowser1)
		{
			string jsonTimes = (string)webBrowser1.Document.InvokeScript("GetAllTimes");
			string[] textTimes = jsonTimes.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
			int[] times = textTimes.Select(s => int.Parse(s)).ToArray();
			return times;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Utilities.Helpers
{
    public static class TimeHelper
    {
        public static string ToTimeAgo(DateTime dateTime)
        {
            var now = DateTime.Now;
            var timeSpan = now - dateTime;

            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes}m ago";

            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours}h ago";

            if (timeSpan.TotalDays < 30)
                return $"{(int)timeSpan.TotalDays}d ago";

            if (dateTime.Year == now.Year)
                return dateTime.ToString("MMM dd");

            return dateTime.ToString("MMM dd, yyyy");
        }
        public static int CalculateReadingTime(string content)
        {
            int WordsPerMinute = 200;

            if (string.IsNullOrWhiteSpace(content))
                return 0;

            
            var wordCount = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            
            var readingTime = (int)Math.Ceiling((double)wordCount / WordsPerMinute);

            return readingTime;
        }
    }
}

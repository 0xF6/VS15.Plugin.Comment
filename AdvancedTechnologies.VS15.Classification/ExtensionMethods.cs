using System;
using System.Collections.Generic;
using System.Linq;
namespace AdvancedTechnologies.CommentClassifier
{
	internal static class ExtensionMethods
	{
		public static List<T> AsList<T>(this IEnumerable<T> source)
		{
			List<T> list = source as List<T>;
			if (list != null)
			{
				return list;
			}
			return source.ToList<T>();
		}
		public static bool Contains(this string text, string value, StringComparison comparison)
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(value))
			{
				return false;
			}
			int num = text.IndexOf(value, comparison);
			return num >= 0;
		}
		public static bool StartsWith(this string text, string value, int startIndex, StringComparison comparison = StringComparison.Ordinal)
		{
			return !string.IsNullOrEmpty(text) && startIndex <= text.Length && !string.IsNullOrEmpty(value) && text.IndexOf(value, startIndex, comparison) == startIndex;
		}
		public static string StartsWithOneOf(this string text, string[] strings, StringComparison comparison = StringComparison.Ordinal)
		{
			if (string.IsNullOrEmpty(text) || strings == null || strings.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < strings.Length; i++)
			{
				string text2 = strings[i];
				if (text.StartsWith(text2, comparison))
				{
					return text2;
				}
			}
			return null;
		}
		public static string StartsWithOneOf(this string text, int startIndex, string[] strings, StringComparison comparison = StringComparison.Ordinal)
		{
			if (string.IsNullOrEmpty(text) || strings == null || strings.Length == 0)
			{
				return null;
			}
			for (int i = 0; i < strings.Length; i++)
			{
				string text2 = strings[i];
				if (text.StartsWith(text2, startIndex, comparison))
				{
					return text2;
				}
			}
			return null;
		}
	}
}

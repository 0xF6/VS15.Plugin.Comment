using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace AdvancedTechnologies.CommentClassifier
{
	internal class CommentTagger : ITagger<ClassificationTag>
	{
		private Dictionary<Classification, ClassificationTag> _classifications;
		private Dictionary<Classification, ClassificationTag> _htmlClassifications;
		private Dictionary<Classification, ClassificationTag> _xmlClassifications;
		private ITagAggregator<IClassificationTag> _aggregator;
		private static bool _enabled;
		private static readonly string[] Comments;
		private static readonly string[] ImportantComments;
		private static readonly string[] QuestionComments;
		private static readonly string[] WtfComments;
		private static readonly string[] RemovedComments;
		private static readonly string[] TaskComments;
		private static readonly List<ITagSpan<ClassificationTag>> EmptyTags;
		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
		internal CommentTagger(IClassificationTypeRegistryService registry, ITagAggregator<IClassificationTag> aggregator)
		{
			this._classifications = new string[]
			{
				"Comment - Important",
				"Comment - Question",
				"Comment - WAT!?",
				"Comment - Removed",
				"Comment - Task"
			}.ToDictionary(new Func<string, Classification>(CommentTagger.GetClassification), (string s) => new ClassificationTag(registry.GetClassificationType(s)));
			this._htmlClassifications = new string[]
			{
				"HTML Comment - Important",
				"HTML Comment - Question",
				"Comment - WAT!?",
				"HTML Comment - Removed",
				"HTML Comment - Task"
			}.ToDictionary(new Func<string, Classification>(CommentTagger.GetClassification), (string s) => new ClassificationTag(registry.GetClassificationType(s)));
			this._xmlClassifications = new string[]
			{
				"XML Comment - Important",
				"XML Comment - Question",
				"Comment - WAT!?",
				"XML Comment - Removed",
				"XML Comment - Task"
			}.ToDictionary(new Func<string, Classification>(CommentTagger.GetClassification), (string s) => new ClassificationTag(registry.GetClassificationType(s)));
			this._aggregator = aggregator;
		}
		static CommentTagger()
		{
			CommentTagger.Comments = new string[]
			{
				"//",
                "///",
				"'",
				"#",
				"<!--"
			};
			CommentTagger.ImportantComments = new string[]
			{
				"! ",
				"# "
			};
			CommentTagger.QuestionComments = new string[]
			{
				"? "
			};
			CommentTagger.WtfComments = new string[]
			{
                "& ",
				"!? ",
				"‽ ",
				"WTF ",
				"WTF: "
			};
			CommentTagger.RemovedComments = new string[]
			{
				"x ",
				"¤ ",
				"// ",
				"//"
			};
			CommentTagger.TaskComments = new string[]
			{
				"TODO ",
				"TODO:",
				"TODO@",
				"HACK ",
				"HACK:",
                "@ "
			};
			CommentTagger.EmptyTags = new List<ITagSpan<ClassificationTag>>();
			CommentTagger._enabled = CommentTagger.IsEnabled();
		}
		private static bool IsEnabled()
		{
			bool result = true;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\AGTSoul\\VS15\\Comment", false))
				{
					int num = Convert.ToInt32(registryKey.GetValue("EnableTags", 1));
					result = (num != 0);
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Failed to read registry: " + ex.Message, "AGTSoul");
			}
			return result;
		}
		public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
		{
			return this.GetTagsInternal(spans);
		}
		private IEnumerable<ITagSpan<ClassificationTag>> GetTagsInternal(NormalizedSnapshotSpanCollection spans)
		{
			if (!CommentTagger._enabled || spans.Count == 0)
			{
				return CommentTagger.EmptyTags;
			}
			ITextSnapshot snapshot = spans[0].Snapshot;
			IContentType contentType = snapshot.TextBuffer.ContentType;
			if (!contentType.IsOfType("code"))
			{
				return CommentTagger.EmptyTags;
			}
			bool flag = this.IsMarkup(contentType);
			Dictionary<Classification, ClassificationTag> dictionary = this._classifications;
			if (CommentTagger.IsHtmlMarkup(contentType))
			{
				dictionary = this._htmlClassifications;
			}
			else if (CommentTagger.IsXmlMarkup(contentType))
			{
				dictionary = this._xmlClassifications;
			}
			List<ITagSpan<ClassificationTag>> list = null;
			foreach (IMappingTagSpan<IClassificationTag> current in this._aggregator.GetTags(spans))
			{
				string classification = current.Tag.ClassificationType.Classification;
				if (classification.Contains("comment", StringComparison.OrdinalIgnoreCase))
				{
					NormalizedSnapshotSpanCollection spans2 = current.Span.GetSpans(snapshot);
					if (spans2.Count > 0)
					{
						SnapshotSpan snapshotSpan = spans2[0];
						string text = snapshotSpan.GetText();
						if (!string.IsNullOrWhiteSpace(text))
						{
							string text2 = text.StartsWithOneOf(CommentTagger.Comments, StringComparison.Ordinal);
							if (text2 == null)
							{
								if (!flag)
								{
									continue;
								}
								text2 = "";
							}
							int length = text2.Length;
							int num = 0;
							if (flag && text2.Length > 0)
							{
								if (!text.EndsWith("-->"))
								{
									continue;
								}
								num = 3;
							}
							ClassificationTag classificationTag = null;
							string text3;
							if (CommentTagger.Match(text, length, CommentTagger.ImportantComments, out text3))
							{
								classificationTag = dictionary[Classification.Important];
							}
							else if (CommentTagger.Match(text, length, CommentTagger.QuestionComments, out text3))
							{
								classificationTag = dictionary[Classification.Question];
							}
							else if (CommentTagger.Match(text, length, CommentTagger.RemovedComments, out text3))
							{
								if (text2 == "//" && text3 == "//")
								{
									int num2 = length + text3.Length;
									if (text.Length > num2 && text[num2] != '/')
									{
										classificationTag = dictionary[Classification.Removed];
									}
								}
								else
								{
									classificationTag = dictionary[Classification.Removed];
								}
							}
							else if (CommentTagger.Match(text, length, CommentTagger.TaskComments, StringComparison.OrdinalIgnoreCase, out text3))
							{
								CommentTagger.FixTaskComment(text, length, ref text3);
								classificationTag = dictionary[Classification.Task];
							}
							else if (CommentTagger.Match(text, length, CommentTagger.WtfComments, out text3))
							{
								classificationTag = dictionary[Classification.Wtf];
							}
							if (classificationTag != null)
							{
								int num3 = text2.Length + text3.Length;
								int num4 = snapshotSpan.Length - (num3 + num);
								SnapshotSpan snapshotSpan2 = new SnapshotSpan(snapshotSpan.Snapshot, snapshotSpan.Start + num3, num4);
								TagSpan<ClassificationTag> item = new TagSpan<ClassificationTag>(snapshotSpan2, classificationTag);
								if (list == null)
								{
									list = new List<ITagSpan<ClassificationTag>>();
								}
								list.Add(item);
							}
						}
					}
				}
			}
			return list ?? CommentTagger.EmptyTags;
		}
		private static bool FixTaskComment(string text, int startIndex, ref string match)
		{
			bool result = false;
			if (match != null && match.EndsWith("@", StringComparison.Ordinal))
			{
				int num = text.IndexOfAny(new char[]
				{
					' ',
					'\t',
					':'
				}, startIndex + match.Length);
				if (num >= 0)
				{
					int length = num - startIndex + 1;
					match = text.Substring(startIndex, length);
					result = true;
				}
			}
			return result;
		}
		private static bool Match(string commentText, int startIndex, string[] templates, out string match)
		{
			return CommentTagger.Match(commentText, startIndex, templates, StringComparison.Ordinal, out match);
		}
		private static bool Match(string commentText, int startIndex, string[] templates, StringComparison comparison, out string match)
		{
			match = commentText.StartsWithOneOf(startIndex, templates, comparison);
			return match != null;
		}
		private static Classification GetClassification(string s)
		{
			if (s.Contains("Important"))
			{
				return Classification.Important;
			}
			if (s.Contains("Question"))
			{
				return Classification.Question;
			}
			if (s.Contains("Removed"))
			{
				return Classification.Removed;
			}
			if (s.Contains("Task"))
			{
				return Classification.Task;
			}
			if (s.Contains("WAT"))
			{
				return Classification.Wtf;
			}
			throw new ArgumentException("Unknown classification type");
		}
		private bool IsMarkup(IContentType contentType)
		{
			return CommentTagger.IsHtmlMarkup(contentType) || CommentTagger.IsXmlMarkup(contentType);
		}
		private static bool IsHtmlMarkup(IContentType contentType)
		{
			return contentType.IsOfType("html") || contentType.IsOfType("htmlx");
		}
		private static bool IsXmlMarkup(IContentType contentType)
		{
			return contentType.IsOfType("XAML") || contentType.IsOfType("XML");
		}
	}
}

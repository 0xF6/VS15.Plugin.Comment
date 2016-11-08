using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "HTML Comment - Question"), UserVisible(true), Name("HTML Comment - Question"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class QuestionHtmlCommentFormat : ClassificationFormatDefinition
	{
		public QuestionHtmlCommentFormat()
		{
			base.DisplayName = ("HTML Comment - Question (<!--?)");
			base.ForegroundColor = (new Color?(Constants.QuestionColor));
		}
	}
}

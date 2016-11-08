using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "Comment - Question"), UserVisible(true), Name("Comment - Question"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class QuestionCommentFormat : ClassificationFormatDefinition
	{
		public QuestionCommentFormat()
		{
			base.DisplayName = ("Comment - Question (//?)");
			base.ForegroundColor = (new Color?(Constants.QuestionColor));
		}
	}
}

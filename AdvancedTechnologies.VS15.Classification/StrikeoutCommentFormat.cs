using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "Comment - Removed"), UserVisible(true), Name("Comment - Removed"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class StrikeoutCommentFormat : ClassificationFormatDefinition
	{
		public StrikeoutCommentFormat()
		{
			base.DisplayName = ("Comment - Removed (//x)");
			base.ForegroundColor = (new Color?(Constants.RemovedColor));
			base.TextDecorations = (System.Windows.TextDecorations.Strikethrough);
		}
	}
}

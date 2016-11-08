using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "HTML Comment - Removed"), UserVisible(true), Name("HTML Comment - Removed"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class StrikeoutHtmlCommentFormat : ClassificationFormatDefinition
	{
		public StrikeoutHtmlCommentFormat()
		{
			base.DisplayName = ("HTML Comment - Removed (<!--x)");
			base.ForegroundColor = (new Color?(Constants.RemovedColor));
			base.TextDecorations = (System.Windows.TextDecorations.Strikethrough);
		}
	}
}

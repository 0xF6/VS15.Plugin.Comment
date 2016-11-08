using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "XML Comment - Removed"), UserVisible(true), Name("XML Comment - Removed"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class StrikeoutXmlCommentFormat : ClassificationFormatDefinition
	{
		public StrikeoutXmlCommentFormat()
		{
			base.DisplayName = ("XML Comment - Removed (<!--x)");
			base.ForegroundColor = (new Color?(Constants.RemovedColor));
			base.TextDecorations = (System.Windows.TextDecorations.Strikethrough);
		}
	}
}

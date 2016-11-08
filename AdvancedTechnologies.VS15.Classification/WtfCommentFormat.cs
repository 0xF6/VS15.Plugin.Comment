using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "Comment - WAT!?"), UserVisible(true), Name("Comment - WAT!?"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class WtfCommentFormat : ClassificationFormatDefinition
	{
		public WtfCommentFormat()
		{
			base.DisplayName = ("Comment - WAT!? (//!?)");
			base.ForegroundColor = (new Color?(Constants.WtfColor));
		}
	}
}

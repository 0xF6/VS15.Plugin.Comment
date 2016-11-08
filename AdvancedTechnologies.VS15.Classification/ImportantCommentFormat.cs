using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "Comment - Important"), UserVisible(true), Name("Comment - Important"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class ImportantCommentFormat : ClassificationFormatDefinition
	{
		public ImportantCommentFormat()
		{
			base.DisplayName = ("Comment - Important (//!)");
			base.ForegroundColor = (new Color?(Constants.ImportantColor));
			base.IsBold = (new bool?(true));
		}
	}
}

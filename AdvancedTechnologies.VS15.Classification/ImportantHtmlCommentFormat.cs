using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "HTML Comment - Important"), UserVisible(true), Name("HTML Comment - Important"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class ImportantHtmlCommentFormat : ClassificationFormatDefinition
	{
		public ImportantHtmlCommentFormat()
		{
			base.DisplayName = ("HTML Comment - Important (<!--!)");
			base.ForegroundColor = (new Color?(Constants.ImportantColor));
			base.IsBold = (new bool?(true));
		}
	}
}

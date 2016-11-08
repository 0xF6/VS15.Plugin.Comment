using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "XML Comment - Important"), UserVisible(true), Name("XML Comment - Important"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class ImportantXmlCommentFormat : ClassificationFormatDefinition
	{
		public ImportantXmlCommentFormat()
		{
			base.DisplayName = ("XML Comment - Important (<!--!)");
			base.ForegroundColor = (new Color?(Constants.ImportantColor));
			base.IsBold = (new bool?(true));
		}
	}
}

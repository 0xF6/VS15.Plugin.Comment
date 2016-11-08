using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "XML Comment - Question"), UserVisible(true), Name("XML Comment - Question"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class QuestionXmlCommentFormat : ClassificationFormatDefinition
	{
		public QuestionXmlCommentFormat()
		{
			base.DisplayName = ("XML Comment - Question (<!--?)");
			base.ForegroundColor = (new Color?(Constants.QuestionColor));
		}
	}
}

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "XML Comment - Task"), UserVisible(true), Name("XML Comment - Task"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class TaskXmlCommentFormat : ClassificationFormatDefinition
	{
		public TaskXmlCommentFormat()
		{
			base.DisplayName = ("XML Comment - Task (<!--TODO)");
			base.ForegroundColor = (new Color?(Constants.TaskColor));
		}
	}
}

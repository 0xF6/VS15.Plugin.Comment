using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "HTML Comment - Task"), UserVisible(true), Name("HTML Comment - Task"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class TaskHtmlCommentFormat : ClassificationFormatDefinition
	{
		public TaskHtmlCommentFormat()
		{
			base.DisplayName = ("HTML Comment - Task (<!--TODO)");
			base.ForegroundColor = (new Color?(Constants.TaskColor));
		}
	}
}

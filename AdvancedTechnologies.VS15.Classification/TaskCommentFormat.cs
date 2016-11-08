using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	[ClassificationType(ClassificationTypeNames = "Comment - Task"), UserVisible(true), Name("Comment - Task"), Order(After = "High Priority"), Export(typeof(EditorFormatDefinition))]
	public sealed class TaskCommentFormat : ClassificationFormatDefinition
	{
		public TaskCommentFormat()
		{
			base.DisplayName = ("Comment - Task (//TODO)");
			base.ForegroundColor = (new Color?(Constants.TaskColor));
		}
	}
}

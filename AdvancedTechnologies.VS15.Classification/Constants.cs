using System;
using System.Windows.Media;
namespace AdvancedTechnologies.CommentClassifier
{
	internal static class Constants
	{
		public const string ImportantComment = "Comment - Important";
		public const string ImportantHtmlComment = "HTML Comment - Important";
		public const string ImportantXmlComment = "XML Comment - Important";
		public const string QuestionComment = "Comment - Question";
		public const string QuestionHtmlComment = "HTML Comment - Question";
		public const string QuestionXmlComment = "XML Comment - Question";
		public const string WtfComment = "Comment - WAT!?";
		public const string RemovedComment = "Comment - Removed";
		public const string RemovedHtmlComment = "HTML Comment - Removed";
		public const string RemovedXmlComment = "XML Comment - Removed";
		public const string TaskComment = "Comment - Task";
		public const string TaskHtmlComment = "HTML Comment - Task";
		public const string TaskXmlComment = "XML Comment - Task";
		public static readonly Color ImportantColor = Colors.Green;
		public static readonly Color QuestionColor = Colors.Red;
		public static readonly Color WtfColor = Colors.Purple;
		public static readonly Color RemovedColor = Colors.Gray;
		public static readonly Color TaskColor = Color.FromRgb(192, 96, 0);
	}
}

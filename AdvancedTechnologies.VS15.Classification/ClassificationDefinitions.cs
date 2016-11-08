using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
namespace AdvancedTechnologies.CommentClassifier
{
	public static class ClassificationDefinitions
	{
		[BaseDefinition("Comment"), Name("Comment - Important"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition ImportantCommentClassificationType;
		[BaseDefinition("Comment"), Name("Comment - Question"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition QuestionCommentClassificationType;
		[BaseDefinition("Comment"), Name("Comment - WAT!?"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition WtfCommentClassificationType;
		[BaseDefinition("Comment"), Name("Comment - Removed"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition StrikeoutCommentClassificationType;
		[BaseDefinition("Comment"), Name("Comment - Task"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition TaskCommentClassificationType;
		[BaseDefinition("HTML Comment"), Name("HTML Comment - Important"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition ImportantHtmlCommentClassificationType;
		[BaseDefinition("HTML Comment"), Name("HTML Comment - Question"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition QuestionHtmlCommentClassificationType;
		[BaseDefinition("HTML Comment"), Name("HTML Comment - Removed"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition StrikeoutHtmlCommentClassificationType;
		[BaseDefinition("HTML Comment"), Name("HTML Comment - Task"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition TaskHtmlCommentClassificationType;
		[BaseDefinition("XML Comment"), Name("XML Comment - Important"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition ImportantXmlCommentClassificationType;
		[BaseDefinition("XML Comment"), Name("XML Comment - Question"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition QuestionXmlCommentClassificationType;
		[BaseDefinition("XML Comment"), Name("XML Comment - Removed"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition StrikeoutXmlCommentClassificationType;
		[BaseDefinition("Xml Comment"), Name("XML Comment - Task"), Export(typeof(ClassificationTypeDefinition))]
		internal static ClassificationTypeDefinition TaskXmlCommentClassificationType;
	}
}

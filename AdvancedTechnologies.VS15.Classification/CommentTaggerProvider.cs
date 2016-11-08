using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
namespace AdvancedTechnologies.CommentClassifier
{
	[TagType(typeof(ClassificationTag)), ContentType("code"), Export(typeof(IViewTaggerProvider))]
	public class CommentTaggerProvider : IViewTaggerProvider
	{
		[Import]
		internal IClassificationTypeRegistryService ClassificationRegistry;
		[Import]
		internal IBufferTagAggregatorFactoryService Aggregator;
		public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
		{
			return new CommentTagger(this.ClassificationRegistry, this.Aggregator.CreateTagAggregator<IClassificationTag>(buffer)) as ITagger<T>;
		}
	}
}

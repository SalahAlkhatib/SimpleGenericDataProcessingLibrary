namespace SimpleGenericDataProcessingLibrary
{
	public static class ExtensionMethods
	{
		public static DataPipeline<T> ToDataPipeline<T>(this IEnumerable<T> data)
			=> new(data);

		public static DataPipeline<T> Filter<T>(this DataPipeline<T> pipeline, Func<T, bool> predicate)
			=> new(Iterator(pipeline, predicate));

		public static DataPipeline<TResult> Map<T, TResult>(this DataPipeline<T> pipeline, Func<T, TResult> selector)
			=> new(Iterator(pipeline, selector));


		#region private methods
		private static IEnumerable<T> Iterator<T>(DataPipeline<T> pipeline, Func<T, bool> predicate)
		{
			foreach (var item in pipeline)
			{
				if (predicate(item))
					yield return item;
			}
		}
		
		private static IEnumerable<TResult> Iterator<T, TResult>(DataPipeline<T> pipeline, Func<T, TResult> selector)
		{
			foreach (var item in pipeline)
			{
				yield return selector(item);
			}
		}
		#endregion
	}
}

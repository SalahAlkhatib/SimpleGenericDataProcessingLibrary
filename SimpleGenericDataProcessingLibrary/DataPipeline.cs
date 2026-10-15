using System.Collections;

namespace SimpleGenericDataProcessingLibrary
{
	public class DataPipeline<T> : IEnumerable<T>
	{
		private IEnumerable<T> Data { get;  init; }

		public DataPipeline(IEnumerable<T> data)
			=> Data = data;

		public IEnumerator<T> GetEnumerator()
			=> Data.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
	}
}

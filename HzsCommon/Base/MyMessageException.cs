using System;

namespace HzsCommon
{
	[Serializable]
	public class MyMessageException : Exception
	{
		// Methods
		public MyMessageException(string message)
			: base(message)
		{
		}

	}
}
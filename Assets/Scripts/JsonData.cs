using System;
using System.Collections.Generic;

namespace UnityCandidateChallenge
{
	[Serializable]
	public class JsonData
	{
		public string Title;
		public string[] ColumnHeaders;
		public object Data;
	
		public Dictionary<string, string>[] Members;
	
		public JsonData(string titleInit, string[] columnHeadersInit, object dataInit)
		{
			this.Title = titleInit;
			this.ColumnHeaders = columnHeadersInit;
			this.Data = dataInit;
		}
	
	}
}

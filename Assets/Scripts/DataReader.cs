using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UnityCandidateChallenge
{
	public class DataReader : MonoBehaviour
	{
		private string path;
		private JsonData jsonData;
	
		public JsonData ReadData()
		{
			path = Application.streamingAssetsPath + "/jsonChallenge.json";
			var stream = File.OpenRead(path);
			
			using (var reader = new StreamReader(stream))
			{
				string contents = reader.ReadToEnd();

				jsonData = JsonConvert.DeserializeObject<JsonData>(contents);
				var headerDictionary = jsonData.ColumnHeaders.ToDictionary(key => key, value => value);
	
				var root = JToken.Parse(contents);
				foreach (var token in root)
				{
					if (token == root.Last)
					{
						var data = token.First;
						var dataArray = data.ToArray();
	
						jsonData.Members = new Dictionary<string, string>[dataArray.Length];
						for (int i = 0; i < dataArray.Length; i++)
						{
							var member = dataArray[i];
							var objectString = JsonConvert.SerializeObject(member);
	
							var memberDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(objectString);
							jsonData.Members[i] = memberDictionary;
	
						}
					}
				}
			}
	
			return jsonData;
		}
	
	}
}
 
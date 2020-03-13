using UnityEngine;
using UnityEngine.UI;

namespace UnityCandidateChallenge
{
	public class DataDisplay : MonoBehaviour
	{
		[Header("Elements")]
		[SerializeField] private Text title;
		[SerializeField] private RectTransform headerDisplay;
		[SerializeField] private RectTransform memberDisplay;
		[SerializeField] private RectTransform memberPrefab;
		[SerializeField] private Text TextValuePrefab;
		[SerializeField] private DataReader dataReader;
	
		private JsonData loadedData;
	
		private void Start()
		{
			LoadData();
		}
	
		public void LoadData()
		{
			DestroyContent();
			loadedData = dataReader.ReadData();
	
			if (loadedData != null)
			{
				Display(loadedData);
			}
		}
	
		private void DestroyContent()
		{
			foreach (Transform item in headerDisplay)
			{
				Destroy(item.gameObject);
			}
			
			foreach (Transform item in memberDisplay)
			{
				Destroy(item.gameObject);
			}
		}
	
		private void Display(JsonData data)
		{
			title.text = data.Title.ToString();
			title.SetAllDirty();

			PopulateHeaderDisplay(data.ColumnHeaders);
			PopulateMemberDisplay(data);

			Canvas.ForceUpdateCanvases();
		}
	
		private void PopulateHeaderDisplay(string[] headerArray)
		{
			foreach (var header in headerArray)
			{
				var headerValue = Instantiate(TextValuePrefab, headerDisplay);
				headerValue.text = "<b>" + header + "</b>";
				headerValue.SetAllDirty();
			}
		}
	
		private void PopulateMemberDisplay(JsonData data)
		{
			foreach (var member in data.Members)
			{
				var memberObject = Instantiate(memberPrefab, memberDisplay);
				foreach (var header in data.ColumnHeaders)
				{
					var value = member[header];
					var textValueObject = Instantiate(TextValuePrefab, memberObject);
					textValueObject.text = value;
					textValueObject.SetAllDirty();
				}
			}
		}
	}
}

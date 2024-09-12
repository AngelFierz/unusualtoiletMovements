using UnityEngine;
using UnityEngine.UI;

public class ToggleUIVisibility : MonoBehaviour
{
	public Button toggleButton; 
	public GameObject targetObject; 

	private bool isVisible = false; 

	void Start()
	{
		
		if (toggleButton != null && targetObject != null)
		{
			toggleButton.onClick.AddListener(ToggleVisibility); 
		}
		else
		{
			Debug.LogError("ToggleButton is not assigned in the stupid inspector you moron, come on , And wjhy are you looking here?!");
		}
	}

	
	void ToggleVisibility()
	{
		isVisible = !isVisible; 
		targetObject.SetActive(isVisible); 
	}
}

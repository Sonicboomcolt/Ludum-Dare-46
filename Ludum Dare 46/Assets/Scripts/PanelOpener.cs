using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
	public GameObject Panel;

	public void OpenPanel()
	
	{			
			if(Panel != null)
		{
			bool isActive = Panel.activeSelf;
			
				Panel.SetActive(!isActive);
				if(!isActive)
				{
					//Cursor.lockState = CursorLockMode.None;
					//Cursor.visible = true;
					//Time.timeScale = 0;
				}
				else
				{
					//Cursor.lockState = CursorLockMode.Locked;
					//Cursor.visible = false;
					//Time.timeScale = 1;
				}
		}
		
		
	}
	        public void QuitGame()
	{
		Debug.Log("You've quir the game libtard");
		Application.Quit();
	}
}

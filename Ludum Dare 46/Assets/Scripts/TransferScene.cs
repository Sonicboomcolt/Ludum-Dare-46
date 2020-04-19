using UnityEngine;
using UnityEngine.SceneManagement;
//Made by AspectDevelops
public class TransferScene : MonoBehaviour
{
	public void LevelEasy()
		{
			SceneManager.LoadScene(1);
		} 
	public void LevelMedium()
	{
		SceneManager.LoadScene(2);
	}
	public void LevelMainMenu()
	{
		SceneManager.LoadScene(0);
	} 
	public void LevelHard()
	{
		SceneManager.LoadScene(3);
	}
	public void LevelExtream()
	{
		SceneManager.LoadScene(4);
	}
	public void QUIT()
	{
		Application.Quit();
	}
}
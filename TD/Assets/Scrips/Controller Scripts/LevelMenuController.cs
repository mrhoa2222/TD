using UnityEngine;
using System.Collections;

public class LevelMenuController : MonoBehaviour {

	public void PlayGame(string name)
	{
		Application.LoadLevel (name);
	}
	public void BackToMenu()
	{
		Application.LoadLevel ("LevelMenu");
	}
	

}

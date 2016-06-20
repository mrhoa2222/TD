using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	
    
	public void PlayGame()
	{
		Application.LoadLevel ("Menu");
	}
	public void Exit()
	{
		Application.Quit ();
	}
	public void TroVe()
	{
		Application.LoadLevel ("LevelMenu");
	}
	public void GioiThieu()
	{
		Application.LoadLevel ("GioiThieu");
	}

	

}

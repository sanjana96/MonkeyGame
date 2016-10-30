using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	public void menu (int level) 
	{
		Application.LoadLevel(level);
    }
}

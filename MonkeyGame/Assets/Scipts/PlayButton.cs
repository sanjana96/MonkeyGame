using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour 
{
	public void loadLevel (int level) 
	{
		Application.LoadLevel(level);
    }
}

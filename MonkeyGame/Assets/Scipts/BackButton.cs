using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public void back(int level) 
	{
		Application.LoadLevel(level);
    }
}

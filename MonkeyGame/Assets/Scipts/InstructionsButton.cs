using UnityEngine;
using System.Collections;

public class InstructionsButton : MonoBehaviour {

	public void inst (int level) 
	{
		Application.LoadLevel(level);
    }
}

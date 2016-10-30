using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour
{
	public GameObject score;
	public AudioClip basket;
	public GameObject thrownObject;

	public int currentScore ;

	void OnCollisionEnter()
	{
		audio.Play();
		currentScore = int.Parse(score.GetComponent<GUIText>().text) + 1;
		score.GetComponent<GUIText>().text = currentScore.ToString();
	}


}
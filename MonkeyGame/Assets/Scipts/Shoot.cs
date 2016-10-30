using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
	private Vector3 throwSpeed = new Vector3(0, 26, 46); //This value is a sure hit
    public Vector3 ballPos;
    private bool thrown = false;
    private GameObject ballClone;
	public GameObject windText;

	System.Random rand = new System.Random ();

    //public GameObject availableShotsGO;
    //private int availableShots = 10;

	public GameObject missedShotsGO;
	private int missedShots = 0;
	private int totalShots = 0;
	Basket b = new Basket ();

	public float windSpeed;
    public GameObject meter;
    public GameObject arrow;
	public GameObject windArrow;
    private float arrowSpeed = 0.2f; //Difficulty
    private bool right = true;

	private float choose; 

    public GameObject gameOver;


    // Use this for initialization
    void Start()
    {
        /* Increase Gravity */
		 choose = rand.Next (0, 2);

		windSpeed = rand.Next (-30, 30);

		          //windSpeed = rand.Next (-30, 30);
		          if (choose < 1) {
						if (windSpeed < 0) {
								windArrow.transform.rotation = Quaternion.identity;
								//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
						} else {
								windArrow.transform.rotation = Quaternion.Euler (0, 180, 0);
								//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
						}
				}
		else {
			if (windSpeed < 0) {
				windArrow.transform.rotation = Quaternion.Euler (0,0,90);
			}
				else{
					windArrow.transform.rotation = Quaternion.Euler (0,0,270);
			}
		}
		windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
		Physics.gravity = new Vector3(0, -30, 0);
   }

    void FixedUpdate()
    {
        /* Move Meter Arrow */

		//Physics.gravity = new Vector3(windSpeed, -30, 0);
        if (arrow.transform.position.y < -3.3f && right)
        {
			arrow.transform.position += new Vector3(0, arrowSpeed, 0);
        }
        if (arrow.transform.position.y >= -3.3f)
        {
            right = false;
        }
        if (right == false)
        {
			arrow.transform.position -= new Vector3(0, arrowSpeed, 0);
        }
        if ( arrow.transform.position.y <= -12.8f)
        {
            right = true;
        }

        /* Shoot ball on Tap */

        if (Input.GetButton("Fire1") && !thrown && /*availableShots > 0*/ missedShots<11)
        {
            thrown = true;
            //availableShots--;
			totalShots++;
			missedShots = totalShots - b.currentScore;
            missedShotsGO.GetComponent<GUIText>().text = missedShots.ToString();

            ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;

			if(choose<1)
			{
            throwSpeed.y = throwSpeed.y + 8.0f + arrow.transform.position.y;
            throwSpeed.z = throwSpeed.z +  8.0f +arrow.transform.position.y;
			throwSpeed.x = windSpeed;
			}
			else
			{
				throwSpeed.y = throwSpeed.y + 8.0f + arrow.transform.position.y + windSpeed/5.0f;
				throwSpeed.z = throwSpeed.z +  8.0f +arrow.transform.position.y + windSpeed/5.0f;
				throwSpeed.x = 0;

			}
			/* windSpeed = rand.Next (-30, 30);
			if (windSpeed < 0) {
				windArrow.transform.rotation = Quaternion.identity;
				windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			} 
			else {
				windArrow.transform.rotation = Quaternion.Euler(0,180,0);
				windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			} */
            ballClone.rigidbody.AddForce(throwSpeed, ForceMode.Impulse);
            audio.Play();
        }

        /* Remove Ball when it hits the floor */

        if (ballClone != null && ballClone.transform.position.y < -16)
        {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 26, 46);//Reset perfect shot variable

            /* Check if out of shots */
            
            if (/*availableShots==0*/missedShots == 10)
            {
                arrow.renderer.enabled = false;
                Instantiate(gameOver, new Vector3(0.4f, 0.2f, 0), transform.rotation);
                Invoke("restart", 2);
            }
			/*

			windSpeed = rand.Next (-30, 30);
			if (windSpeed < 0) {
				windArrow.transform.rotation = Quaternion.identity;
				windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			} 
			else {
				windArrow.transform.rotation = Quaternion.Euler(0,180,0);
				windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			} */

			choose = rand.Next (0, 2);
			
			windSpeed = rand.Next (-30, 30);
			
			//windSpeed = rand.Next (-30, 30);
			if (choose < 1) {
				if (windSpeed < 0) {
					windArrow.transform.rotation = Quaternion.identity;
					//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
				} else {
					windArrow.transform.rotation = Quaternion.Euler (0, 180, 0);
					//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
				}
			}
			else {
				if (windSpeed < 0) {
					windArrow.transform.rotation = Quaternion.Euler (0,0,90);
				}
				else{
					windArrow.transform.rotation = Quaternion.Euler (0,0,270);
				}
			}
			windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
        }

		

    }
	void OnCollisionEnter(Collision collision)
	{
				if (collision.gameObject.name == "bananaclone")
						Destroy (collision.gameObject);
		/*
		windSpeed = rand.Next (-30, 30);
		if (windSpeed < 0) {
			windArrow.transform.rotation = Quaternion.identity;
			windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
		} 
		else {
			windArrow.transform.rotation = Quaternion.Euler(0,180,0);
			windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
		}
		*/

		choose = rand.Next (0, 2);
		
		windSpeed = rand.Next (-30, 30);
		
		//windSpeed = rand.Next (-30, 30);
		if (choose < 1) {
			if (windSpeed < 0) {
				windArrow.transform.rotation = Quaternion.identity;
				//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			} else {
				windArrow.transform.rotation = Quaternion.Euler (0, 180, 0);
				//windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
			}
		}
		else {
			if (windSpeed < 0) {
				windArrow.transform.rotation = Quaternion.Euler (0,0,90);
			}
			else{
				windArrow.transform.rotation = Quaternion.Euler (0,0,270);
			}
		}
		windText.GetComponent<GUIText> ().text = Math.Abs(windSpeed).ToString ();
	}

    void Update(){
   if (Input.GetKeyDown(KeyCode.Escape)) 
    Application.Quit(); 
 }

    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
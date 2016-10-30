using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

public class MonkeyMovement : MonoBehaviour {

	public float speed = 10f;            // The speed that the player will move at.
	Vector3 movement;                   // The vector to store the direction of the player's movement.
//	public float tilt;
	public Boundary boundary;

	void Awake () 
	{
	}
    void Update ()
	{
		float moveHorizontal =  Input.acceleration.x;
		Vector3 movement = new Vector3 (moveHorizontal, 10.0f, 35.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 10.0f, 35.0f);
	//	rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}

/*
using UnityEngine;
using System.Collections;

public class MonkeyMovement : MonoBehaviour 
{
	public float tilt;
	public float speed = 6f;  
	void awake()
	{
		
	}
	void Update () 
	{
		float ax = Input.acceleration.x;
		Vector3 movement = new Vector3 (ax, 10.0f, 35.0f);
		if(ax>37f || ax<-37f)
			rigidbody.velocity = movement * 0f;
		else
		   rigidbody.velocity = movement * speed;
		//rigidbody.position = new Vector3 (Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 10.0f, 35.0f);
		movement *= Time.deltaTime;
		transform.Translate(movement * speed);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}*/
using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour 
{
	private bool path = false; //this tells us if we have a path
	private Vector3 targetPosition;

	public float dampSpeed = 0.5f; // this is the speed at which we rotate toward the point
	public float maxSpeed = 20.0f;
	public float acceleration = 1.0f;

	public void GoTo(Vector3 pos)
	{
		//Set target position
		targetPosition = pos;
		//Set path to true
		path = true	;
	}
	void GotThere()
	{
		//Set path to false
		path = false;
	}
	void FixedUpdate()
	{
		float speed;
		Vector3 lastPosition;

		//Check speed
		speed = (transform.position - lastPosition).magnitude;
		lastPosition = transform.position;

		if(path)
		{
			//Look at the position
			Vector3 relativePos = targetPosition - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			gameObject.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, dampSpeed);

			if(speed < maxSpeed)
			{
				gameObject.rigidbody.AddForce(acceleration*transform.forward);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour 
{
	private bool path = false; //this tells us if we have a path
	private Vector3 targetPosition;

	public float dampSpeed = 0.5f; // this is the speed at which we rotate toward the point
	public float slowDrag = 0.977f; // Fine tuned number to get the object to stop at the mouse click
	public float maxSpeed = 20.0f;
	public float acceleration = 1.0f;
	public float goAngle = 5; // Angle at which the object will begin forward motion
	public float targetPositionTolerance = 2; // Radius when object is "close enough" to mouse click

	public void GoTo(Vector3 pos)
	{
		//Set target position
		targetPosition = pos;
		//Set path to true
		path = true	;
	}

	void FixedUpdate()
	{
		if(path)
		{
			Debug.Log(path);
			//Look at the position
			Vector3 relativePos = targetPosition - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, dampSpeed);
			
			float angle = Quaternion.Angle(transform.rotation, rotation);
			if ((transform.position - this.targetPosition).magnitude < 5 && rigidbody.velocity.magnitude > 0) {
				rigidbody.velocity *= this.slowDrag;
			} else if(rigidbody.velocity.magnitude < this.maxSpeed && (angle > -this.goAngle && angle < this.goAngle)) {
				rigidbody.AddForce(transform.forward * this.acceleration);
			}
			if((transform.position - this.targetPosition).magnitude < 1) {
				path = false;
			}
		}
	}
}

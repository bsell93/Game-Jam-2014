using UnityEngine;
using System.Collections;

public class CameraActions : MonoBehaviour
{
	public float xMultiplier = 1.0f;
	public float zMultiplier = 1.0f;
	public int scrollSpeed = 5;

	private bool trackLeftMouse = false;
	private bool trackRightMouse = false;
	private Vector3 lastState;
	private Vector3 distance;
	private Vector3 point;

	void Start ()
	{
		this.point = new Vector3(0,0,0);
		transform.LookAt(point);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) { // Left click, pan camera
			this.trackLeftMouse = true;
			this.lastState = Input.mousePosition;
		} else if (Input.GetMouseButtonDown(1)) { // Right click, rotate camera
			this.trackRightMouse = true;
			this.lastState = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp(0)) {
			this.trackLeftMouse = false;
		} else if (Input.GetMouseButtonUp(1)) {
			this.trackRightMouse = false;
			Debug.Log(this.distance);
		}

		if (this.trackLeftMouse) {
			Debug.Log("Left Click Down");
			Vector3 currentPosition = Input.mousePosition;
			if ((this.lastState - currentPosition).magnitude > 2) {
				this.distance.x = (transform.position.x + ((currentPosition.x - this.lastState.x) * this.xMultiplier));
				this.distance.z = (transform.position.z + ((currentPosition.y - this.lastState.y) * this.zMultiplier));
				float lerpX = Mathf.Lerp(transform.position.x, this.distance.x, Time.deltaTime);
				float lerpZ = Mathf.Lerp(transform.position.z, this.distance.z, Time.deltaTime);
				transform.position = new Vector3(lerpX, transform.position.y, lerpZ);
				this.lastState = currentPosition;
			}
		} else if (this.trackRightMouse) {
			Debug.Log("Right Click Down");
			Vector3 currentState = Input.mousePosition;
			Debug.Log(transform.rotation);
			if ((this.lastState - currentState).magnitude > 2) {
				this.distance.y = (transform.rotation.x + (currentState.x - this.lastState.x));
				this.distance.x = (transform.rotation.y + (currentState.y - this.lastState.y));
				this.distance.z = 0;
				//Quaternion target = Quaternion.Euler(this.distance);
				//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
				transform.RotateAround(point, this.distance, Time.deltaTime * 200);
				this.lastState = currentState;
			}
		}

		transform.Translate(transform.forward * Input.GetAxis("Mouse ScrollWheel") * this.scrollSpeed);
	}
}

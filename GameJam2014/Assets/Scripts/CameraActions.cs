using UnityEngine;
using System.Collections;

public class CameraActions : MonoBehaviour
{
	public float panSpeed = 1.0f;
	public float rotateSpeed = 1.0f;
	public int scrollSpeed = 5;

	private bool trackLeftMouse = false;
	private bool trackRightMouse = false;
	private Vector3 lastState; // last state of the mouse on the screen
	private Vector3 distance; // distance the mouse has moved on the screen
	private Vector3 point; // the point teh camera looks at and looks around

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

		if (Input.GetMouseButtonUp(0)) { // End pan 
			this.trackLeftMouse = false;
		} else if (Input.GetMouseButtonUp(1)) { // End rotate
			this.trackRightMouse = false;
		}

		if (this.trackLeftMouse) {  // Pan camera
			Vector3 currentPosition = Input.mousePosition;
			if ((this.lastState - currentPosition).magnitude > 2) { // if it is a meaningful mouse move
				this.distance.x = (transform.position.x + ((currentPosition.x - this.lastState.x) * this.panSpeed));
				this.distance.z = (transform.position.z + ((currentPosition.y - this.lastState.y) * this.panSpeed));
				float lerpX = Mathf.Lerp(transform.position.x, this.distance.x, Time.deltaTime);
				float lerpZ = Mathf.Lerp(transform.position.z, this.distance.z, Time.deltaTime);
				transform.position = new Vector3(lerpX, transform.position.y, lerpZ);
				this.lastState = currentPosition;
			}
		} else if (this.trackRightMouse) { // Rotate camera
			Vector3 currentState = Input.mousePosition;
			if ((this.lastState - currentState).magnitude > 2) { // if it is a meaningful mouse move
				this.distance.y = (transform.rotation.x + (currentState.x - this.lastState.x));
				this.distance.x = (transform.rotation.y + (currentState.y - this.lastState.y));
				transform.RotateAround(point, transform.TransformDirection(Vector3.right), this.distance.x * Time.deltaTime * rotateSpeed);
				transform.RotateAround(point, Vector3.up, this.distance.y * Time.deltaTime * rotateSpeed);
				this.lastState = currentState;
			}
		}

		transform.Translate(transform.forward * Input.GetAxis("Mouse ScrollWheel") * this.scrollSpeed);
	}
}

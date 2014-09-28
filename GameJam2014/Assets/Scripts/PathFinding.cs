using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {

	public float dampSpeed = 10;
	
	private UnitManager uManager;
	
	void Start()
	{
		uManager = GameObject.FindGameObjectWithTag("manager").GetComponent("UnitManager") as UnitManager;
	}

	void RightClicked (Vector3 pos)
	{
		Debug.Log (pos);
		if (uManager.unitManager.Contains (gameObject.transform.root.gameObject)) {
			Vector3 relativePos = pos - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			gameObject.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, dampSpeed);
		}
	}
}

using UnityEngine;
using System.Collections;

public class AddUnitToUnitManager : MonoBehaviour {

	private UnitManager uManager;

	void Start()
	{
		uManager = GameObject.FindGameObjectWithTag("manager").GetComponent("UnitManager") as UnitManager;
	}

	void Clicked(Vector3 point)
	{
		Debug.Log (point);
		if (!uManager.unitManager.Contains (gameObject)) {
			uManager.unitManager.Add (gameObject);
		}
	}

	void Update () 
	{
	
	}
}

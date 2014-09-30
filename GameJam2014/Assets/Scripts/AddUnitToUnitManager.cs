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
		if (!uManager.unitManager.Contains (gameObject.transform.root.gameObject)) 
		{
			uManager.unitManager.Add (gameObject.transform.root.gameObject);
		}
	}
}

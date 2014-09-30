using UnityEngine;
using System.Collections;

public class MoveOnRightClick : MonoBehaviour 
{
	private UnitManager uManager;

	
	void Start()
	{
		uManager = GameObject.FindGameObjectWithTag("manager").GetComponent("UnitManager") as UnitManager;
	}
	
	void RightClicked(Vector3 position)
	{
		foreach(GameObject unit in uManager.unitManager)
		{
			unit.GetComponent<PathFinding>().GoTo(position);
		}
	}
}

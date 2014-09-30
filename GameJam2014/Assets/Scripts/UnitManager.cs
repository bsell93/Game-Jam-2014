using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour 
{
	public  List<GameObject> unitManager = new List<GameObject>();

	void ClearList()
	{
		unitManager.Clear();
	}
}

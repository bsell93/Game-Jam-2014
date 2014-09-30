using UnityEngine;
using System.Collections;

public class ActivateIfUnitSelected : MonoBehaviour 
{
	public float onColorAlpha = 80.0f;
	public float offColorAlpha = 0.0f;
	public float lerpTime = 1.5f;

	public Color onColor;
	public Color offColor;
	
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("manager").GetComponent<UnitManager>().unitManager.Count == 0)
		{
			gameObject.collider.enabled = false;
			renderer.material.color = Color.Lerp(gameObject.renderer.material.color, offColor, Time.deltaTime * lerpTime);
		}
		else
		{
			gameObject.collider.enabled = true;
			renderer.material.color = Color.Lerp(gameObject.renderer.material.color, onColor, Time.deltaTime * lerpTime);
		}
	}
}

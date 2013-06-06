using UnityEngine;
using System.Collections;

public class ObjectOfInterest : MonoBehaviour {
	protected GameObject Controller;
	
	void Start()
	{
		Controller = GameObject.Find("Controller");	
	}
	
	void OnMouseDown()
	{
		Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle = true;	
		Debug.Log("test");
	}
}

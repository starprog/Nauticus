using UnityEngine;
using System.Collections;

public class SkipToDestination_BTN : Window
{	
	private Vector3 zero = new Vector3(0,0,0);
	
	public bool ShowSkipBTN = false;
	
	void OnGUI()
	{
		UpdateStats();
		
		if (GUI.Button (WindowBox, Text))
		{
			Debug.Log("Target = "+Controller.GetComponent<State>().TargetWaypoint().Name);
			//Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Warp(Controller.GetComponent<State>().TargetWaypoint().transform.position);
		}
	}
}

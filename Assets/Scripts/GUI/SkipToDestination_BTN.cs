using UnityEngine;
using System.Collections;

public class SkipToDestination_BTN : Window
{	
	private Vector3 zero = new Vector3(0,0,0);
	
	public bool ShowSkipBTN = false;
	
	void OnGUI()
	{
		UpdateStats();
		
		if(Controller.GetComponent<State>().IsLooping == false)
		{
			if (GUI.Button (WindowBox, Text,Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				Debug.Log("Target = "+Controller.GetComponent<State>().PrimaryTargetWaypoint().Name);
				Controller.GetComponent<State>().TargetWaypoint(Controller.GetComponent<State>().PrimaryTargetWaypoint());
				Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Warp(Controller.GetComponent<State>().PrimaryTargetWaypoint().transform.position);
			}
		}
	}
}

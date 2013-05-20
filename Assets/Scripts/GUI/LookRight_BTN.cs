using UnityEngine;
using System.Collections;

public class LookRight_BTN : Window
{
	
	void OnGUI()
	{
		UpdateStats();
		
		if(Controller.GetComponent<State>().CurrentWaypoint() !=null)
		{
			if(Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint() &&
				Controller.GetComponent<State>().CurrentWaypoint().EndPoint == true)
			{
				if (GUI.RepeatButton(WindowBox, Text,Controller.GetComponent<HUD>().GUI_Style_RightArrow))
				{
					Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().camera.transform.Rotate(0,2,0);
				}
			}
		}
	}
}

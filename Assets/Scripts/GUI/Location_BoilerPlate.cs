using UnityEngine;
using System.Collections;

public class Location_BoilerPlate : Window
{
	public bool Location_BolierPlate_Toggle = true;
	
	// Update is called once per frame
	void Update ()
	{
		//Error Checking to make sure that the CurrentWaypoint is set
		if(Controller.GetComponent<State>().CurrentWaypoint() != null)
		{
			//If Current waypoint exists, the Text will become the Name of the Waypoint.
			Text = Controller.GetComponent<State>().CurrentWaypoint().Name;
				//+":\n"
				//+ Controller.GetComponent<State>().CurrentWaypoint().LocationInformation;
		}
	}
	
	void OnGUI()
	{		
		UpdateStats();
		if(Location_BolierPlate_Toggle == true)
		{
			GUI.Box(WindowBox,Text,Controller.GetComponent<HUD>().GUI_Style);
		}
	}
}

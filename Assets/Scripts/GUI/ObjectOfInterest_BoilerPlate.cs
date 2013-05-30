using UnityEngine;
using System.Collections;

public class ObjectOfInterest_BoilerPlate : Window
{
	void OnGUI()
	{
		UpdateStats();
		if(Controller.GetComponent<State>().CurrentWaypoint() != null && Controller.GetComponent<State>().CurrentWaypoint().HasDescriptiveItems == true)
		{
			if(GUI.Button(WindowBox,Text,Controller.GetComponent<HUD>().GUI_Style_ObjectOfInterestBoilerPlate))
			{
				Controller.GetComponent<HUD>().MenuShown = -1;
				
				if(Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle == false)
				{
					Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle = true;	
				}
				else
				{
					Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle = false;	
				}
			}
		}
	}
}

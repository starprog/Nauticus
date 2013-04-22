using UnityEngine;
using System.Collections;

public class ObjectOfInterest_BoilerPlate : Window
{
	// Update is called once per frame
	void Update ()
	{
		//Error Checking to make sure that the CurrentObjectOfInterest is set
		if(Controller.GetComponent<State>().CurrentObjectOfInterest() != null)
		{
			//If Current waypoint exists, the Text will become the Name of the Object.
			Text = Controller.GetComponent<State>().CurrentObjectOfInterest().GetComponent<ObjectOfInterest>().Name
				+":\n"
				+ Controller.GetComponent<State>().CurrentObjectOfInterest().GetComponent<ObjectOfInterest>().Information;
		}
	}
	
	void OnGUI()
	{
		UpdateStats();
		
		GUI.Box(WindowBox,Text,Controller.GetComponent<HUD>().GUI_Style);
	}
}

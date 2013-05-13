using UnityEngine;
using System.Collections;

public class ObjectOfInterest_Window : Window
{
	void OnGUI()
	{	
		UpdateStats();
		
		if(GUI.Button(WindowBox,Text,Controller.GetComponent<HUD>().GUI_Style_ObjectOfInterestWindow))
		{
			Controller.GetComponent<HUD>().ObjectOfInterestWindow_Toggle(false);	
		}
	}
}

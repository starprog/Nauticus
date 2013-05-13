using UnityEngine;
using System.Collections;

public class LookLeft_BTN : Window
{
	
	void OnGUI()
	{
		UpdateStats();
		
		if (GUI.RepeatButton (WindowBox, Text,Controller.GetComponent<HUD>().GUI_Style_LeftArrow))
		{
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().camera.transform.Rotate(0,-2,0);
		}
	}
}
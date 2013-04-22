using UnityEngine;
using System.Collections;

public class SkipToDestination_BTN : Window
{	
	private Vector3 zero = new Vector3(0,0,0);
	
	public bool ShowSkipBTN = false;
	
	void OnGUI()
	{
		UpdateStats();
		
		if (GUI.Button(WindowBox,Text,Controller.GetComponent<HUD>().GUI_Style))
		{
			Controller.GetComponent<Objects>().Player.transform.position = Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination;
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().velocity = zero;
		}
	}
}

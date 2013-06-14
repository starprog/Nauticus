using UnityEngine;
using System.Collections;

public class LookRight_BTN : Window
{
	
	public int DegreesToTurn; //how many degrees left it still needs to turn
int MaxDegrees = 45; //how many degrees it turns in total (rough amount)
	
	//Right
	void TurnSequence_Handler()
	{	
		//if(DegreesToTurn > 0)
		//{
			//Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().camera.transform.Rotate(0,3,0);
			//DegreesToTurn -= 1;
		//}
	}
	
	void OnGUI()
	{
		UpdateStats();
		//TurnSequence_Handler();
		if(Controller.GetComponent<State>().CurrentWaypoint() !=null)
		{
			if(Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint() &&
				Controller.GetComponent<State>().CurrentWaypoint().EndPoint == true &&
				GetComponent<HUD>().RoomOfInterestWindow_Toggle == false)
			{
				if (GUI.RepeatButton (WindowBox, Text,Controller.GetComponent<HUD>().GUI_Style_RightArrow))
				{
					Controller.GetComponent<HUD>().MenuShown = -1;
                    Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().camera.transform.Rotate(0, 3, 0);
					//DegreesToTurn = MaxDegrees;
					//Controller.GetComponent<LookLeft_BTN>().DegreesToTurn = 0;
				}
			}
		}
	}
}

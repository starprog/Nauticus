using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HUD : MonoBehaviour
{
	#region "Variables"
	protected GameObject Controller;
	public GUIText InactivityWarningMessage;//This is the GUI Text object
	public int BTN_X = 10;//The distance from the left side of the screen
	public int BTN_Y = 10;//The distance from the top of the screen
	public int BTN_Width = 100;//The width of the button
	public int BTN_Height = 50;//The height of the button
	public GUIStyle GUI_Style = new GUIStyle();
	public GUIStyle GUI_Style_Default_BTN = new GUIStyle();
	public GUIStyle GUI_Style_Default_BTN_Highlight = new GUIStyle();
	public GUIStyle GUI_Style_ObjectOfInterestBoilerPlate = new GUIStyle();
	public GUIStyle GUI_Style_LeftArrow = new GUIStyle();
	public GUIStyle GUI_Style_RightArrow = new GUIStyle();
	public GUIStyle GUI_Style_ObjectOfInterestWindow = new GUIStyle();
	public int MenuShown;
	public int MenuItems_0 = 0;
	public int MenuItems_1 = 0;
	public int MenuItems_2 = 0;
	public int MenuItems_3 = 0;
	public int MenuItems_4 = 0;
	
	private bool _ObjectOfInterestWindow_Toggle = false;
	#endregion
	
	#region "Methods"
	
	void Start()
	{
		Controller = GameObject.Find("Controller");	
	}
	
	void Update()
	{
		//Updates the text
		InactivityWarningMessage.text = ("Inactivity Timeout in " + Controller.GetComponent<State>().TimeOut + " Seconds");
		
		SkipToDestination_Handler();
		
		ObjectOfInterest_Handler();
		
		CurrentDeck_Handler();
	}
	
	public void ShowTimeOutWarning()
	{
		//Shows the Warning Message for InActivity
		InactivityWarningMessage.GetComponent<GUIText>().enabled = true;
	}
	
	public void HideTimeOutWarning()
	{
		//Hides the Warning Message for InActivity
		InactivityWarningMessage.GetComponent<GUIText>().enabled = false;
	}
	
	private void SkipToDestination_Handler()
	{
		if(Controller.GetComponent<State>().PrimaryTargetWaypoint() != null &&
			Controller.GetComponent<State>().CurrentWaypoint() != null)
		{
			if(Controller.GetComponent<State>().IsLooping == false &&
				Controller.GetComponent<State>().PrimaryTargetWaypoint().WithinZone() == false &&
				Controller.GetComponent<State>().CurrentWaypoint().EndPoint==false)
			{
					Controller.GetComponent<SkipToDestination_BTN>().enabled = true;	
			}
			else
			{
				Controller.GetComponent<SkipToDestination_BTN>().enabled = false;	
			}
				
		}
	}
		
	private void CurrentDeck_Handler()
	{
		if(Controller.GetComponent<State>().CurrentWaypoint() != null)
		{
			//MenuShown = Controller.GetComponent<State>().CurrentWaypoint().DeckIndex;	
		}
	}
	
	private void OnGUI()
	{
		int VerticalOffset_0 = 0;
		int VerticalOffset_1 = 0;
		int VerticalOffset_2 = 0;
		int VerticalOffset_3 = 0;
		int VerticalOffset_4 = 0;
		int VerticalOffset_Highlight = 0;
		
		switch(Controller.GetComponent<HUD>().MenuShown)
		{
		case 0: if(Controller.GetComponent<HUD>().MenuItems_0>0)
				{
				//VerticalOffset_0 += (Controller.GetComponent<HUD>().MenuItems_0-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_1 += (Controller.GetComponent<HUD>().MenuItems_0-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_2 += (Controller.GetComponent<HUD>().MenuItems_0-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_3 += (Controller.GetComponent<HUD>().MenuItems_0-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_4 += (Controller.GetComponent<HUD>().MenuItems_0-1) * Controller.GetComponent<HUD>().BTN_Height;
				}
			break;							
		case 1: if(Controller.GetComponent<HUD>().MenuItems_1>0)
				{
				//VerticalOffset_0 += (Controller.GetComponent<HUD>().MenuItems_1) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_1 += (Controller.GetComponent<HUD>().MenuItems_1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_2 += (Controller.GetComponent<HUD>().MenuItems_1-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_3 += (Controller.GetComponent<HUD>().MenuItems_1-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_4 += (Controller.GetComponent<HUD>().MenuItems_1-1) * Controller.GetComponent<HUD>().BTN_Height;
				}
			break;
		case 2: if(Controller.GetComponent<HUD>().MenuItems_2>0)
				{
				//VerticalOffset_0 += (Controller.GetComponent<HUD>().MenuItems_2) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_1 += (Controller.GetComponent<HUD>().MenuItems_2) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_2 += (Controller.GetComponent<HUD>().MenuItems_2) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_3 += (Controller.GetComponent<HUD>().MenuItems_2-1) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_4 += (Controller.GetComponent<HUD>().MenuItems_2-1) * Controller.GetComponent<HUD>().BTN_Height;
				}
			break;
		case 3: if(Controller.GetComponent<HUD>().MenuItems_3>0)
				{
				//VerticalOffset_0 += (Controller.GetComponent<HUD>().MenuItems_3) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_1 += (Controller.GetComponent<HUD>().MenuItems_3) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_2 += (Controller.GetComponent<HUD>().MenuItems_3) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_3 += (Controller.GetComponent<HUD>().MenuItems_3) * Controller.GetComponent<HUD>().BTN_Height;
				VerticalOffset_4 += (Controller.GetComponent<HUD>().MenuItems_3-1) * Controller.GetComponent<HUD>().BTN_Height;
				}
			break;
		case 4: if(Controller.GetComponent<HUD>().MenuItems_4>0)
				{
				//VerticalOffset_0 += (Controller.GetComponent<HUD>().MenuItems_4) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_1 += (Controller.GetComponent<HUD>().MenuItems_4) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_2 += (Controller.GetComponent<HUD>().MenuItems_4) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_3 += (Controller.GetComponent<HUD>().MenuItems_4) * Controller.GetComponent<HUD>().BTN_Height;
				//VerticalOffset_4 += (Controller.GetComponent<HUD>().MenuItems_4) * Controller.GetComponent<HUD>().BTN_Height;
				}
			break;
		default:
			break;
		}
				
		
		VerticalOffset_0 += 0*Controller.GetComponent<HUD>().BTN_Height;
		VerticalOffset_1 += 1*Controller.GetComponent<HUD>().BTN_Height;
		VerticalOffset_2 += 2*Controller.GetComponent<HUD>().BTN_Height;
		VerticalOffset_3 += 3*Controller.GetComponent<HUD>().BTN_Height;
		VerticalOffset_4 += 4*Controller.GetComponent<HUD>().BTN_Height;
		
				
		//VerticalOffset_0+=DeckIndex*Controller.GetComponent<HUD>().BTN_Height;
		
		if(	Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint() &&
			Controller.GetComponent<State>().CurrentWaypoint()!= null &&
			Controller.GetComponent<State>().CurrentWaypoint().EndPoint == true)
		{
		//Level 2
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_0,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Level 2",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 0;	
			}
		
		//Level 1
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_1,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Level 1",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 1;	
			}
		
		//Deck 1
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_2,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 1",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 2;	
			}
		
		//Deck 2
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_3,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 2",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 3;	
			}
		
		//Deck 3
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_4,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 3",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 4;	
			}
		
		
			if(Controller.GetComponent<State>().CurrentWaypoint() != null)
			{
				switch(Controller.GetComponent<State>().CurrentWaypoint().DeckIndex)
				{
				case 0: VerticalOffset_Highlight = VerticalOffset_0;
					break;
				case 1: VerticalOffset_Highlight = VerticalOffset_1;
					break;
				case 2: VerticalOffset_Highlight = VerticalOffset_2;
					break;
				case 3: VerticalOffset_Highlight = VerticalOffset_3;
					break;
				case 4: VerticalOffset_Highlight = VerticalOffset_4;
					break;
				}
				
				//Highlight
				if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
					Controller.GetComponent<HUD>().BTN_Y+VerticalOffset_Highlight,
					Controller.GetComponent<HUD>().BTN_Width,
					Controller.GetComponent<HUD>().BTN_Height),
					"",Controller.GetComponent<HUD>().GUI_Style_Default_BTN_Highlight))
					{
		
					}
			}
		}
	}
	
	#region "ObjectOfInterest"
	private void ObjectOfInterest_Handler()
	{
		ObjectOfInterestScanner();
		
		ObjectOfInterestWindow_Handler();
		
		if(Controller.GetComponent<State>().CurrentObjectOfInterest() !=null)
		{
			Controller.GetComponent<ObjectOfInterest_BoilerPlate>().enabled = true;
		}	
		else
		{
			Controller.GetComponent<ObjectOfInterest_BoilerPlate>().enabled = false;
		}
	}
	
	void ObjectOfInterestWindow_Handler()
	{
		if(_ObjectOfInterestWindow_Toggle == true)
		{
			Controller.GetComponent<ObjectOfInterest_Window>().enabled = true;
			Controller.GetComponent<Location_BoilerPlate>().enabled = false;
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Stop();
		}
		else
		{
			Controller.GetComponent<ObjectOfInterest_Window>().enabled = false;	
			Controller.GetComponent<Location_BoilerPlate>().enabled = true;
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Resume();
		}
	}
	
	public void LookAtTarget()
	{			
		Vector3 zero = new Vector3(0,0,0);
		Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().speed = 0f;
		Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = Controller.GetComponent<State>().CurrentWaypoint().LookTarget.transform.position;
	}
	
	void ObjectOfInterestScanner()
	{
		float distance = 10;

		Vector3 CameraCenter = (new Vector3(Screen.width/2, Screen.height/2, Controller.GetComponent<Objects>().Player.GetComponent<Camera>().nearClipPlane));
		Ray ray = Controller.GetComponent<Objects>().Player.GetComponent<Camera>().ScreenPointToRay(CameraCenter);
		RaycastHit hit = new RaycastHit();
		
		if (Physics.Raycast (ray, out hit, distance))
		{			
			if(hit.collider.gameObject.GetComponent<ObjectOfInterest>()!=null)
			{
				Controller.GetComponent<State>().CurrentObjectOfInterest(hit.collider.gameObject);	
			}
			else
			{
				Controller.GetComponent<State>().CurrentObjectOfInterest(null);
			}
		}
	}
	#endregion
	
	#region "Getter and Setter"
	
	public bool ObjectOfInterestWindow_Toggle()
	{
		return _ObjectOfInterestWindow_Toggle;	
	}
	
	public void ObjectOfInterestWindow_Toggle(bool ObjectOfInterestWindow_Toggle)
	{
		_ObjectOfInterestWindow_Toggle = ObjectOfInterestWindow_Toggle;	
	}
	
	#endregion
	
	#endregion
}


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
	public GUIStyle GUI_Style_ObjectOfInterestBoilerPlate = new GUIStyle();
	public GUIStyle GUI_Style_LeftArrow = new GUIStyle();
	public GUIStyle GUI_Style_RightArrow = new GUIStyle();
	public GUIStyle GUI_Style_ObjectOfInterestWindow = new GUIStyle();
	public int MenuShown;
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
		
		Look_BTN_Handler();
		
		ObjectOfInterest_Handler();
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
		if(Controller.GetComponent<State>().TargetWaypoint() != null)
		{
			if(Controller.GetComponent<SkipToDestination_BTN>().ShowSkipBTN == true && Controller.GetComponent<State>().TargetWaypoint().WithinZone() == false)
			{
				Controller.GetComponent<SkipToDestination_BTN>().enabled = true;	
			}
			else
			{
				Controller.GetComponent<SkipToDestination_BTN>().enabled = false;	
			}
		}
	}
	
	private void Look_BTN_Handler()
	{
		if(Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint() &&
			Controller.GetComponent<State>().MovementCheck() == false)
		{
			Controller.GetComponent<LookLeft_BTN>().enabled = true;
			Controller.GetComponent<LookRight_BTN>().enabled = true;
		}
		else
		{
			Controller.GetComponent<LookLeft_BTN>().enabled = false;
			Controller.GetComponent<LookRight_BTN>().enabled = false;	
		}
	}
	
	private void OnGUI()
	{
		//Level 2
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+0*Controller.GetComponent<HUD>().BTN_Height,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Level 2",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 0;	
			}
		
		//Level 1
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+1*Controller.GetComponent<HUD>().BTN_Height,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Level 1",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 1;	
			}
		
		//Deck 1
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+2*Controller.GetComponent<HUD>().BTN_Height,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 1",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 2;	
			}
		
		//Deck 2
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+3*Controller.GetComponent<HUD>().BTN_Height,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 2",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 3;	
			}
		
		//Deck 3
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X,
			Controller.GetComponent<HUD>().BTN_Y+4*Controller.GetComponent<HUD>().BTN_Height,
			Controller.GetComponent<HUD>().BTN_Width,
			Controller.GetComponent<HUD>().BTN_Height),
			"Deck 3",Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
			{
				MenuShown = 4;	
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
		}
		else
		{
			Controller.GetComponent<ObjectOfInterest_Window>().enabled = false;	
			Controller.GetComponent<Location_BoilerPlate>().enabled = true;
		}
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


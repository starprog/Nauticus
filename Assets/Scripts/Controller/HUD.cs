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
		if(Controller.GetComponent<SkipToDestination_BTN>().ShowSkipBTN == true)
		{
			Controller.GetComponent<SkipToDestination_BTN>().enabled = true;	
		}
		else
		{
			Controller.GetComponent<SkipToDestination_BTN>().enabled = false;	
		}
	}
	
	private void ObjectOfInterest_Handler()
	{
		ObjectOfInterestScanner();
		
		if(Controller.GetComponent<State>().CurrentObjectOfInterest() !=null)
		{
			Controller.GetComponent<ObjectOfInterest_BoilerPlate>().enabled = true;
		}	
		else
		{
			Controller.GetComponent<ObjectOfInterest_BoilerPlate>().enabled = false;
		}
	}
	
	void ObjectOfInterestScanner()
	{
		float distance = Mathf.Infinity;

		Vector3 CameraCenter = (new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane));
		Ray ray = Camera.main.ScreenPointToRay(CameraCenter);
		RaycastHit hit = new RaycastHit();
		
		if (Physics.Raycast (ray, out hit, distance))
		{			
			if(hit.collider.gameObject.GetComponent<ObjectOfInterest>()!=null)
			{
				Controller.GetComponent<State>().CurrentObjectOfInterest(hit.collider.gameObject);	
			}
		}
	}
	#endregion
}


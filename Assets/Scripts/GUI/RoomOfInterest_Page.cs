using UnityEngine;
using System.Collections;

	
	public class RoomOfInterest_Page : MonoBehaviour
	{		
	protected GameObject Controller;
	public bool HomePage = false;
	public int PrimaryWaypointIndex;
	public int PageIndex;
	public string Title;
	public Texture2D Image;
	//public string Description;
	public float Margin = 50f;
	public bool HasBTN = false;
		
	void Start()
	{
		Controller = GameObject.Find("Controller");
		
		Controller.GetComponent<Objects>().RoomOfInterestCollection.Add(this);	
	}
	
	}


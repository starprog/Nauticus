using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour
{
	#region "Variables"
	protected GameObject Controller;
	public string Name;//Set this = to the name of the waypoint
	public int Index;//Set this = to the order position of this waypoint
	public int DeckIndex;
	public int MenuIndex;//Set this = to the position on the menu where the button should be placed. Note: Do not overlap otherwise, one will be hidden
	public bool HasButton=true;//Set this to true if a button is to be displayed on the menu
	public bool PrimaryWaypoint = false;
	public bool Loop = true;
	public bool EndPoint = false;
	public Waypoint LoopTarget = null;
	public GameObject LookTarget = null;
	public AudioClip Dialog;//set this = to the dialog to play when the player enters the waypoint trigger zone
	public string LocationInformation;
	private bool _WithinZone = false;
	
	private List<Waypoint> _Paths = new List<Waypoint>();
	public Waypoint Path0;
	public Waypoint Path1;
	public Waypoint Path2;
	public Waypoint Path3;
	public Waypoint Path4;
	public Waypoint Path5;
	public Waypoint Path6;
	public Waypoint Path7;
	public Waypoint Path8;
	#endregion
	
	#region "Methods"
	
	#region "Initialize"
	void Start ()
	{			
		Controller = GameObject.Find("Controller");
		
		//Pushes the Waypoint
		PushWaypoint();
				
		//Reorders the Waypoint Collection
		Reorder();
		
		//Pushes the Paths
		PushPaths();
		
		UpdateMenuItems();
		
		//Turns the waypoint invisible
		GetComponent<MeshRenderer>().enabled = false;
		
		//Sets the dialog
		audio.clip = Dialog;
	}
	
	void UpdateMenuItems()
	{
		//Checks to see if the waypoint should have a button created on the menu
		if (HasButton==true)
		{
			switch(DeckIndex)
			{
			case 0: Controller.GetComponent<HUD>().MenuItems_0 += 1;
				break;
			case 1: Controller.GetComponent<HUD>().MenuItems_1 += 1;
				break;
			case 2: Controller.GetComponent<HUD>().MenuItems_2 += 1;
				break;
			case 3: Controller.GetComponent<HUD>().MenuItems_3 += 1;
				break;
			case 4: Controller.GetComponent<HUD>().MenuItems_4 += 1;
				break;
			}
		}
	}
	
	void PushPaths()
	{
		_Paths.Add(Path0);
		_Paths.Add(Path1);	
		_Paths.Add(Path2);
		_Paths.Add(Path3);
		_Paths.Add(Path4);
		_Paths.Add(Path5);
		_Paths.Add(Path6);
		_Paths.Add(Path7);
		_Paths.Add(Path8);
	}
	
	void PushWaypoint()
	{
		//sets the name of the waypoint. ex: "0WardroomWaypoint"
		this.name = (Index +"_"+ this.Name +"_"+"Waypoint").ToString().ToUpper();
		
		//sets count = to the difference of however many are needed to support this waypoint and how many already exist
		//I needed to change it to a new variable because in the for loop it calls .Count each iteration causing fewer waypoints to be created than required
		int count = Index-Controller.GetComponent<Follow>().WaypointCollection().Count;
		
		//Creates waypoints
		for(int x=0;x<=count;x++)
		{
			Controller.GetComponent<Follow>().WaypointCollection().Add(this);
		}

		bool found = false;
		
		//searches through the waypoints and if this waypoint is not already in the collection,
		//it will assign this waypoint to the appropriate index
		for(int i=0;i<Controller.GetComponent<Follow>().WaypointCollection().Count;i++)
		{
			if(Controller.GetComponent<Follow>().WaypointCollection()[i].Index == Index)
			{
				found = true;
			}
		}
		
		
		if(found == false)
		{
			Controller.GetComponent<Follow>().WaypointCollection()[Index] = this;
		}
		
	}
	
	void Reorder()
	{
		//Defines count as the current number of items in the waypointcollection
		int count = Controller.GetComponent<Follow>().WaypointCollection().Count;
		
		//Used to hold the temporary waypoints
		List <Waypoint> TempWaypointCollection = new List<Waypoint>();
		
		//Creates temporary Waypoints to use when reordering the List
		for(int i=0;i<count;i++)
		{
			Waypoint TempWaypoint = Controller.GetComponent<Follow>().WaypointCollection()[i];

			TempWaypointCollection.Add(TempWaypoint);
		}
		
		//Handles the reordering process of WaypointCollection in relation to Waypoint.Index
		for(int i=0;i<count;i++)
		{			
			for(int x=0;x<count;x++)
			{				
				//Checks to see if WaypointCollection index is equal to the current TempWaypoint's Index.
				if(i==TempWaypointCollection[x].Index)
				{
					//Reorders the actual WaypointCollection according to the .Index of each Waypoint
					Controller.GetComponent<Follow>().ReorderWaypointCollection(TempWaypointCollection,x,i); 
				}
			}
			
		}
		
		//Clears the Temporary Collection now that it isn't needed.
		TempWaypointCollection.Clear();
	}
	#endregion
	
	void Update ()
	{

	}
	
	#region "Triggers"
	//Handles everything that happens when the player enters the waypoint zone
	void OnTriggerEnter(Collider other)
	{
		if(LookTarget != null)
		{
			Controller.GetComponent<State>().CurrentWaypoint(this);
			Controller.GetComponent<HUD>().LookAtTarget();	
		}
		
		Controller.GetComponent<SkipToDestination_BTN>().ShowSkipBTN = false;
				
		//Plays the dialog audio clip associated with this waypoint zone
		PlayDialog();
	}
	
	void OnTriggerStay(Collider other)
	{
		//Sets the current waypoint to this waypoint
		Controller.GetComponent<State>().CurrentWaypoint(this);
		
		_WithinZone = true;
		

		
		if(Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint())
		{
			CheckLoop();
		}
	}
		
	
	
	//Handles everything that happens when the player leaves the waypoint zone
	void OnTriggerExit(Collider other)
	{
		if(Controller.GetComponent<Follow>().HasAutomaticPathfinding == true)
		{
			_WithinZone = false;
		}
		
		//Player is Active
		Controller.GetComponent<State>().Active();
	}
	
	void CheckLoop()
	{
		//Makes sure the loop target exists, loop is true

		if(LoopTarget == null && PrimaryWaypoint == false && Loop == false && EndPoint == false)
		{
			Controller.GetComponent<Follow>().SetNewDestination(_Paths[Controller.GetComponent<State>().PrimaryTargetWaypoint().Index].Index);
		}
		else if(LoopTarget != null)
		{
			Controller.GetComponent<Follow>().SetNewDestination(LoopTarget.Index);
		}
	}
	
	#region "Dialog"
	
	void PlayDialog()
	{
		//Checks to see if there is a dialog to play and if it's not currently playing
		if(Dialog != null)
		{
			audio.Play();
		}
		
	}
	#endregion
	
	#endregion
	
	#region "Get and Set"
	public bool WithinZone()
	{
		return _WithinZone;	
	}
	
	public void WithinZone(bool WithinZone)
	{
		_WithinZone = WithinZone;	
	}
	#endregion
	
	#region "GUI"
	void OnGUI ()
	{
		//Checks to see if the waypoint should have a button created on the menu
		if (HasButton==true)
		{
		
			int VerticalOffset = 0;
		
			VerticalOffset+=DeckIndex*Controller.GetComponent<HUD>().BTN_Height;
			VerticalOffset+=MenuIndex*Controller.GetComponent<HUD>().BTN_Height;
				
			if(	Controller.GetComponent<State>().CurrentWaypoint() == Controller.GetComponent<State>().TargetWaypoint() &&
				Controller.GetComponent<State>().CurrentWaypoint()!= null &&
				Controller.GetComponent<State>().CurrentWaypoint().EndPoint == true)
			{
				//Handles the deck level menu
				if(Controller.GetComponent<HUD>().MenuShown == DeckIndex)
				{
					//Creates a button based off of the dimensions of the HUD class
					if (GUI.Button (new Rect (Controller.GetComponent<HUD>().BTN_X+Controller.GetComponent<HUD>().BTN_Width,
						Controller.GetComponent<HUD>().BTN_Y+VerticalOffset,
						Controller.GetComponent<HUD>().BTN_Width,
						Controller.GetComponent<HUD>().BTN_Height),
						Name,Controller.GetComponent<HUD>().GUI_Style_Default_BTN))
						{
							Controller.GetComponent<HUD>().MenuShown = -1;
							Controller.GetComponent<SkipToDestination_BTN>().ShowSkipBTN = true;
							//Loop = true;
							//On Click will set the destination of the player to this waypoint
							Debug.Log("Waypoint: Setting Destination to Waypoint: " + Name);
							Controller.GetComponent<State>().PrimaryTargetWaypoint(this);	
							Controller.GetComponent<Follow>().PathWaypointNavigate();
							
						}
				}
			}
		}
	}
	#endregion
	
	public List<Waypoint> Paths()
	{
		return _Paths;	
	}
	
	#endregion
}

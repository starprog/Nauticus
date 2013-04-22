using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour
{	
	#region "Variables"
	protected GameObject Controller;
	public bool HasAutomaticPathfinding = true;
	
	private List<Waypoint> _WaypointCollection = new List<Waypoint>();	
	#endregion
	
	#region "Methods"
	
	#region "Initialize"
	private void Start()
	{
		Controller = GameObject.Find("Controller");
		
		//Enabled the components that allow the player to move and look on their own
		//***Use this for Walking freely on the ship***
		if (HasAutomaticPathfinding==false)
		{
			Controller.GetComponent<Objects>().Player.GetComponent<CharacterMotor>().enabled = true;
			Controller.GetComponent<Objects>().Player.GetComponent<FPSInputController>().enabled = true;
			Controller.GetComponent<Objects>().Player.GetComponent<MouseLook>().enabled = true;
		}
	}
	#endregion
	
	
	//Used for reordering the waypoint collection.
	//Parameters
	//(Send the TempWaypointCollection,
	//the index of the element of the WaypointCollection,
	//and the Index of the TempWaypointCollection Element to assign to the WaypointCollection)
	public void ReorderWaypointCollection(List<Waypoint> TempWaypointCollection,int newindex,int index)
	{
		_WaypointCollection[index] = TempWaypointCollection[newindex];
	}
	
	public List<Waypoint> WaypointCollection()
	{
		return _WaypointCollection;	
	}
	
	public void SetNewDestination(int WaypointDestinationIndex)
	{
		if(HasAutomaticPathfinding == true)
		{
			//Sets the destination
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = _WaypointCollection[WaypointDestinationIndex].transform.position;
		}
	}
	#endregion
}

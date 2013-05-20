using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour
{	
	#region "Variables"
	protected GameObject Controller;
	public bool HasAutomaticPathfinding = true;
	
	public List<Waypoint> _WaypointCollection = new List<Waypoint>();	
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
			Controller.GetComponent<State>().CurrentWaypoint(_WaypointCollection[0]);			
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
			if(Controller.GetComponent<State>().CurrentWaypoint().LoopTarget != null && Controller.GetComponent<State>().CurrentWaypoint().PrimaryWaypoint == true)
			{
				PrimaryWaypointNavigate();
			}	
			else if(Controller.GetComponent<State>().CurrentWaypoint().LoopTarget != null && Controller.GetComponent<State>().CurrentWaypoint().PrimaryWaypoint == false)
			{
				LoopWaypointNavigate();
			}
			else if(Controller.GetComponent<State>().CurrentWaypoint().LoopTarget == null && Controller.GetComponent<State>().CurrentWaypoint().PrimaryWaypoint == false)
			{
				PathWaypointNavigate();
			}

			
			if(Controller.GetComponent<State>().TargetWaypoint().Loop == true && Controller.GetComponent<State>().TargetWaypoint().PrimaryWaypoint == false)
			{
				Controller.GetComponent<State>().IsLooping = true;
			}
			else
			{
				Controller.GetComponent<State>().IsLooping = false;
			}
			
			Debug.Log("Target = "+Controller.GetComponent<State>().TargetWaypoint().Name);
		}
	}
	
	private void PrimaryWaypointNavigate()
	{
		Controller.GetComponent<State>().TargetWaypoint(Controller.GetComponent<State>().CurrentWaypoint().LoopTarget);
		Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = Controller.GetComponent<State>().TargetWaypoint().transform.position;
	}
	
	private void LoopWaypointNavigate()
	{
		Controller.GetComponent<State>().TargetWaypoint(Controller.GetComponent<State>().CurrentWaypoint().LoopTarget);
		Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = Controller.GetComponent<State>().TargetWaypoint().transform.position;
	}
	
	public void PathWaypointNavigate()
	{
		Controller.GetComponent<State>().TargetWaypoint(Controller.GetComponent<State>().CurrentWaypoint().Paths()[Controller.GetComponent<State>().PrimaryTargetWaypoint().Index]);
		Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = Controller.GetComponent<State>().TargetWaypoint().transform.position;
	}
	
	#endregion
}

using UnityEngine;
using System.Collections;

public class State : MonoBehaviour
{
	#region "Variables"
	protected GameObject Controller;
	public bool HasTimeOut = true;//Set this if an Inactivity Timer should be active
	public int TimeOut = 60;//The amount of time of inactivity before the game reverts back to the home screen
	public int TimeOutWarning = 15;//At this time, the player will get notified that they must act or be reset
	
	public bool IsLooping = false;
	
	private int MaxTimeOut;
	private Vector3 _OldPos;
	private Vector3 _CurrentPos;
	private Vector2 _OldCursorPos;
	private Vector2 _CurrentCursorPos;
	private Quaternion _OldRotation;
	private Quaternion _CurrentRotation;
	
	
	private Waypoint _CurrentWaypoint;
	private Waypoint _TargetWaypoint;
	private Waypoint _PrimaryTargetWaypoint;
	private GameObject _CurrentObjectOfInterest;
	
	private string _CurrentState;
	private const string ACTIVE = "ACTIVE";
	private const string INACTIVE = "INACTIVE";
	private const string TIMEDOUT = "TIMEDOUT";
	
	bool FirstRunSetup = true;
	int FirstRunSetupCounter = 0;
	#endregion
	
	#region "Methods"
	
	#region "Initialize"
	private void Start()
	{
		Controller = GameObject.Find("Controller");
		
		if(HasTimeOut==true)
		{
			InitializeTimeOut();
		}
		
	}
	#endregion
	
	private void Update ()
	{
		if(HasTimeOut==true)
		{			
			TimeOutStateCheck();
		}
		
		ActivityCheck();
		
		IsLooping_Handler();
		
		FirstRunSetupCounter += 1;
		if(FirstRunSetup == true && FirstRunSetupCounter%50 == 0)
		{
			Controller.GetComponent<State>().PrimaryTargetWaypoint(Controller.GetComponent<Follow>().WaypointCollection()[0]);
			Controller.GetComponent<State>().TargetWaypoint(Controller.GetComponent<Follow>().WaypointCollection()[0]);
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().destination = Controller.GetComponent<Follow>().WaypointCollection()[0].transform.position;	
			FirstRunSetup = false;
		}
	}
	
	void IsLooping_Handler()
	{
		if(IsLooping == true)
		{
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().speed = 3f;	
		}
		else
		{
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().speed = 4f;	
		}
	}
	
	#region "TimeOut"
	
	#region "Checks for Activity"
	
	private void ActivityCheck()
	{
		//Definition List:
		//MovementCheck() = If the player is currently moving
		//DialogCheck() = If the last waypoint the player was at is still playing dialog
		//CameraRotationCheck() = if the player's camera has rotated
		
		//Tests all checks to see if the player is active
		if(MovementCheck() == true || DialogCheck() == true || CameraRotationCheck() == true || CursorMovementCheck() == true)
		{
			Active();
		}
		else
		{
			Inactive();	
		}
	}
	
	public bool CursorMovementCheck()
	{
		_CurrentCursorPos = Input.mousePosition;
		
		//Checks the OldCursorPos against the current CursorPos
		if(_OldCursorPos == _CurrentCursorPos)
		{
			_OldCursorPos = _CurrentCursorPos;
			return false;	
		}
		else
		{
			_OldCursorPos = _CurrentCursorPos;
			return true;	
		}
	}
	
	public bool CameraRotationCheck()
	{
		_CurrentRotation = Controller.GetComponent<Objects>().Player.GetComponent<Camera>().transform.rotation;
		
		//Checks the OldRotation against the current Rotation
		if(_OldRotation == _CurrentRotation)
		{
			_OldRotation = _CurrentRotation;
			return false;	
		}
		else
		{
			_OldRotation = _CurrentRotation;
			return true;	
		}
	}
	
	public bool MovementCheck()
	{
		_CurrentPos = Controller.GetComponent<Objects>().Player.transform.position;
		
		//Checks the OldPosition against the current Position
		if(_OldPos == _CurrentPos)
		{
			_OldPos = _CurrentPos;
			return false;	
		}
		else
		{
			_OldPos = _CurrentPos;
			return true;	
		}
	}
	
	private bool DialogCheck()
	{		
		//Checks if the current waypoint is playing dialog
		if(_CurrentWaypoint!=null && _CurrentWaypoint.audio.isPlaying == true)
		{
			return true;	
		}
		else
		{
			return false;	
		}
		
	}
	
	#endregion
	
	private void InitializeTimeOut()
	{			
		//Initializes MaxTimeOut to = Timeout
		MaxTimeOut = TimeOut;
		
		//Causes the TimeOutCounter to begin ticking every 1 second
		InvokeRepeating("TimeOutCount", 0, 1);
	}
	
	void TimeOutStateCheck()
	{
		//Checks to see if the the player has been inactive long enough to show a warning
		if(TimeOut <= TimeOutWarning)
		{
			//Displays a Warning Message for InActivity
			Controller.GetComponent<HUD>().ShowTimeOutWarning();
		}
		else
		{
			Controller.GetComponent<HUD>().HideTimeOutWarning();	
		}
		
		//Checks to see if there is an inactivity timeout
		if(TimeOut == 0)
		{
			TimedOut();
		}
		
		switch(_CurrentState)
			{
				//Resets the TimeOutCount if the player is ACTIVE
				case ACTIVE:ResetTimeOutCount();
					break;
				
				//If something is needed on INACTIVE, place that code below
				//case INACTIVE: ;
				//	break;
				
				case TIMEDOUT: ResetGame();
					break;
			}
	}
	
	void TimeOutCount()
	{
		//Subtracts 1 second from TimeOut
		TimeOut-=1;
		
		//Trace
		Debug.Log("STATE: TimeOutCount: " + TimeOut);
	}
	
	public void ResetTimeOutCount()
	{		
		//Hides the Warning Message for InActivity
		Controller.GetComponent<HUD>().HideTimeOutWarning();
		
		//Resets the TimeOutCounter back to the start
		TimeOut	= MaxTimeOut;
	}
	
	public void ResetGame()
	{
		Application.LoadLevel(0);
	}
	#endregion
	
	#region "Getters and Setters"
	//Set
	public void Active()
	{		
		//Sets Current State to Active
		_CurrentState = ACTIVE;
	}
	
	public void Inactive()
	{		
		//Sets Current State to Inactive
		_CurrentState = INACTIVE;	
	}
	
	public void TimedOut()
	{
		//Sets Current State to Inactive
		_CurrentState = TIMEDOUT;
		
	}
		
	public string CurrentState()
	{
		return _CurrentState;	
	}
	
	public void CurrentWaypoint(Waypoint CurrentWaypoint)
	{
		_CurrentWaypoint = CurrentWaypoint;
	}
	
	public Waypoint CurrentWaypoint()
	{
		return _CurrentWaypoint;	
	}
	
	public void TargetWaypoint(Waypoint TargetWaypoint)
	{
		_TargetWaypoint = TargetWaypoint;
	}
	
	public Waypoint TargetWaypoint()
	{
		return _TargetWaypoint;	
	}
	
	public void PrimaryTargetWaypoint(Waypoint PrimaryTargetWaypoint)
	{
		_PrimaryTargetWaypoint = PrimaryTargetWaypoint;
	}
	
	public Waypoint PrimaryTargetWaypoint()
	{
		return _PrimaryTargetWaypoint;	
	}

	public void CurrentObjectOfInterest(GameObject CurrentObjectOfInterest)
	{
		_CurrentObjectOfInterest = CurrentObjectOfInterest;
	}
	
	public GameObject CurrentObjectOfInterest()
	{
		return _CurrentObjectOfInterest;	
	}
	#endregion
	
	#endregion
}

using UnityEngine;
using System.Collections;

	
	public class RoomOfInterest_Window : Window
	{		
	
	public GUIStyle WindowStyle = new GUIStyle();
	
	private float Title_X;
	private float Title_Y;
	private float Title_Width;
	private float Title_Height;
	public GUIStyle TitleStyle = new GUIStyle();
	
	private float ExitBTN_X;
	private float ExitBTN_Y;
	private float ExitBTN_Width;
	private float ExitBTN_Height;
	public GUIStyle ExitBTNStyle = new GUIStyle();
	
	private float Image_X;
	private float Image_Y;
	private float Image_Width;
	private float Image_Height;
	public GUIStyle ImageStyle = new GUIStyle();
	
	private float Desc_X;
	private float Desc_Y;
	private float Desc_Width;
	private float Desc_Height;
	public GUIStyle DescStyle = new GUIStyle();
	
	private float BTN_X;
	private float BTN_Y;
	private float BTN_Width;
	private float BTN_Height;
	public GUIStyle BTNStyle = new GUIStyle();
	public GUIStyle BTNStyle_Highlighted = new GUIStyle();
	
	public int Margin = 25;
	public int SmallMargin = 15;
	
		void OnGUI()
		{	
			UpdateStats();
		
			UpdateVariables();
		
			HideLocationBoilerPlate_Handler();
		
			if(Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle == true && Controller.GetComponent<State>().CurrentRoomOfInterest_Page != null)
			{
			
			//stops navigation
			Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Stop();
			
			UpdateStyle();
			
			//Window
			GUI.Box(WindowBox,"",WindowStyle);
			
			//Image
			GUI.Box(new Rect(Image_X,Image_Y,Image_Width,Image_Height),"",ImageStyle);
			
			//ExitBTN
			if(GUI.Button(new Rect(ExitBTN_X,ExitBTN_Y,ExitBTN_Width,ExitBTN_Height),"",ExitBTNStyle))
			{
				Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle = false;	
			}
						
			//Buttons
			int count = Controller.GetComponent<Objects>().RoomOfInterestCollection.Count;
			
				for(int i=0;i<count;i++)
				{
					if(Controller.GetComponent<State>().PrimaryTargetWaypoint().Index == Controller.GetComponent<Objects>().RoomOfInterestCollection[i].PrimaryWaypointIndex &&
					Controller.GetComponent<Objects>().RoomOfInterestCollection[i].HasBTN == true &&
					Controller.GetComponent<State>().CurrentRoomOfInterest_Page != Controller.GetComponent<Objects>().RoomOfInterestCollection[i]&&
                    Controller.GetComponent<State>().CurrentRoomOfInterest_Page.ItemIndex <0)
					{
						if(GUI.Button(new Rect(BTN_X + (Controller.GetComponent<Objects>().RoomOfInterestCollection[i].PageIndex * (BTN_Width + SmallMargin)),BTN_Y,BTN_Width,BTN_Height),"",BTNStyle))
						{
							Controller.GetComponent<State>().CurrentRoomOfInterest_Page = Controller.GetComponent<Objects>().RoomOfInterestCollection[i];
						}
					}
				}
			
			}
			else
			{
			//Resumes navigation
				Controller.GetComponent<Objects>().Player.GetComponent<NavMeshAgent>().Resume();	
			}
		
		}
	
	void UpdateStyle()
	{
		ImageStyle.normal.background = Controller.GetComponent<State>().CurrentRoomOfInterest_Page.Image;	
	}
	
	void UpdateVariables()
	{
		Title_Width = WindowBox.width*0.5f;
		Title_Height = WindowBox.height*0.1f;
		Title_X = WindowBox.x +Title_Width/2;
		Title_Y = WindowBox.y + Margin;
		
		ExitBTN_Width = WindowBox.width*0.055f;
		ExitBTN_Height = ExitBTN_Width;
		ExitBTN_X = WindowBox.x + WindowBox.width - ExitBTN_Width-SmallMargin;
		ExitBTN_Y = WindowBox.y+SmallMargin;
		
		Image_Width = WindowBox.width;
		Image_Height = WindowBox.height;
		Image_X = WindowBox.x;
		Image_Y = WindowBox.y;
		
		Desc_Width = WindowBox.width - (Margin * 2);
		Desc_Height = WindowBox.height*0.3f-(Margin * 2);
		Desc_X = WindowBox.x+Margin;
		Desc_Y = Image_Y + Image_Height + SmallMargin;
		
		BTN_Width = WindowBox.width * 0.1f + Margin;
		BTN_Height = BTN_Width/3;
		BTN_X = WindowBox.x+WindowBox.width-Margin-BTN_Width;
		BTN_Y = WindowBox.y + WindowBox.height - Margin-BTN_Height;
	}
	
	void HideLocationBoilerPlate_Handler()
	{
		if(Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle == true)
		{
			Controller.GetComponent<Location_BoilerPlate>().Location_BolierPlate_Toggle = false;	
		}
		else
		{
			Controller.GetComponent<Location_BoilerPlate>().Location_BolierPlate_Toggle = true;	
		}
	}
	
	}


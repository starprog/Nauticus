using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour
{
	protected GameObject Controller;
	
	public string Text;
	
	public string DockedX;
	public string DockedY;
		
	public string SquareBy = "NONE";
	
	public float Window_Width;
	public float Window_Height;
	
	public float Window_X;
	public float Window_Y;
	
	protected Rect WindowBox = new Rect(0,0,0,0);
	
	void Start()
	{
		Controller = GameObject.Find("Controller");
		InitializeWindow();	
	}
	
	public void InitializeWindow()
	{		
		CheckSquareBy();
	}
	
	public void CheckSquareBy()
	{
		//Checks to see if the width or height is to be squared. If this is set to Width and the Height is at a value of 15, Then it will act as an aspect ratio.
		switch(SquareBy)
		{
		case "WIDTH":
			Window_Width=Screen.width*Window_Width/100;
			Window_Height=Screen.width*Window_Height/100;
			break;
			
		case "HEIGHT":
			Window_Width=Screen.height*Window_Width/100;
			Window_Height=Screen.height*Window_Height/100;
			break;
			
		default:
			Window_Width=Screen.width*Window_Width/100;
			Window_Height=Screen.height*Window_Height/100;
			break;
		}
	}
	
	public void UpdateStats()
	{
		//Checks the Dock X and Y settings
		Window_X=DockX(DockedX);
		Window_Y=DockY(DockedY);
		
		//Sets the WindowBox settings
		WindowBox.x = Window_X;
		WindowBox.y = Window_Y;
		WindowBox.width = Window_Width;
		WindowBox.height = Window_Height;
	}
	
	public void OnGUI()
	{
		UpdateStats();
		
		GUI.Box(WindowBox,Text);
	}
	
	public float DockX(string DockedX)
	{
		float Window_X = 0f;
			
		switch(DockedX)
		{
			case "LEFT":
				Window_X = 0f;
				break;

			case "RIGHT":
				Window_X = Screen.width - Window_Width;
				break;
			
			case "CENTER":
				Window_X = Screen.width/2 - Window_Width/2;
				break;
			
			default:
				Window_X = 0;
				break;
		}	
		
		return Window_X;
	}
	
	public float DockY(string DockedY)
	{
		float Window_Y = 0f;
			
		switch(DockedY)
		{
			case "TOP":
				Window_Y = 0f;
				break;
			
			case "BOTTOM":
				Window_Y = Screen.height - Window_Height;
				break;
			
			case "CENTER":
				Window_Y = Screen.height/2 - Window_Height/2;
				break;
			
			default:
				Window_Y = 0;
				break;
		}
		
		return Window_Y;
	}
}

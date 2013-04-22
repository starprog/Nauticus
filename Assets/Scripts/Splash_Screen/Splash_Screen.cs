using UnityEngine;
using System.Collections;

public class Splash_Screen : MonoBehaviour
{
	public int BTN_Width = 100;
	public int BTN_Height = 100;
	public string BTN_Text = "Click to Start";
	
	private int _BTN_X;
	private int _BTN_Y;
	
	// Use this for initialization
	void Start ()
	{
		_BTN_X = Screen.width/2-BTN_Width/2;
		_BTN_Y = Screen.height/2-BTN_Height/2;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnGUI()
	{
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (_BTN_X,
			_BTN_Y,
			BTN_Width,
			BTN_Height),
			BTN_Text))
			{
				Application.LoadLevel(1);
			}
	}
}

using UnityEngine;
using System.Collections;

public class Splash_Screen : MonoBehaviour
{
	public int BTN_Width = 100;
	public int BTN_Height = 100;
	public string BTN_Text = "Click to Start";
	public GUIStyle SplashStyle = new GUIStyle();
	private int _BTN_X;
	private int _BTN_Y;
	public GameObject MovieScreen;
	public MovieTexture SplashMovie;
	// Use this for initialization
	void Start ()
	{
		_BTN_X = Screen.width/2-BTN_Width/2;
		_BTN_Y = Screen.height/2-BTN_Height/2;
		
		MovieScreen.GetComponent<MeshRenderer>().materials[0].mainTexture = SplashMovie;
		//MovieScreen.GetComponent<MeshRenderer>().material.mainTexture.Loop= true;;
		SplashMovie.loop = true;
		SplashMovie.Play();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnGUI()
	{			
		//Creates a button based off of the dimensions of the HUD class
		if (GUI.Button (new Rect (0,0,Screen.width,Screen.height),BTN_Text,SplashStyle))
			{
				Application.LoadLevel(1);
			}
	}
}

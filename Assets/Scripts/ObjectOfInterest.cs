using UnityEngine;
using System.Collections;

public class ObjectOfInterest : MonoBehaviour {
	protected GameObject Controller;

    public int Index;

	void Start()
	{
		Controller = GameObject.Find("Controller");	
	}
	
	void OnMouseDown()
	{
        int count = Controller.GetComponent<Objects>().RoomOfInterestCollection.Count;
        for (int i = 0; i < count; i++)
        {
            if (Controller.GetComponent<Objects>().RoomOfInterestCollection[i].ItemIndex == Index)
            {
                Controller.GetComponent<State>().CurrentRoomOfInterest_Page = Controller.GetComponent<Objects>().RoomOfInterestCollection[i];
            }
        }

		Controller.GetComponent<HUD>().RoomOfInterestWindow_Toggle = true;	
		Debug.Log("test");
	}
}

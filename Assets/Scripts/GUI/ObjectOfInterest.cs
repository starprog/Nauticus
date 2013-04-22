using UnityEngine;
using System.Collections;
using System;
public class ObjectOfInterest : MonoBehaviour
{
	
	protected GameObject Controller;
	public GameObject ReferenceObject;	
	
	public string Name;
	public string Information;
	
	// Use this for initialization
	void Start ()
	{
		Controller = GameObject.Find("Controller");
		PushObject();
	}
	
	private void PushObject()
	{
		Controller.GetComponent<Objects>().ObjectOfInterestCollection.Add(ReferenceObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
}

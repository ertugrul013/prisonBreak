using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	public int Id;
	private bool IsOpen;
	private float InitRotation;

	// Use this for initialization
	void Start ()
	{
		InitRotation = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOpen && transform.rotation.eulerAngles.y < InitRotation + 80)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,InitRotation +80 , 0), 5 );
		}
		else if (!IsOpen && transform.rotation.eulerAngles.y > InitRotation)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,InitRotation,0),5 );
		}
	}

	public void Open()
	{
		if (Id == -1 || Inventory.instance.HasKey(Id))
		{
			IsOpen = !IsOpen;
		}	
	}

	public void Action()
	{
		Open();
	}
}

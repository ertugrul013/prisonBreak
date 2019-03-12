using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
	public string name;
	public int weight;

	public void Action()
	{
		if (Inventory.instance.AddItem(CreateItem()))
		{
			gameObject.SetActive(false);
		}
	}

	protected abstract Item CreateItem();
}
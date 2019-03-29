using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour, IInteractable
{
	public Image image;
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

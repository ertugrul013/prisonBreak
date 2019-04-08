using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Pickup : MonoBehaviour, IInteractable
{
	public Sprite image;
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

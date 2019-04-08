using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//instance
	public static Inventory instance;
	public static int amountOfRaftItems;
	public List<Item> _items = new List<Item>();
	public int maxWeight = 10;
	private int _totalWeight;
	private int currentAmountOfItems = 0;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this);
		}
	}

	public bool AddItem(Item item)
	{
		//if the total weight is lower than max weight continue
		if(_totalWeight + item.Weight > maxWeight)
		{
			return false;
		}
		_items.Add(item);
		_totalWeight += item.Weight;
		currentAmountOfItems++;
		UIManeger.instance.updateUI(item,currentAmountOfItems);
		return true;
	}

	/// <summary>
	/// removes item's from the inventory.
	/// only if removing is successful than the weight will decrease
	/// </summary>
	/// <param itemobject="item"></param>
	public void RemoveItem(Item item)
	{
		if (_items.Remove(item))
		{
			_totalWeight -= item.Weight;
		}
	}

	public bool checkKey(int _id)
	{
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] is AccesItem)
			{
				var it = (AccesItem) _items[i];
				if (it.id == _id)
				{
					return true;
				}
			}
		}
		return false;
	}

}

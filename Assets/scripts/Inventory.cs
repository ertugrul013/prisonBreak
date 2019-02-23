using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//instance 
	public static Inventory instance;
	
	private List<Item>  _items = new List<Item>();
	public int maxWeight = 10;
	private int _totalWeight;

	private void Awake()
	{
		if (instance == null)
		{
			
			Debug.Log(_items.Count);
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
		Debug.Log(item);
		//if the total weight is lower than max weight continue
		if(_totalWeight + item.Weight > maxWeight)
		{
			return false;
		}
		Debug.Log(item);
		_items.Add(item);
		_totalWeight += item.Weight;
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

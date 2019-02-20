using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;
	
	private int _totalWeight;
	private int _maxWeight;

	private List<Item> _items;

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
		if (_totalWeight + item.Weight > _maxWeight)
		{
			return false;
		}
		else
		{
			_items.Add(item);
			_totalWeight += item.Weight;
			return true;
		}
	}

	public void RemoveItem(Item item)
	{
		if (_items.Remove(item))
		{
			_totalWeight -= item.Weight;
		}
	}

	public bool HasKey(int id)
	{
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] is AccesItem)
			{
				AccesItem it = (AccesItem) _items[i];
				if (it.Door == id)
				{
					return true;
				}
			}
		}
	}
}

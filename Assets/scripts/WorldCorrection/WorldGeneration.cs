using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
	public static WorldGeneration instance;
	
	public PassCalculate passCalculate;
	
	//the different type's of seed's
	public int _seed;
	public float _perlinSeed;

	private int worldSize = 513;
	public int maxHeight = 600;
	[SerializeField] private Terrain mainTerrain;
	
	public List<HeightPass> Passes = new List<HeightPass>();
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

	private void Start()
	{
		passCalculate = new PassCalculate(worldSize,worldSize,Passes);
		mainTerrain.terrainData.size = new Vector3(worldSize,maxHeight,worldSize);
		mainTerrain.terrainData.heightmapResolution = worldSize;
		Generate();
	}

	void Generate()
	{
		SetSeed(_seed);
		passCalculate.Generate();
		mainTerrain.terrainData.SetHeights(0,0,passCalculate.GetNormilized());
		Debug.Log("height set");
		//PassCalculate.G
	}
	/// <summary>
	/// Sets the seed for the terrain genaration
	/// </summary>
	/// <param name="CurrSeed">the current seed</param>
	/// <returns></returns>
	void SetSeed(int CurrSeed)
	{
		Random.InitState(CurrSeed);
		//Will perform the needed check so that the seed isn't assigned mulitple time's
		if (_seed != CurrSeed )
		{
			_seed = CurrSeed;
		}
		_perlinSeed = Random.Range(0f, 1000000f);
	}
}

using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
	public static WorldGeneration instance;

	public PassCalculate passCalculate;
	public ObjectSpawning objectSpawning = new ObjectSpawning();

	public float minHeight;

	//the different type's of seed's
	public int seed;
	public float perlinSeed;

	public int worldSize = 513;
	public int maxHeight = 600;
	public Terrain mainTerrain;

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

	private void Generate()
	{
		SetSeed(seed);
		passCalculate.Generate();
		mainTerrain.terrainData.SetHeights(0,0,passCalculate.GetNormilized());
		Debug.Log("height set");
		objectSpawning.SpawnRaftItem();
		Debug.Log("spawned raft parts");
	}
	/// <summary>
	/// Sets the seed for the terrain genaration
	/// </summary>
	/// <param name="CurrSeed">the current seed</param>
	/// <returns></returns>
	private void SetSeed(int CurrSeed)
	{
		Random.InitState(CurrSeed);
		//Will perform the needed check so that the seed isn't assigned multiple time's
		if (seed != CurrSeed )
		{
			seed = CurrSeed;
		}
		perlinSeed = Random.Range(0f, 1000000f);
	}

}

using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
	public static WorldGeneration instance;
	
	public PassCalculate passCalculate;
	
	//the different type's of seed's
	public int _seed;
	public float _perlinSeed;

	public int worldSize = 513;
	public int maxHeight = 600;
	[SerializeField] private Terrain mainTerrain;
	
	public List<HeightPass> Passes = new List<HeightPass>();

	[Header("Raft Spawn settings")] [Range(8, 20)] [SerializeField]
	private int AmountOfRaftParts;
	public GameObject raftPart;

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
		SetSeed(_seed);
		passCalculate.Generate();
		mainTerrain.terrainData.SetHeights(0,0,passCalculate.GetNormilized());
		Debug.Log("height set");
		SpawnRaftParts();
		Debug.Log("spawned raft parts");
		//PassCalculate.G
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
		if (_seed != CurrSeed )
		{
			_seed = CurrSeed;
		}
		_perlinSeed = Random.Range(0f, 1000000f);
	}

	private void SpawnRaftParts()
	{
		for (int x = 0; x < AmountOfRaftParts; x++)
		{
			var xCord = Random.Range(50, worldSize - 50);
			var zCord = Random.Range(50, worldSize - 50);
			//Gets the height of the terrain at the xCord and yCord
			var yCord = mainTerrain.terrainData.GetHeight(xCord, zCord);
			///spawning cordinate
			Vector3 Cord = new Vector3(xCord,yCord + 0.5f,zCord);
			
			Debug.Log(mainTerrain.terrainData.GetSteepness(xCord, yCord));
			Instantiate(raftPart, Cord, Quaternion.identity);
		}
	}
}

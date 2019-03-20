using System;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// This is used for the control for object spawning.
/// All objects that are instantiated in a large number should be added here.
/// Currently controlled Objects by this class.
///     1.RaftItem
///-------want to add------------
///     2.Key Spawning.
/// </summary>
[Serializable]
public class ObjectSpawning
{
    
    [Header("Raft Spawn settings")] [Range(8, 20)] [SerializeField]
    private int AmountOfRaftParts;

    public int spawnMargin;
    public GameObject raftPart;

    public void SpawnRaftItem()
    {
        for (int i = 0; i < AmountOfRaftParts; i++)
        {
            MonoBehaviour.Instantiate(raftPart, GetCord(), Quaternion.identity);
        }
    }

    Vector3 GetCord()
    {
        var xCord = Random.Range(spawnMargin, WorldGeneration.instance.worldSize - spawnMargin);
        var zCord = Random.Range(spawnMargin, WorldGeneration.instance.worldSize - spawnMargin);
        //Gets the height of the terrain at the xCord and yCord
        var yCord = WorldGeneration.instance.mainTerrain.terrainData.GetHeight(xCord, zCord);
        ///spawning cordinate
        //used for spawning the raftpart objects. 0.5f is used for the cubes and should be removed later on.
        return new Vector3(xCord,yCord + 0.5f,zCord);
    }
} 

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

    public GameObject raftPart;

    public void SpawnRaftItem()
    {
        for (int i = 0; i < AmountOfRaftParts; i++)
        {
            MonoBehaviour.Instantiate(raftPart, GetCord(), Quaternion.identity);
        }
    }
    
    /// <summary>
    /// Gets a random location on the map with the desired minimal height.
    /// </summary>
    /// <returns>vector3 with the desired minHeight</returns>
    Vector3 GetCord()
    {
        var xCord = 0;
        var zCord = 0;
        var yCord = 0f;
        
        while (yCord < WorldGeneration.instance.minHeight)
        {
            xCord = Random.Range(0, WorldGeneration.instance.worldSize);
            zCord = Random.Range(0, WorldGeneration.instance.worldSize);
            yCord = WorldGeneration.instance.mainTerrain.terrainData.GetHeight(xCord, zCord);
            
        }
        return new Vector3(xCord,yCord + 0.5f,zCord);
    }
} 

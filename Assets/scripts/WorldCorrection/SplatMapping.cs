using System;
using System.Linq;
using UnityEngine;
/// <summary>
/// WIP is not working yet
/// </summary>
[Serializable]
public class SplatMapping
{
    [Serializable]
    public class SplatHeight
    {
        public int textureIndex;
        public int stratingHeight;
    }

    public SplatHeight[] splatHeights;
    
    public void Paint()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;

        float[, ,] splatmapData = new float[terrainData.alphamapWidth,terrainData.alphamapHeight,terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float terrainHeight = terrainData.GetHeight(y, x);

                float[] splat = new float[splatHeights.Length];

                for (int i = 0; i < splatHeights.Length; i++)
                {
                    if (terrainHeight >= splatHeights[i].stratingHeight)
                    {
                        splat[i] = 1;
                    }
                }

                for (int j = 0; j < splatHeights.Length; j++)
                {
                    splatmapData[x, y, j] = splat[j];
                }
            }
        }
        terrainData.SetAlphamaps(0,0,splatmapData);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class PassCalculate
{
    public int width;

    public int depth;

    public float[,] _heights;
    
    public List<HeightPass> Passes = new List<HeightPass>();

    public  PassCalculate(int width,int depth,List<HeightPass> passes)
    {
        this.width = width;
        this.depth = depth;
        this.Passes = passes;
        //creates the correct length for the array for 
        _heights = new float[depth,width];
    }

    public void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                _heights[x, z] = CalculateHeight(x, z);
            }
        }
    }

    float CalculateHeight(int x,int z)
    {
        var HeightValua = 0f;
        for (int i = 0; i < Passes.Count; i++)
        {
            var val = 0f;
            switch (Passes[i].PassType)
            {
                case HeightPass.Pass.PerlinBased:
                    val = Mathf.PerlinNoise(WorldGeneration.instance._perlinSeed + x / Passes[i].detail,WorldGeneration.instance._perlinSeed + z / Passes[i].detail) * Passes[i].height;
                    HeightValua += val;
                    break;
                case HeightPass.Pass.RandomBased:
                    val = Random.value * Passes[i].height;
                    HeightValua += val;
                    break;
                case HeightPass.Pass.ImageBased:
                    if (Passes[i].mapSprite != null)
                    {
                        val = Passes[i].mapSprite.texture.GetPixel(x, z).grayscale;  
                        HeightValua *= val;
                    }
                    else
                    {
                        Debug.Log("image not set to an instance the pass will fallback to randombased");
                        val = Random.value * Passes[i].height;
                        HeightValua += val;
                    }
                    break;
            }
        }

        return HeightValua;
    }

    public float[,] GetNormilized()
    {
        float[,] normilized = new float[width,depth];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                normilized[x, z] = MathUtils.Map(_heights[x, z], 0, WorldGeneration.instance.maxHeight, 0, 1);
            }
        }
        return normilized;
    }
}

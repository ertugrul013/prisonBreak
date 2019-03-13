using System;
using UnityEngine;

[Serializable]
public class HeightPass
{
    public enum Pass
    {
        PerlinBased,
        RandomBased,
        ImageBased
    };

    public string name;
    public Sprite mapSprite;
    public float detail, height;

    public Pass PassType;
}

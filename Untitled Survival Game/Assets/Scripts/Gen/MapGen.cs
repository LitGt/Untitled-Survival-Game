using UnityEngine;

public class MapGen : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public void GernerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapHeight, mapWidth, noiseScale);


    }
}

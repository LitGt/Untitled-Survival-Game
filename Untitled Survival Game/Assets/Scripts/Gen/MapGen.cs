using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octives;
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octives, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap (noiseMap);
    }
}

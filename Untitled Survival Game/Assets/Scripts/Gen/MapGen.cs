using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapHeight, mapWidth, noiseScale);

        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap (noiseMap);
    }
}

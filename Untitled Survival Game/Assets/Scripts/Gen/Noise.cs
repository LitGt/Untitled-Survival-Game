using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octives, float persistance, float lacunarity)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        if(scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHight = float.MinValue;
        float minNoiseHight = float.MaxValue;

        for(int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHight = 0;

                for (int i = 0; i < octives; i++)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHight += perlinValue * amplitude;

                    amplitude *= persistance;

                    frequency *= lacunarity;
                }

                if (noiseHight > maxNoiseHight)
                {
                    maxNoiseHight = noiseHight;
                }
                else if (noiseHight < minNoiseHight)
                {
                    minNoiseHight = noiseHight;
                }
                noiseMap[y, x] = noiseHight;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHight, maxNoiseHight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
}

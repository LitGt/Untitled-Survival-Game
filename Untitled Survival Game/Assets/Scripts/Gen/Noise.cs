using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octives, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octiveOffsets = new Vector2[octives];
        for (int i = 0; i < octives; i++)
        {
            float offetX = prng.Next(-100000, 100000) + offset.x;
            float offetY = prng.Next(-100000, 100000) + offset.y;
            octiveOffsets[i] = new Vector2 (offetX, offetY);
        }

        if(scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHight = float.MinValue;
        float minNoiseHight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHight = 0;

                for (int i = 0; i < octives; i++)
                {
                    float sampleX = (x-halfWidth) / scale * frequency + octiveOffsets[i].x;
                    float sampleY = (y-halfHight) / scale * frequency + octiveOffsets[i].y;

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

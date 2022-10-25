using UnityEngine;
using System.Collections;

public class Noise:MonoBehaviour
{
    [Header("Terrain Height Variation:"), Space(10)]
    [SerializeField] private int depth = 20;
    [Header("Terrain Size:"), Space(10)]
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [Header("Terrain Noise Settings:"), Space(10)]
    [SerializeField] private float scale = 20f;
    [SerializeField] private int octaves = 4;
    [Range(0,1)]
    [SerializeField] private float persistance = 0.5f;
    [SerializeField] private float lacunarity = 2f;

    [Header("Terrain:"), Space(10)]
    [SerializeField] Terrain terrain;
    [SerializeField] TerrainData terrainData;
    private void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainData(terrain.terrainData);
    }
    TerrainData GenerateTerrainData(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateNoiseMap());
        return terrainData;
    }
    public float[,] GenerateNoiseMap()
    {
        float[,] noiseMap = new float[width, height];

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0f;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (float)x / width * scale * frequency; //ojo a los parentesis
                    float sampleY = (float)y / height * scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;


                }
                if(noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }else if(noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
                return noiseMap;
    }
}
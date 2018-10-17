using UnityEngine;

public class TerrainGeneration : MonoBehaviour {

    public int depth = 20;
    public int width = 256;
    public int hight = 256;

    public float scale = 20.0f;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.size = new Vector3(width, depth, hight);
        terrainData.SetHeights(0, 0, GenerateHights());

        return terrainData;
    }

    float[,] GenerateHights()
    {
        float[,] hights = new float[width, hight];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < hight; y++)
            {
                hights[x, y] = CalculateHight(x, y);
            }
        }

        return hights;
    }

    float CalculateHight(int x, int y)
    {
        float xCord = x / width * scale;
        float yCord = y / hight * scale;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}

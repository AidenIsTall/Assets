using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ProcGen : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase landTile;

    public int width;
    public int height;
    [Range(0,100)] public int initialFillPercent;
    public int smoothIterations;

    int[,] map;

    void Start(){

        GenerateMap();
        SmoothMap();
        DrawMap();
    }

    void GenerateMap(){

        map = new int[width, height];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){

                map[x,y] = (Random.Range(0,100)< initialFillPercent) ? 1 : 0;
            }
        }
        for (int x = 0; x < width; x++)
        {
            map[x, 0] = 1;
            map[x, height - 1] = 1;
        }

        for (int y = 0; y < height; y++)
        {
            map[0, y] = 1;
            map[width - 1, y] = 1;
        }
    }

    void SmoothMap(){

        for (int i = 0; i < smoothIterations; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int surroundingTiles = CountSurroundingTiles(x, y);

                    if (surroundingTiles > 4)
                    {
                        map[x, y] = 1;
                    }
                    else if (surroundingTiles < 4)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }
    }
    int CountSurroundingTiles(int gridX, int gridY){
        int count = 0;
        for (int x = gridX - 1; x <= gridX + 1; x++)
        {
            for (int y = gridY - 1; y <= gridY + 1; y++)
            {
                if (x >= 0 && x < width && y >= 0 && y < height)
                {
                    count += map[x, y];
                }
                else
                {
                    count++;
                }
            }
        }
        return count;
    }

    void DrawMap()
    {
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(tilePosition, landTile);
            }
        }
    }
}
}
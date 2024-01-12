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

        map = new int[width, height];     //creates a 2D array called map

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){

                map[x,y] = (Random.Range(0,100)< initialFillPercent) ? 1 : 0; // randomly fills the map based on the initialFillPercent variable.
            }
        }
        for (int x = 0; x < width; x++)    // for loop
        {
            map[x, 0] = 1;                 //sets vertical limits to close off the map
            map[x, height - 1] = 1;        // see above
        }

        for (int y = 0; y < height; y++)
        {
            map[0, y] = 1;                 //sets horizontal limits to close off the map
            map[width - 1, y] = 1; //see above
        }
    }

    void SmoothMap(){

        for (int i = 0; i < smoothIterations; i++)   //for loop to run a specific number of times.
        {
            for (int x = 0; x < width; x++)        //keeps the function inside the map
            {
                for (int y = 0; y < height; y++)    //see above
                {
                    int surroundingTiles = CountSurroundingTiles(x, y); //sets the value of surroundingTiles to the result of CountSurroundingTiles(x, y)

                    if (surroundingTiles > 4)     // checks for single tile gaps and fills them in, this creates a more cave-like look. This uses the cellular automata framework.
                    {
                        map[x, y] = 1;    //makes tile
                    
                    else if (surroundingTiles < 4)   // does the opposite of above, checks for single tiles and removes them to make navigaton easier.
                    {
                        map[x, y] = 0;    //removes tile
                    }
                }
            }
        }
    }
    int CountSurroundingTiles(int gridX, int gridY){      //it counts the number of surrounding tiles. Duh.
    
        int count = 0;      //it keeps count.
        
        for (int x = gridX - 1; x <= gridX + 1; x++){     //for loops to keep function to necessary area
            for (int y = gridY - 1; y <= gridY + 1; y++){     //see above
            
                if (x >= 0 && x < width && y >= 0 && y < height){ //checks if tiles are in map
                    count += map[x, y];     //counts the tiles
                }
                else{
                    count++; //increases count by one
                }
            }
        }
        return count;
    }

    void DrawMap() //draws the map using Unity tilemap library
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

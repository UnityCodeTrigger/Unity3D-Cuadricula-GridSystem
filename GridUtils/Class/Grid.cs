using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    int height, width;
    float cellSize = 1;
    public int[,] gridArray;
    public TextMesh[,] debugTextArray;
    Vector2 origin;

    public Grid(int width, int height, float cellSize, Vector2 origin)
    {
        //grid size
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        //Setup grid array
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        //initialize grid
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                DebugUtils.DrawText(x + "/" + y, CoordinatesToWorld(x, y), Vector3.one * cellSize * 0.025f);
                DebugUtils.DrawText(gridArray[x,y].ToString(),
                                    CoordinatesToWorld(x, y) - Vector2.up * cellSize * 0.25f,
                                    Vector3.one * cellSize * 0.025f,
                                    null,
                                    Color.green,
                                    out debugTextArray[x,y]
                                    );

                Debug.DrawLine(CoordinatesToWorld(x,y) - Vector2.one * (cellSize * 0.5f), CoordinatesToWorld(x, y + 1) - Vector2.one * (cellSize * 0.5f), Color.white, 999);
                Debug.DrawLine(CoordinatesToWorld(x, y) - Vector2.one * (cellSize * 0.5f), CoordinatesToWorld(x + 1, y) - Vector2.one * (cellSize * 0.5f), Color.white, 999);
            }
        }
        Debug.DrawLine(CoordinatesToWorld(width, 0) - Vector2.one * (cellSize * 0.5f), CoordinatesToWorld(width,height) - Vector2.one * (cellSize * 0.5f), Color.white, 999);
        Debug.DrawLine(CoordinatesToWorld(0, height) - Vector2.one * (cellSize * 0.5f), CoordinatesToWorld(width ,height) - Vector2.one * (cellSize * 0.5f), Color.white, 999);

    }

    public void WorldToCoordinates(Vector2 worldPos, out int x, out int y)
    {
        x = Mathf.RoundToInt((worldPos - origin).x / cellSize);
        y = Mathf.RoundToInt((worldPos - origin).y / cellSize);
    }
    public Vector2 CoordinatesToWorld(int x, int y)
    {
        Vector2 pos = new Vector2(x, y) * cellSize + origin;
        return pos;
    }

    //Get value using position & coordinates
    public int GetGridValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
            return 0;
    }
    public int GetGridValue(Vector2 position)
    {
        int x, y;
        WorldToCoordinates(position, out x, out y);

        return GetGridValue(x,y);
    }

    //Set value using position & coordinates
    public void SetGridValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    public void SetGridValue(Vector2 position, int value)
    {
        int x, y;
        WorldToCoordinates(position, out x, out y);

        SetGridValue(x, y,value);
    }
}
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public int x, y;
    Grid grid;

    void Start()
    {
        grid = new Grid(x, y,1, transform.position);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int _x;
            int _y;
            int value;
            Vector2 mousePos = WorldMousePosition(Input.mousePosition);
            grid.WorldToCoordinates(mousePos, out _x,out _y);
            value = grid.GetGridValue(_x, _y);
            grid.SetGridValue(_x,_y, value + 1);
        }
    }

    Vector2 WorldMousePosition(Vector2 pos)
    {
        return Camera.main.ScreenToWorldPoint(pos);
    }
}
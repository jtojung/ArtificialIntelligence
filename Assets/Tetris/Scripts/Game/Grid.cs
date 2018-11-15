using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    #region Singleton
    public static Grid Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion
    public int width = 10, height = 20;

    // 2D grid for storing the blocks
    public Transform[,] data;


    public void OnDrawGizmos()
    {

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Gizmos.DrawWireCube(new Vector3(x, y), Vector3.one);
            }
        }
    }
    // Use this for initialization
    void Start() {
        data = new Transform[width, height];
    }
    public bool insideBorder(Vector2 pos)
    {
        //truncate the vector
        int x = (int)pos.x;
        int y = (int)pos.y;

        // Is the position within the bounds of the grid?
        if (x >= 0 && x < width &&
           y >= 0) // Do not need to check height
        {
            // Inside of the border
            return true;
        }
        // Outside of the border
        return false;
    }
    public void DeleteRow(int y)
    {
        // Loop through the row using x - width
        for (int x = 0; x< width; x++)
        {
            //Destroy each element
            Destroy(data[x, y].gameObject);
            //clear array index
            data[x, y] = null;
        }

    }
    public void DecreaseRow(int y)
    {
        // Loop through entire row
        for(int x = 0; x < width; x++)
        {
            //Check if index is not null
            if(data[x,y] != null)
            {
                // Move one towards bottom
                data[x, y - 1] = data[x, y];
                // Set grid element to one above
                data[x, y] = null;
                //update block position
                data[x, y - 1].position += Vector3.down;
            }
        }
    }
    public void DecreaseRowAbove(int y)
    {
        //Loop each row starting from y
        for (int i = y; i<height; i++)
        {
            // Decrease each row
            DecreaseRow(i);
        }
    }
    public bool IsRowFull(int y)
    {
        //Loop through each column
        for(int x = 0;x < width; x++)
        {
            if(data[x,y] == null)
                return false;
        }
        //We have found a full row!
        return true;
    }
    public int DeleteFullrows()
    {
        int clearedRows = 0;
        //Loop through all rows
        for (int y =0; y < height; y++)
        {
            //Add row to count
            clearedRows++;
            //Delete entire row
            DeleteRow(y);
            //Decrease row from above
            DecreaseRowAbove(y + 1);
            //Decrease current y coordinate
            //(so we don't skip the next row)
            y--;
        }

        return clearedRows;
    }
    public Vector2 RoundVec2(Vector2 v)
    {
        float roundX = Mathf.Round(v.x);
        float roundY = Mathf.Round(v.y);

        return new Vector2(roundX,roundY);
    }

}
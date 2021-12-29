using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public int rows = 4;
    public int columns = 4;
    public GameObject mazeWall;
    public GameObject mazeFloor;

    private MazeCell[,] grid;
    private int currentRow = 0;
    private int currentColumn = 0;

    void Start()
    {

        CreateGrid();

        HuntAndKill();
        
    }

    void CreateGrid()
    {
        float size = mazeWall.transform.localScale.x;
        grid = new MazeCell[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject floor = Instantiate(mazeFloor, new Vector3(j * size, 0, -i * size), Quaternion.identity);
                floor.name = "Floor_" + i + "_" + j;

                GameObject upWall = Instantiate(mazeWall, new Vector3(j * size, 1.75f, -i * size + 1.25f), Quaternion.identity);
                upWall.name = "UpWall_" + i + "_" + j;

                GameObject downWall = Instantiate(mazeWall, new Vector3(j * size, 1.75f, -i * size - 1.25f), Quaternion.identity);
                downWall.name = "DownWall_" + i + "_" + j;

                GameObject leftWall = Instantiate(mazeWall, new Vector3(j * size - 1.25f, 1.75f, -i * size), Quaternion.Euler(0, 90, 0));
                leftWall.name = "LeftWall_" + i + "_" + j;

                GameObject rightWall = Instantiate(mazeWall, new Vector3(j * size + 1.25f, 1.75f, -i * size), Quaternion.Euler(0, 90, 0));
                rightWall.name = "RightWall_" + i + "_" + j;

                grid[i, j] = new MazeCell();
                grid[i, j].upWall = upWall;
                grid[i, j].downWall = downWall;
                grid[i, j].leftWall = leftWall;
                grid[i, j].rightWall = rightWall;

                floor.transform.parent = transform;
                upWall.transform.parent = transform;
                downWall.transform.parent = transform;
                leftWall.transform.parent = transform;
                rightWall.transform.parent = transform;

            }
        }
    }

    bool IsThereUnvisitedNeighbors()
    {
        if (IsCellUnvisitedAndWithinBoundaries(currentRow - 1, currentColumn))
        {
            return true;
        }
      

        if (IsCellUnvisitedAndWithinBoundaries(currentRow + 1, currentColumn))
        {
            return true;
        }

        if(IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn + 1))
        {
            return true;
        }
        
        if(IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn - 1))
        {
            return true;
        }

        return false;
    }
    bool IsCellUnvisitedAndWithinBoundaries(int row, int column)
    {
        if (row >= 0 && row < rows && column >= 0 && column < columns && !grid[row, column].hasVisited)
        {
            return true;
        }

        return false;
    }
   
    void HuntAndKill()
    {
        grid[currentColumn, currentColumn].hasVisited = true;

        while (IsThereUnvisitedNeighbors())
        {
            int direction = Random.Range(0, 4);

            if (direction == 0)
            {
                if (IsCellUnvisitedAndWithinBoundaries(currentRow - 1, currentColumn))
                {
                    if (grid[currentRow, currentColumn].upWall)
                    {
                        Destroy(grid[currentRow, currentColumn].upWall);
                    }

                    currentRow--;
                    grid[currentRow, currentColumn].hasVisited = true;

                    if (grid[currentRow, currentColumn].downWall)
                    {
                        Destroy(grid[currentRow, currentColumn].downWall);
                    }
                }
            }

            else if (direction == 1)
            {

                if (IsCellUnvisitedAndWithinBoundaries(currentRow + 1, currentColumn))
                {
                    if (grid[currentRow, currentColumn].downWall)
                    {
                        Destroy(grid[currentRow, currentColumn].downWall);
                    }

                    currentRow++;
                    grid[currentRow, currentColumn].hasVisited = true;

                    if (grid[currentRow, currentColumn].upWall)
                    {
                        Destroy(grid[currentRow, currentColumn].upWall);
                    }
                }
            }

            else if (direction == 2)
            {
                if (IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn - 1))
                {
                    if (grid[currentRow, currentColumn].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }

                    currentColumn--;
                    grid[currentRow, currentColumn].hasVisited = true;

                    if (grid[currentRow, currentColumn].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }
                }
            }

            else if (direction == 3)
            {
                if (IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn + 1))
                {
                    if (grid[currentRow, currentColumn].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }

                    currentColumn++;
                    grid[currentRow, currentColumn].hasVisited = true;

                    if (grid[currentRow, currentColumn].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }
                }
            }

        
        }
    }
}

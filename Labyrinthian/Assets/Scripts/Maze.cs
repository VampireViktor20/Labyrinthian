using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maze : MonoBehaviour
{
    public int Rows = 2;
    public int Columns = 2;
    public GameObject mazeWall;
    public GameObject mazeFloor;
    public InputField heightField;
    public InputField widthField;

    private MazeCell[,] grid;
    private int currentRow = 0;
    private int currentColumn = 0;
    private bool hasScanned = false;

    void Start()
    {

        GenerateGrid();
        
    }

    void GenerateGrid()
    {
        foreach (Transform transform in transform)
        {
            Destroy(transform.gameObject);
        }
        CreateGrid();

        currentRow = 0;
        currentColumn = 0;
        hasScanned = false; 

        HuntAndKill();
    }

    void CreateGrid()
    {
        float size = mazeWall.transform.localScale.x;
        grid = new MazeCell[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
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

                if(i == 0 && j == 0)
                {
                    Destroy(leftWall);
                }

                if(i == Rows - 1 && j == Columns -1)
                {
                    Destroy(rightWall);
                }
            }
        }
    }
    void HuntAndKill()
    {
        grid[currentColumn, currentColumn].hasVisited = true;

        while (!hasScanned)
        {
            Walk();
            Hunt();

        }

    }

    void Walk()
    {
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

    void Hunt()
    {
        hasScanned = true;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (!grid[i, j].hasVisited && AreThereVisitedNeighbors(i, j))
                {
                    hasScanned = false;
                    currentRow = i;
                    currentColumn = j;
                    grid[currentRow, currentColumn].hasVisited = true;
                    DestroyAdjacentWall();
                    return;
                }
            }
        }
    }

    void DestroyAdjacentWall()
    {
        bool hasDestroyed = false;
        
        while (!hasDestroyed)
        {
            int direction = Random.Range(0, 4);

            if (direction == 0)
            {
                if(currentRow > 0 && grid[currentRow - 1, currentColumn].hasVisited)
                {

                    if ((grid[currentRow, currentColumn].upWall))
                    {
                        Destroy(grid[currentRow, currentColumn].upWall);
                    }

                    if (grid[currentRow - 1, currentColumn].downWall)
                    {
                        Destroy(grid[currentRow - 1, currentColumn].downWall);
                    }
                   
                    hasDestroyed = true;
                    
                }
            }

            else if (direction == 1)
            {
                if (currentRow < Rows - 1 && grid[currentRow + 1, currentColumn].hasVisited)
                {
                    if ((grid[currentRow, currentColumn].downWall))
                    {
                        Destroy(grid[currentRow, currentColumn].downWall);
                    }

                    if (grid[currentRow + 1, currentColumn].upWall)
                    {
                        Destroy(grid[currentRow + 1, currentColumn].upWall);
                    }

                    hasDestroyed = true;
                }
            }

            else if (direction == 2)
            {
                if (currentColumn > 0 && grid[currentRow, currentColumn - 1 ].hasVisited)
                {
                    if ((grid[currentRow, currentColumn].leftWall))
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }

                    if (grid[currentRow, currentColumn - 1].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn - 1].rightWall);
                    }

                    hasDestroyed = true;
                }
            }

            else if (direction == 3)
            {
                if (currentColumn < Columns - 1 && grid[currentRow, currentColumn + 1].hasVisited)
                {
                    if ((grid[currentRow, currentColumn].rightWall))
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }

                    if (grid[currentRow, currentColumn + 1].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn + 1].leftWall);
                    }

                    hasDestroyed = true;
                }
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

        if (IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn + 1))
        {
            return true;
        }

        if (IsCellUnvisitedAndWithinBoundaries(currentRow, currentColumn - 1))
        {
            return true;
        }

        return false;
    }

    public bool AreThereVisitedNeighbors(int row, int column)
    {
        if (row > 0 && grid[row - 1, column].hasVisited)
        {
            return true;
        }

        if (row < Rows - 1 && grid[row + 1, column].hasVisited)
        {
            return true;
        }

        if (column > 0 && grid[row, column - 1].hasVisited)
        {
            return true;
        }

        if (column < Columns - 1 && grid[row, column + 1].hasVisited)
        {
            return true;
        }


        return false;
    }

    bool IsCellUnvisitedAndWithinBoundaries(int row, int column)
    {
        if (row >= 0 && row < Rows && column >= 0 && column < Columns && !grid[row, column].hasVisited)
        {
            return true;
        }

        return false;
    }

    public void Regenerate()
    {
        int rows = 2;
        int columns = 2;

        if(int.TryParse(heightField.text, out rows))
        {
            Rows = rows;
        }

        if(int.TryParse(widthField.text, out columns))
        {
            Columns = columns;
        }
        GenerateGrid();
    }

}

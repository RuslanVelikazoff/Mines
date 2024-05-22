using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Minefield : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField] 
    private int height;

    [SerializeField] 
    private int bombPercentage;

    private List<Cell> cells = new List<Cell>();
    private Dictionary<Vector3Int, Cell> positionToCell = new Dictionary<Vector3Int, Cell>();

    [SerializeField] 
    private MinefieldVisualizer visualizer;

    private int totalCells;
    private int bombsToSetup;
    private int remainedBombs;
    
    private int closedCells;

    public int Width
    {
        get => width;
    }

    public int Height
    {
        get => height;
    }

    private void Awake()
    {
        totalCells = width * height;
        bombsToSetup = totalCells * bombPercentage / 100;
        remainedBombs = bombsToSetup;
        closedCells = totalCells;
        
        Debug.Log(bombsToSetup);
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CreateMinefield();
        visualizer.VisualizeCellsOnStart(cells);
    }

    private void CreateMinefield()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = new Cell(x, y);
                cells.Add(cell);
                positionToCell[new Vector3Int(x, y, 0)] = cell;
            }
        }
        
        SetBombs();
    }

    private void SetBombs()
    {
        int setBombs = 0;
        while (setBombs < bombsToSetup)
        {
            int randomIndex = Random.Range(0, cells.Count);
            
            if (cells[randomIndex].IsBomb)
            {
                continue;
            }

            cells[randomIndex].IsBomb = true;
            setBombs++;
        }
    }

    public void OpenCellByCoords(Vector3Int cellCoords)
    {
        Cell cell = positionToCell[cellCoords];
        OpenCellResult result = cell.OpenCell();

        if (result == OpenCellResult.Opened)
        {
            int bombsAround = GetBombsAroundCell(cell);
            visualizer.OpenCell(cell, bombsAround);
            closedCells--;

            if (bombsAround == 0)
            {
                foreach (Cell neighbour in GetNeighborCell(cell))
                {
                    OpenCellByCoords(new Vector3Int(neighbour.XCoord, neighbour.YCoord, 0));
                }
            }
        }

        if (result == OpenCellResult.GameOver)
        {
            GameManager.Instance.LoseGame();
        }

        if (closedCells == bombsToSetup)
        {
            GameManager.Instance.WinGame();
        }
    }

    private IEnumerable<Cell> GetNeighborCell(Cell cell)
    {
        List<Cell> neighbourCells = new List<Cell>();

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                Vector3Int neighbourCoords = new Vector3Int(cell.XCoord + x, cell.YCoord + y, 0);

                if (!positionToCell.ContainsKey(neighbourCoords))
                {
                    continue;
                }

                if (x == 0 && y == 0)
                {
                    continue;
                }

                Cell neighbourCell = positionToCell[neighbourCoords];
                neighbourCells.Add(neighbourCell);
            }
        }

        return neighbourCells;
    }

    private int GetBombsAroundCell(Cell cell)
    {
        int bombsAround = 0;

        foreach (var neighbour in GetNeighborCell(cell))
        {
            if (neighbour.IsBomb)
            {
                bombsAround++;
            }
        }
        
        return bombsAround;
    }
}

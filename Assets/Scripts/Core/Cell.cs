using UnityEngine;

public enum OpenCellResult
{
    GameOver,
    Opened,
    None
}

public class Cell : MonoBehaviour
{
    private int xCoord;
    private int yCoord;

    private bool isBomb;
    private bool isOpened = false;

    private GameObject cellInstance;
    
    public Cell(int xCoord, int yCoord)
    {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }

    public bool IsBomb
    {
        get => isBomb;
        set => isBomb = value;
    }

    public int XCoord
    {
        get => xCoord;
    }

    public int YCoord
    {
        get => yCoord;
    }

    public GameObject CellInstance
    {
        get => cellInstance;
        set => cellInstance = value;
    }

    public OpenCellResult OpenCell()
    {
        if (isOpened)
        {
            return OpenCellResult.None;
        }

        if (isBomb)
        {
            return OpenCellResult.GameOver;
        }

        isOpened = true;
        return OpenCellResult.Opened;
    }
}

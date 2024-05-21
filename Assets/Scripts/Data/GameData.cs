[System.Serializable]
public class GameData
{
    public bool[] levelUnlock = new bool[7];
    public bool[] difficulty = new bool[3];

    public int currentLevelIndex;

    public GameData()
    {
        levelUnlock[0] = true;
        levelUnlock[1] = false;
        levelUnlock[2] = false;
        levelUnlock[3] = false;
        levelUnlock[4] = false;
        levelUnlock[5] = false;
        levelUnlock[6] = false;

        difficulty[0] = true;
        difficulty[1] = false;
        difficulty[2] = false;

        currentLevelIndex = 0;
    }
}

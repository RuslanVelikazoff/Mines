using Firebase.Firestore;

[FirestoreData]
public class SaveData
{
    private int day;
    private int month;
    private int year;

    [FirestoreProperty]
    public int Day
    {
        get => day;
        set => day = value;
    }

    [FirestoreProperty]
    public int Month
    {
        get => month;
        set => month = value;
    }

    [FirestoreProperty]
    public int Year
    {
        get => year;
        set => year = value;
    }
}

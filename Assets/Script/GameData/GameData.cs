
public class GameData  {
#if UNITY_EDITOR
    public string TestDataString;
    public int TestDataInt;
    public bool TestDataBool;
#endif

    public GameData()
    {
#if UNITY_EDITOR
        TestDataBool = false;
        TestDataInt = 0;
        TestDataString = "";
#endif
    }

}

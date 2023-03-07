public interface IGameData
{
    /* All the classes which needs to save or load data will implement this interface **/
    void LoadData(GameData _data);
    void SaveData(ref GameData _data);
}

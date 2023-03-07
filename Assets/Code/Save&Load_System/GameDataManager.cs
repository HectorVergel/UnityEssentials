using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;


    public static GameDataManager instance;

    private GameData gameData;

    private List<IGameData> gameDataHolders;

    private FileDataHandler dataHandler;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Data Manager in the scene. ");
        }

        instance = this;

    }

    private void Start()
    {
        gameDataHolders = FindAllGameDataHolders();
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IGameData dataObj in gameDataHolders)
        {
            dataObj.SaveData(ref gameData);
        }
        /** We save the data into the data handler */

        dataHandler.Save(gameData); 
    }

    public void LoadGame()
    {
        /** Load any data saved in the Data Handler */
        
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.LogError("No game data was found. Initializating data to default");
            NewGame();
        }

        /** We send the data to load to any script who need it */

        foreach(IGameData _dataObj in gameDataHolders)
        {
            _dataObj.LoadData(gameData);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IGameData> FindAllGameDataHolders()
    {
        IEnumerable<IGameData> _dataHolders = FindObjectsOfType<MonoBehaviour>().OfType<IGameData>();

        return new List<IGameData>(_dataHolders);
    }
}

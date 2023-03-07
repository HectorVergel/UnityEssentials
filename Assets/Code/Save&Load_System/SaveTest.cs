using UnityEngine;

public class SaveTest : MonoBehaviour, IGameData
{


    public int deathCount;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            deathCount++;
        }
    }
    public void LoadData(GameData _data)
    {
       deathCount = _data.deathCount;
    }

    public void SaveData(ref GameData _data)
    {
       _data.deathCount = deathCount;
    }
}

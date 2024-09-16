using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//https://qiita.com/kiku09020/items/8429d8693c761e0da4a1 参考
//https://www.sejuku.net/blog/48869
public class PlayerDataManager : MonoBehaviour
{
    private string _playerDataFilepath;
    private string _playerDataFileName = "PlayerData.json";
    CharacterData _characterData = new CharacterData();
    void CheckMasterDataExist()
    {
        _playerDataFilepath = Application.dataPath + "/" + _playerDataFileName;

        if (!File.Exists(_playerDataFilepath))
        {
            SavePlayerData(_characterData);
        }
    }

    void SavePlayerData(CharacterData _characterData)
    {
        string json = JsonUtility.ToJson(_characterData);
        StreamWriter writer = new StreamWriter(_playerDataFilepath, false);
        writer.WriteLine(json);
        writer.Close();
    }
    CharacterData LoadPlayerData()
    {
        StreamReader reader = new StreamReader(_playerDataFilepath);
        string json = reader.ReadToEnd();
        reader.Close();
        
        return JsonUtility.FromJson<CharacterData>(json);
    }
}

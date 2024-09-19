using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class DataDownLoad : MonoBehaviour
{
    private static string _apiurl =
        "https://script.google.com/macros/s/AKfycbxiigdL73WaYZvZVSA1SgEk54CqI2zvFk4c1xIC5YA1NlN5GLJ_mqO_otWPPBPfLUEp/exec";

    private static CharacterData _characterData = new CharacterData();
    private static TmpCharacterData tmpcharacterData = new TmpCharacterData();

    [MenuItem("MyTool/Download Data")]
    static async void DLData()
    {
        await GetData();
        _characterData = ConvertTmpCharacterData(tmpcharacterData);
    }
    
    public static CharacterData ConvertTmpCharacterData(TmpCharacterData tmpCharacterData)//jsonデータをEnumにうまく変換できなかったので、一度文字型にしてからEnum型にする。
    {
        Debug.Log("start");
        CharacterData characterData = new CharacterData();
        characterData.baseData = new List<CharacterDataBase>();
        foreach (var VARIABLE in tmpCharacterData.baseData)
        {
            CharacterDataBase tmpbase = new CharacterDataBase();
            tmpbase.CharacterName = VARIABLE.CharacterName;
            tmpbase.CharacterID = VARIABLE.CharacterID;
            tmpbase.Hp = VARIABLE.Hp;
            tmpbase.Atk = VARIABLE.Atk;
            tmpbase.Cost = VARIABLE.Cost;
            tmpbase.Speed = VARIABLE.Speed;
            tmpbase.Type = (CharacterType)Enum.Parse(typeof(CharacterType), VARIABLE.CharacterType);
            characterData.baseData.Add(tmpbase);
        }
        return characterData;
    }
    
    [MenuItem("MyTool/DebugConsole")]
    private static void DebugData()
    {
        foreach (var item in _characterData.baseData)
        {
            Debug.Log(string.Join(",", item.CharacterID, item.CharacterName, item.Type, item.Cost, item.Hp, item.Atk,
                item.Speed) + "\n");
        }
    }
    [MenuItem("MyTool/Download Data")]
    #if UNITY_EDITOR
    private static async UniTask GetData() //オンライン上のGoogleスプレッドシートからデータを取得
    {
        // HTTP リクエストする(GET メソッド) UnityWebRequest を呼び出し
        // アクセスする先は変数 urlAPI で設定
        UnityWebRequest request = UnityWebRequest.Get(_apiurl);

        // リクエスト開始
        await request.SendWebRequest();

        // 結果によって分岐
        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("リクエスト中");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("リクエスト成功");


                string tmp = request.downloadHandler.text;
                string str = "{\"baseData\":" + tmp + "}";

                // ResponseData クラスで Unity で扱えるデータ化
                tmpcharacterData = JsonUtility.FromJson<TmpCharacterData>(str);

                break;
        }
    }
#endif
}
[Serializable]
public class CharacterData
{
    public List<CharacterDataBase> baseData;
}
[Serializable]
public class CharacterDataBase
{
    public int CharacterID; //キャラクターのID
    public string CharacterName; //キャラクターの名前
    public CharacterType Type; //キャラクターの種類
    public int Cost; //召喚するのに必要なコイン
    public int Hp; //最大HP
    public int Atk; //攻撃力
    public float Speed; //移動速度
}

[Serializable]
public class TmpCharacterData
{
    public List<TmpCharacterDataBase> baseData;
}
[Serializable]
public class TmpCharacterDataBase
{
    public int CharacterID; //キャラクターのID
    public string CharacterName; //キャラクターの名前
    public string CharacterType; //キャラクターの種類
    public int Cost; //召喚するのに必要なコイン
    public int Hp; //最大HP
    public int Atk; //攻撃力
    public float Speed; //移動速度
}
[Serializable]
public enum CharacterType
{
    Army,
    Airforce,
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class DataDownLoad : MonoBehaviour
{
    private static string _apiurl = "https://script.google.com/macros/s/AKfycbxiigdL73WaYZvZVSA1SgEk54CqI2zvFk4c1xIC5YA1NlN5GLJ_mqO_otWPPBPfLUEp/exec";
    
    private static CharacterData _characterData = new CharacterData();
    
    [MenuItem("MyTool/DebugConsole")]
    private static void DebugData()
    {
        foreach (var item in _characterData.baseData)
        {
            Debug.Log(string.Join(",", item.CharacterID, item.CharacterName, item.Type, item.Cost, item.Hp, item.Atk, item.Speed) + "\n");
        }
    }
    #if UNITY_EDITOR
    [MenuItem("MyTool/Download Data")]
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
                Debug.Log(str);
                
                // ResponseData クラスで Unity で扱えるデータ化
                _characterData = JsonUtility.FromJson<CharacterData>(str);

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
    public string Type; //キャラクターの種類
    public int Cost; //召喚するのに必要なコイン
    public int Hp; //最大HP
    public int Atk; //攻撃力
    public float Speed; //移動速度
}
[Serializable]
public enum CharacterType
{
    Army,
    Airforce
}
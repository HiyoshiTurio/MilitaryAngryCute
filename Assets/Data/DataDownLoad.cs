using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class DataDownLoad : MonoBehaviour
{
    private string _apiurl = "https://script.google.com/macros/s/AKfycbxiigdL73WaYZvZVSA1SgEk54CqI2zvFk4c1xIC5YA1NlN5GLJ_mqO_otWPPBPfLUEp/exec";

    CharacterData _characterData = new CharacterData();

    public void DebugData()
    {
        for (int i = 0; i < _characterData.baseData.Length; i++)
        {
            Debug.Log(_characterData.baseData[i].CharacterName);
            Debug.Log(_characterData.baseData[i].Type);
            Debug.Log(_characterData.baseData[i].Cost);
            Debug.Log(_characterData.baseData[i].Hp);
            Debug.Log(_characterData.baseData[i].Atk);
            Debug.Log(_characterData.baseData[i].Speed);
        }
    }
    public void GetDataCore()
    {
        // HTTP リクエストを非同期処理を待つためコルーチンとして呼び出す
        StartCoroutine("GetData");
    }

    IEnumerator GetData()
    {
        // HTTP リクエストする(GET メソッド) UnityWebRequest を呼び出し
        // アクセスする先は変数 urlAPI で設定
        UnityWebRequest request = UnityWebRequest.Get(_apiurl);

        // リクエスト開始
        yield return request.SendWebRequest();

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
                _characterData= JsonUtility.FromJson<CharacterData>(str);

                break;
        }
    }
}
[Serializable]
public class CharacterData
{
    public CharacterDataBase[] baseData;
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
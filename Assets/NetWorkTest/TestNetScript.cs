using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestNetScript : MonoBehaviour
{
    [SerializeField] private Text text;
    private string _apiurl = "https://script.google.com/macros/s/AKfycbxZew23SsSE6kssATeK2Ce9HAZWzz9dYDJeRhWrMjPDUokGEhLd7J4DJJK0oIVcGOOx/exec";
    // https://docs.google.com/spreadsheets/d/1U3KEg9mNL_jV2zVUPCAJ-I6LR42jMWu2OnHz03v4lWU/edit?gid=0#gid=0
    ResponseData responseData;
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
                string str = "{\"response\":" + tmp + "}";

                // ResponseData クラスで Unity で扱えるデータ化
                responseData = JsonUtility.FromJson<ResponseData>(str);
                text.text = string.Join(" ", responseData.response[0].Name, responseData.response[0].Cost);
                text.text += string.Join(" ", responseData.response[1].Name, responseData.response[1].Cost);

                break;
        }
    }
}
[Serializable]
public class ResponseData
{
    public List<ResponseDataItem> response;
}
[Serializable]
public class ResponseDataItem
{
    public string Name;
    public int Cost;
}

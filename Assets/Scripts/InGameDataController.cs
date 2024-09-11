using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InGameDataController : MonoBehaviour
{
    private static InGameDataController _instance;
    private GameObject characterPrefab; //キャラクタープレハブ
    [SerializeField] private GameObject characterCamp; //キャラクターの出撃地点
    [SerializeField] private CharacterData characterData; //キャラクターデータ
    [SerializeField] private GameObject goalObject; //ゴールオブジェクト
    private int _kawaiiCoin = 100; //インゲームでキャラクターを召喚するために使うコインの残り枚数
    public static InGameDataController Instance => _instance;
    public CharacterData CharacterData => characterData;

    private void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        var a = Addressables.LoadAssetAsync<GameObject>("Character");
        characterPrefab = a.WaitForCompletion();
    }

    public void SummonCharacter(int id)
    {
        var character = Instantiate(characterPrefab, characterCamp.transform.position, Quaternion.identity);
        var characterBase = character.GetComponent<CharacterBase>();
        characterBase.id = id;
    }

    public void TouchedGoal()
    {
        Debug.Log("Goal touched!");
    }
}

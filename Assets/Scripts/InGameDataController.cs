using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InGameDataController : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab; //キャラクタープレハブ
    [SerializeField] private GameObject characterCamp; //キャラクターの出撃地点
    private int _kawaiiCoin = 100; //インゲームでキャラクターを召喚するために使うコインの残り枚数
    public void SummonCharacter(int id)
    {
        var characterBase = Instantiate(characterPrefab, characterCamp.transform.position, Quaternion.identity)
            .GetComponent<CharacterData>();
    }
}

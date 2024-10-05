using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public int id;
    private float _moveSpeed;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _moveSpeed = InGameDataController.Instance.CharacterData.baseData[id].Speed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * (_moveSpeed * 0.03f);
    }
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
public enum CharacterType
{
    Army,
    Airforce,
}
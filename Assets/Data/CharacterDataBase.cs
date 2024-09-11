using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/CharacterDataBase")]
public class CharacterDataBase : ScriptableObject
{
    public string Name; //キャラクターの名前
    public int Cost; //召喚するのに必要なコイン
    public int Hp; //最大HP
    public int Atk; //攻撃力
    public float Speed; //移動速度
}

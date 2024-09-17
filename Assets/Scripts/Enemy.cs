using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData _enemyData;
}

public class EnemyData
{
    public int EnemyId;
    public string EnemyName;
    public CharacterType EnemyType;
    public int Health;
    public int Attack;
}
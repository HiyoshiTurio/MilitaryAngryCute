using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
[CreateAssetMenu(menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] public CharacterDataBase[] baseData;
}

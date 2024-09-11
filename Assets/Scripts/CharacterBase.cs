using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
}
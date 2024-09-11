using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    private Image _image;
    private float _moveSpeed;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _moveSpeed = InGameDataController.Instance.CharacterData.baseData[0].Speed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * (_moveSpeed * 0.03f);
    }
}
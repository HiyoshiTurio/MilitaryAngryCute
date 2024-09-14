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
    private void Awake()
    {
        
    }

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
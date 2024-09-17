using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
    private FieldObject _fieldObject;
    public float Duration
    {
        get { return _fieldObject.Duration; }
        set { _fieldObject.Duration = value; }
    }
}
[Serializable]
public class FieldObjectData
{
    public float duration; //Objectの耐久力
}

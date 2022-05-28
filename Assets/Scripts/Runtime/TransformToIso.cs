using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToIso : MonoBehaviour
{
    [SerializeField] bool _AlignWithWorldRotation;
    private void Awake()
    {
       if (_AlignWithWorldRotation) this.transform.rotation = IsometricSystem.WorldRotation;
    }
    private void OnValidate()
    {
       if (_AlignWithWorldRotation) this.transform.rotation = IsometricSystem.WorldRotation;
    }
}

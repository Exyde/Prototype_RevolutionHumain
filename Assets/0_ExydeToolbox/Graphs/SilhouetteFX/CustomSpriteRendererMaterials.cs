using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Small component for applying multiple materials on a Sprite Renderer, since it's not exposed by default.
///</summary>
[RequireComponent (typeof(SpriteRenderer))]
public class CustomSpriteRendererMaterials : MonoBehaviour
{
    [SerializeField] Material[] _materials;

    void OnValidate(){
        GetComponent<SpriteRenderer>().materials = _materials;
    }

    void Awake(){
        GetComponent<SpriteRenderer>().materials = _materials;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Small component for applying multiple materials on a Sprite Renderer, since it's not exposed by default.
///</summary>
[RequireComponent (typeof(SpriteRenderer))]
public class CustomSpriteRendererMaterials : MonoBehaviour
{
    [SerializeField] bool _overrideRendererMaterials;
    [SerializeField] Material[] _materials;
    

    void OnValidate(){
       if(_overrideRendererMaterials) GetComponent<SpriteRenderer>().materials = _materials;
    }

    void Awake(){
       if(_overrideRendererMaterials) GetComponent<SpriteRenderer>().materials = _materials;
    }
}

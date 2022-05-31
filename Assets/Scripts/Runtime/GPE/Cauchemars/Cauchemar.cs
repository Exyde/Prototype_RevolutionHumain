using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauchemar : Entity
{

    [SerializeField] protected string _playerTag = "Player";
    [SerializeField] protected bool _isPlayerInZone = false; 
    [SerializeField] [Range (0, 100)] protected float _SanityDecayPercent = 100f;

    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _playerTag){
            OnCauchemarEnter();
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _playerTag){
            OnCauchemarExit();
        }
    }

    protected virtual void OnCauchemarEnter(){
            _isPlayerInZone = true;
    }

    protected virtual void OnCauchemarStay(){
        
    }

    
    protected virtual void OnCauchemarExit(){
            _isPlayerInZone = false;
    }

}

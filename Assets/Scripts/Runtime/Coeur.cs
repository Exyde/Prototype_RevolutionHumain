using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur : Entity{
    //Todo :
        // Broadcast Event to the MentalJauge
        // Implement cooldown & reactivation
        // Add the correct sprites
        // Refacto with animations or mesh
        
    #region Serialized Fields
    [Header ("Gameplay Datas")]
    [SerializeField]
    [Range (0, 120)] int _cooldownInSeconds;

    [SerializeField]
    [Range (0, 100)] float _mentalStabilityHealingPercentage;

    [SerializeField] bool _isActive;
    [SerializeField] string _playerTag;

    [Header ("Sprites, Textures, Anims References")]
    [SerializeField] Sprite _activeSprite;
    [SerializeField] Sprite _inactiveSprite;
    #endregion

    #region Private Fields & components
    private SpriteRenderer _renderer;
    private float _currentCooldown;
    #endregion

    #region Unity Callbacks
    private void Awake(){
        _renderer = GetComponent<SpriteRenderer>();
        _currentCooldown = 0f;
    }

    private void Update(){

    }
    #endregion
    public void Activate(){
        _isActive = true;
        _renderer.sprite = _activeSprite;
    }

    public void Desactivate(){
        Debug.Log("Player Triggered this Coeur");
        _isActive = false;
        _renderer.sprite = _inactiveSprite;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == _playerTag && _isActive){
            Desactivate();
        }
    }
}

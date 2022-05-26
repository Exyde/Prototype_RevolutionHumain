using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeur : Entity{
    //Todo :
        // Broadcast Event to the MentalJauge
        
    #region Serialized Fields
    [Header ("Gameplay Datas")]
    [SerializeField]
    [Range (0, 120)] int _cooldownInSeconds;

    [SerializeField]
    [Range (0, 100)] float _mentalStabilityHealingPercentage;

    [SerializeField] bool _isActive;
    [SerializeField] string _playerTag;

    [Header ("Sprites, Textures, Anims References")]
    [SerializeField] Material _activeMat;
    [SerializeField] Material _inactiveMat;
    #endregion

    #region Private Fields & components
    private MeshRenderer _renderer;
    private float _currentCooldown;
    #endregion

    #region Unity Callbacks
    private void Awake(){
        _renderer = GetComponent<MeshRenderer>();
        Activate();
    }

    private void Update(){
        if (_isActive) return;
        HandleCooldown();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == _playerTag && _isActive){
            Desactivate();
        }
    }
    #endregion
    
    #region Methods
    public void Activate(){
        _isActive = true;
        _currentCooldown = 0f;
        _renderer.sharedMaterial = _activeMat;
    }

    public void Desactivate(){
        _isActive = false;
        _renderer.sharedMaterial = _inactiveMat;
        GameManager._instance.AdjustSanity(_mentalStabilityHealingPercentage);
    }

    private void HandleCooldown(){
        if (_currentCooldown < _cooldownInSeconds){
            _currentCooldown += Time.deltaTime;
        }

        if (_currentCooldown >= _cooldownInSeconds){
            Activate();
        }
    }

    #endregion

}

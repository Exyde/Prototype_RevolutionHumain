using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerCauchemar : MonoBehaviour
{
    [SerializeField] string _playerTag = "Player";
    [SerializeField] float _TimeBtwDecay = 1f;
    [SerializeField] [Range (0, 100)] float _SanityDecayPercent = 10f;

    private bool _isPlayerInZone = false;
    float _currentTimer = 0f;

    void Update()
    {
        if (!_isPlayerInZone) return;

        if (_currentTimer < _TimeBtwDecay) _currentTimer += Time.deltaTime;
        if (_currentTimer >= _TimeBtwDecay){
            _currentTimer = 0;
            GameManager._instance.AdjustSanity(-_SanityDecayPercent);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _playerTag){
            _isPlayerInZone = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _playerTag){
            _isPlayerInZone = false;
        }
    }
}

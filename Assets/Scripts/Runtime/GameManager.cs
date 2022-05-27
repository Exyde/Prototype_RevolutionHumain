using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header ("Core references")]
    [SerializeField] GameObject _player;
    
    [SerializeField] GameObject _cameraPivot;
    [SerializeField] MentalJauge _mentalJauge;

    [SerializeField] int _gameDurationInSeconds = 200;
    public int GetGameDuration() => _gameDurationInSeconds;


    void Awake()
    {
        if (_instance != null && _instance != this) Destroy (this.gameObject);
        _instance = this;
        
        _mentalJauge.gameObject.SetActive(true);
    }
    public void ReloadGame(){
        SceneManager.LoadScene(0);
    }

    public void AdjustSanity(float amount){
        _mentalJauge.UpdateSanity (amount);
    }
}

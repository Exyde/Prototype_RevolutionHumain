using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalJauge : MonoBehaviour
{
    #region Serialized Fields

    [Header ("Debug")]
    [SerializeField] bool _decaySanity;
    [SerializeField] bool _displaySanityPanelFeedback;

    [Header ("Gameplay Data")]
    [SerializeField] [Range (0, 100)] float _mentalSanity;
    public float GetSanityPercent() => _mentalSanity;
    float _percentLossPerSecond;

    [Header ("References")]
    [SerializeField] GameObject _panelSanity;
    [SerializeField] Image _imgPanelSanity;
    [SerializeField] Image _imgSanityJauge;
    #endregion
   
    #region Unity Callbacks
   void Start()
    {
        _mentalSanity = 100f;
        _percentLossPerSecond = _mentalSanity / (float) GameManager._instance.GetGameDuration();


        //Temp.
        if (!_decaySanity) GetComponent<TimerEvent>().Stop();
        else if (_decaySanity) GetComponent<TimerEvent>().Run();
    }
    #endregion

    #region Methods
    void DecaySanity(){
        _mentalSanity -= _percentLossPerSecond;

        UpdateDisplay();
        CheckSanity();
    }

    public void DecaySanityTimerCallback(){
        DecaySanity();
    }

    public void UpdateSanity(float amount){
        _mentalSanity += amount;

        UpdateDisplay();
        CheckSanity();
    }

    private void CheckSanity(){
        if (_mentalSanity <= 0){
            GameManager._instance.ReloadGame();
        }
    }

    void UpdateDisplay(){
        //Img
        _imgSanityJauge.fillAmount = _mentalSanity / 100;

        if (!_displaySanityPanelFeedback) return;
        //Panel
        float t = 1.0f - (_mentalSanity/100.0f);
        float alpha = Mathf.Lerp(0, 1, t );
        Color c = new Color(0, 0, 0, alpha);
        _imgPanelSanity.color = c;
    }
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalJauge : MonoBehaviour
{
    #region Serialized Fields
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
        this.gameObject.SetActive(true);
        _mentalSanity = 100f;
        _percentLossPerSecond = _mentalSanity / (float) GameManager._instance.GetGameDuration();
        InvokeRepeating("DecaySanity", 0, 1);
        InvokeRepeating("UpdateDisplay", 0, 1);
    }
    #endregion

    #region Methods
    void DecaySanity(){
        _mentalSanity -= _percentLossPerSecond;

        CheckSanity();
    }

    public void UpdateSanity(float amount){
        _mentalSanity += amount;

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

        //Panel
        float t = 1.0f - (_mentalSanity/100.0f);
        float alpha = Mathf.Lerp(0, 1, t );
        Color c = new Color(0, 0, 0, alpha);
        _imgPanelSanity.color = c;
    }
    #endregion

}

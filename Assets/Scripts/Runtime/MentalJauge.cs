using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalJauge : MonoBehaviour
{
    [Header ("Gameplay Data")]
    [SerializeField] [Range (0, 100)] float _mentalSanity;
    [SerializeField] int _gameDurationInSeconds = 200;
    float _percentLossPerSecond;

    [Header ("References")]
    [SerializeField] GameObject _panelSanity;
    [SerializeField] Image _imgPanelSanity;
    [SerializeField] Image _imgSanityJauge;

    void Start()
    {
        // _panelSanity.GetComponent<Image>();

        _mentalSanity = 100f;
        _percentLossPerSecond = _mentalSanity / (float)_gameDurationInSeconds;
        InvokeRepeating("DecaySanity", 0, 1);
        InvokeRepeating("UpdateDisplay", 0, 1);

    }

    void DecaySanity(){
        _mentalSanity -= _percentLossPerSecond;
    }

    void UpdateDisplay(){
        _imgSanityJauge.fillAmount = _mentalSanity / 100;

        float t = 1.0f - (_mentalSanity/100.0f);
        Debug.Log(t);
        float alpha = Mathf.Lerp(0, 1, t );
        Color c = new Color(0, 0, 0, alpha);
        Debug.Log(c);


        _imgPanelSanity.color = c;
    }
}

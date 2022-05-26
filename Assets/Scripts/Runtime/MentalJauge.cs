using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalJauge : MonoBehaviour
{
    [Header ("Gameplay Data")]
    [SerializeField] [Range (0, 100)] float _mentalSanity;

    [Header ("References")]
    [SerializeField] GameObject _panelSanity;
    [SerializeField] Image _imgSanityJauge;


    void Start()
    {
        _mentalSanity = 100f;
    }

    void Update()
    {
        
    }
}

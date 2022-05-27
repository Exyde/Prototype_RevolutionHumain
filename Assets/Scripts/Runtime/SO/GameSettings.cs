using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{

    [Header ("Main Loop")]
    [SerializeField] [Range (0, 200)] float _gameDurationInSeconds;

    [Header ("Coeur")]
    [SerializeField] [Range (0, 200)] float _cooldownInSeconds;
    [SerializeField] [Range (0, 200)] float _SanityDecayPercent;


}

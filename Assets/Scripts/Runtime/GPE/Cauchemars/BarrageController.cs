using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageController : MonoBehaviour
{

    [Header ("Quand tu ramasses l'objet")]
    [SerializeField] List<BarrageCauchemar> _barragesToRemoveOnRammassage;
    [Header ("Quand tu poses l'objet dans le HUB voila quoi")]
    [SerializeField] List<BarrageCauchemar> _barragesToRemoveOnPosageHub;

}

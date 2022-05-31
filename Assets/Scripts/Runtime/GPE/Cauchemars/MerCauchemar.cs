using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerCauchemar : Cauchemar
{
    protected override void OnCauchemarEnter()
    {
        base.OnCauchemarEnter();
        GameManager._instance.AdjustSanity(-_SanityDecayPercent);   
    }

}

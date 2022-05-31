using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageCauchemar : Cauchemar
{
    TimerEvent _timerEvent;

    private void Awake()
    {
        _timerEvent = GetComponent<TimerEvent>();
        _timerEvent.Stop();
    }
    protected override void OnCauchemarEnter()
    {
        base.OnCauchemarEnter();
        GameManager._instance.AdjustSanity(-_SanityDecayPercent);
        _timerEvent.Run();  
    }

    protected override void OnCauchemarExit()
    {
        base.OnCauchemarEnter();
        _timerEvent.Stop();  
    }

    protected override void OnCauchemarStay(){
        GameManager._instance.AdjustSanity(-_SanityDecayPercent);   
    }

    public void OnCauchemarStayTimerCallback(){
        OnCauchemarStay();
    }


}

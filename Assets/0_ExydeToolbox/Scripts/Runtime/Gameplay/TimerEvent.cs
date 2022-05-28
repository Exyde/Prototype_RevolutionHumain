using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    [Header ("Debug")]
    [SerializeField] string _timerName;
    
    [Header ("Timer Data")]
    [SerializeField] float _timerDuration;
    [SerializeField] float _timeElapsed;
    [SerializeField] bool _isLoopTimer;
    [SerializeField] UnityEvent _event;

    private void Update()
    {
        if (_timeElapsed < _timerDuration){
            _timeElapsed += Time.deltaTime;
        }

        if (_timeElapsed >= _timerDuration){
            if (_isLoopTimer){
                _timeElapsed = 0;
                TriggerTimerEvent();
            }
            else{
                TriggerTimerEvent();
                Debug.Log("Event not looping, destroying component.");
                Destroy(this);
            }
        }
    }

    private void TriggerTimerEvent(){
        if (_event != null){
            _event.Invoke();
        }
    }
}


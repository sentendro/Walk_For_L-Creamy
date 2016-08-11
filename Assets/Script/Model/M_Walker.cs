using UnityEngine;
using System.Collections;
using System;

public class M_Walker : MonoBehaviour
{
    private float _step;
    private float _time;
    private GameObject C_Refrig;
    private float _loLim = 0.005F;
    private float _hiLim = 0.3F;
    private bool stateH = false;
    private float _fHigh = 8.0F;
    private float _curAcc = 0F;
    private float _fLow = 0.2F;
    private float _avgAcc;
    float deltaTime;
    void Start()
    {
        this._step = 0;
        this._time = 0;
        this.deltaTime = 0;
    }

    void Update()
    {
        
        deltaTime += Time.deltaTime;
        this._time = (int)deltaTime;
        this._step += (Time.deltaTime)*4;
    }
    void getStep(C_Refrig script)
    {
        script._step = (int) this._step;
    }

    void getTime(C_Refrig script)
    {
        script._time = (int) this._time;
    }

    public void stepDetector()
    {
        _curAcc = Mathf.Lerp(_curAcc, Input.acceleration.magnitude, Time.deltaTime * _fHigh);
        _avgAcc = Mathf.Lerp(_avgAcc, Input.acceleration.magnitude, Time.deltaTime * _fLow);
        float delta = _curAcc - _avgAcc;
        if (!stateH)
        {
            if (delta > _hiLim)
            {
                stateH = true;
                this._step++;
            }
        }
        else {
            if (delta < _loLim)
            {
                stateH = false;
            }
        }
        _avgAcc = _curAcc;
    }
}

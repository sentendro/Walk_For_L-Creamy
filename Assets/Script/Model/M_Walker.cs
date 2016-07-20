using UnityEngine;
using System.Collections;
using System;

public class M_Walker : MonoBehaviour
{
    private float _step;
    private float _time;
    private GameObject C_Refrig;
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
}

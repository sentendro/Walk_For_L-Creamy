using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class M_Walker : MonoBehaviour
{
    private int _step;
    private float _time;
    private GameObject C_Refrig;
    
    void Start()
    {
        this._step = 0;
        this._time = 0;
    }

    void Update()
    {
        this._time += Time.deltaTime;
    }
    void getStep(C_Refrig script)
    {
        script._step = this._step;
    }

    void getTime(C_Refrig script)
    {
        script._time = (int) this._time;
    }
}

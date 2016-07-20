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
        C_Refrig = GameObject.Find("C_Refrig");
    }

    void Update()
    {
        this._time += Time.deltaTime;
        print((int)this._time);
    }
    void getStep()
    {
        if(C_Refrig != null)
            C_Refrig.SendMessage("setStep", this._step);
    }

    void getTime()
    {
        if (C_Refrig != null)
            C_Refrig.SendMessage("setTime", this._step);
    }
}

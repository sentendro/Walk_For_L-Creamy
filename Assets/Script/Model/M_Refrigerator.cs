﻿using UnityEngine;
using System.Collections;
using System;

public class M_Refrigerator : MonoBehaviour
{
    int _lastTime;
    int _Battery;
    int _Temparature;
    int _Type;
    int _Level;
    

    void Start()
    {
        this._lastTime = 0;
        this._Battery = 5;
        this._Temparature = 0;
        this._Type = 0;
        this._Level = 0;
    }
    void setLastTime(int givenTime)
    {
        this._lastTime = givenTime;
    }
    void CalcBattery(C_Refrig script)
    {
        if (this._Battery >0)
            this._Battery = this._Battery - (script.getTime() - this._lastTime);
        script.setBattery(this._Battery);
        setLastTime(script.getTime());
    }
    void CalcTemparature()
    {

    }
    void CalcType()
    {

    }
    void CalcLevel()
    {

    }
}

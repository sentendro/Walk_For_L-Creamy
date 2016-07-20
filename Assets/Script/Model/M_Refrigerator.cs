using UnityEngine;
using System.Collections;
using System;

[Serializable]
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

        this._Battery = 0;
        this._Temparature = 0;
        this._Type = 0;
        this._Level = 0;
    }
    void CalcBattery(C_Refrig script)
    {
        this._Battery = this._Battery + (script._time - this._lastTime);
        script._battery = this._Battery;
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

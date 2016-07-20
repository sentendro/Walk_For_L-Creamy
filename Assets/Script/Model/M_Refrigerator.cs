using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class M_Refrigerator: MonoBehaviour
{
    int _lastTime;

    int _Battery;
    int _Temparature;
    int _Type;
    int _Level;

    GameObject C_Refrig;

    void Start()
    {
        this._lastTime = 0;

        this._Battery = 0;
        this._Temparature = 0;
        this._Type = 0;
        this._Level = 0;

        this.C_Refrig = GameObject.Find("C_refrig");
    }
    void CalcBattery(int currentTime)
    {
        this._Battery = this._Battery + (currentTime - this._lastTime);
        C_Refrig.SendMessage("setBattery", this._Battery);
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

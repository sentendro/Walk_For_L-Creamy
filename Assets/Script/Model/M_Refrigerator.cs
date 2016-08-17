using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class M_Refrigerator : MonoBehaviour
{
    private int _LastTime;
    private int _Battery;
    private int _Temparature;
    private int _Type;
    private int _Level;

    #region getter
    public int getLastTime()                            { return this._LastTime; }
    public int getBattery()                             { return this._Battery; }
    public int getTemparature()                         { return this._Temparature; }
    public int getType()                                { return this._Type; }
    public int getLevel()                               { return this._Level; }
    #endregion

    #region setter
    public void setLastTime(int givenLastTime)          { this._LastTime = givenLastTime; }
    public void setBattery(int givenBattery)            { this._Battery = givenBattery; }
    public void setTemparature(int givenTemparature)    { this._Temparature = givenTemparature; }
    public void setType(int givenType)                  { this._Type = givenType; }
    public void setLevel(int givenLevel)                { this._Level = givenLevel; }
    #endregion

    void Start()
    {
        
        this._LastTime = 0;
        this._Battery = 100;
        this._Temparature = 0;
        this._Type = 0;
        this._Level = 0;
    }
    public void setUp(M_Refrigerator prevRefrig)
    {
        this._LastTime = prevRefrig._LastTime;
        this._Battery = prevRefrig._Battery;
        this._Temparature = prevRefrig._Temparature;
        this._Type = prevRefrig._Type;
        this._Level = prevRefrig._Level;
    }
    void CalcBattery(C_Refrig script)
    {
        if (this._Battery >0)
            this._Battery = this._Battery - (script.getTime() - this._LastTime);
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

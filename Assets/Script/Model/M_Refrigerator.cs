using UnityEngine;
using System.Collections;
using System;

public class M_Refrigerator : MonoBehaviour
{

    private GameObject Controller;
    private GameObject C_Serializer;
    private Refrigerator CurrentRefrig;

    void Awake()
    {
        C_Serializer = GameObject.Find("C_Serializer");
        CurrentRefrig = new Refrigerator();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("REFRIGINFO_SAVE_KEY"))
        {
            C_Serializer.SendMessage("LoadRefrig");
        }
        else {
            CurrentRefrig.setLastTime(DateTime.Now);
            CurrentRefrig.setBattery(100);
            CurrentRefrig.setTemparature(-18);
            CurrentRefrig.setType(0);
            CurrentRefrig.setLevel(0);
        }
    }
    void CalcBattery(TimeSpan givenTime)
    {
        if (CurrentRefrig.getBattery() >= 0)
        {
            if(CurrentRefrig.getBattery() - ((givenTime.Days * 86400) + (givenTime.Hours * 3600) + (givenTime.Seconds)) > 0)
                CurrentRefrig.setBattery(CurrentRefrig.getBattery() - ((givenTime.Days * 86400) + (givenTime.Hours * 3600) + (givenTime.Seconds)));
            else
            {
                int remainTime = ((givenTime.Days * 86400) + (givenTime.Hours * 3600) + (givenTime.Seconds)) - CurrentRefrig.getBattery();
                this.CalcTemparature(remainTime);
            }
        }
    }
    void CalcTemparature(int givenTime)
    {

    }
    void ControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) Controller = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) Controller = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) Controller = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) Controller = GameObject.Find("C_MyPage");
    }
}

[Serializable]
public class Refrigerator
{
    private DateTime _LastTime;
    private int _Battery;
    private int _Temparature;
    private int _Type;
    private int _Level;

    #region getter
    public DateTime getLastTime() { return this._LastTime; }
    public int getBattery() { return this._Battery; }
    public int getTemparature() { return this._Temparature; }
    public int getType() { return this._Type; }
    public int getLevel() { return this._Level; }
    #endregion

    #region setter
    public void setLastTime(DateTime givenLastTime) { this._LastTime = givenLastTime; }
    public void setBattery(int givenBattery) { this._Battery = givenBattery; }
    public void setTemparature(int givenTemparature) { this._Temparature = givenTemparature; }
    public void setType(int givenType) { this._Type = givenType; }
    public void setLevel(int givenLevel) { this._Level = givenLevel; }
    #endregion

    public void setUp(Refrigerator prevRefrig)
    {
        this._LastTime = prevRefrig.getLastTime();
        this._Battery = prevRefrig.getBattery();
        this._Temparature = prevRefrig._Temparature;
        this._Type = prevRefrig._Type;
        this._Level = prevRefrig._Level;
    }
}
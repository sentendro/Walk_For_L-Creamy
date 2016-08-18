using UnityEngine;
using System.Collections;
using System;

public class M_Refrigerator : MonoBehaviour
{

    private GameObject Controller;
    private GameObject C_Serializer;
    private Refrigerator CurrentRefrig;

    #region sender
    void sendBattery()
    {
        Controller.SendMessage("setBattery", CurrentRefrig.getBattery());
    }
    void sendTemperature()
    {
        Controller.SendMessage("setTemperature", CurrentRefrig.getTemperature());
    }
    #endregion

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
        else
        {
            CurrentRefrig.setLastTimeForBattery(DateTime.Now);
            CurrentRefrig.setLastTimeForTemperature(DateTime.Now);
            CurrentRefrig.setBattery(100);
            CurrentRefrig.setTemperature(0);
            CurrentRefrig.setType(0);
            CurrentRefrig.setLevel(0);
        }
    }
    void Update()
    {
        ControllerCheck();
    }
    void CalcBattery(DateTime CurrentTime)
    {
        TimeSpan givenTime = CurrentTime - CurrentRefrig.getLastTimeForBattery();
        if (givenTime.Seconds < 1)
            return;
        int remainTime = ((givenTime.Days * 86400) + (givenTime.Hours * 3600) + (givenTime.Seconds));
        Debug.Log(remainTime.ToString());
        if (CurrentRefrig.getBattery() >= 0)
        {
            if (CurrentRefrig.getBattery() - remainTime > 0)
            {
                CurrentRefrig.setBattery(CurrentRefrig.getBattery() - remainTime);
                Controller.SendMessage("setBattery", CurrentRefrig.getBattery());
            }
            else
            {
                remainTime -= CurrentRefrig.getBattery();
                CurrentRefrig.setBattery(0);
                Controller.SendMessage("setBattery", 0);
            }
        }
        CurrentRefrig.setLastTimeForBattery(CurrentTime);
    }
    void CalcTemperature(DateTime CurrentTime)
    {
        TimeSpan givenTime = CurrentTime - CurrentRefrig.getLastTimeForTemperature();
        if (givenTime.Seconds < 1)
            return;
        int remainTime = ((givenTime.Days * 86400) + (givenTime.Hours * 3600) + (givenTime.Seconds));
        Debug.Log(remainTime.ToString());
        if (CurrentRefrig.getBattery() > 0)
        {
            if (CurrentRefrig.getTemperature() >= -18)
            {
                double TemperatureSpan = CurrentRefrig.getTemperature() - (-18);
                if (CurrentRefrig.getTemperature() - (0.4 * remainTime) < -18)
                {
                    this.CurrentRefrig.setTemperature(-18);
                }
                else
                {
                    this.CurrentRefrig.setTemperature(CurrentRefrig.getTemperature() - (0.4 * remainTime));
                }
                this.Controller.SendMessage("setTemperature", this.CurrentRefrig.getTemperature());
            }
        }
        CurrentRefrig.setLastTimeForTemperature(CurrentTime);
    }
    void ControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) Controller = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) Controller = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) Controller = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) Controller = GameObject.Find("C_MyPage");
    }
    public void setUp(Refrigerator prevRefrig)
    {
        CurrentRefrig.setLastTimeForBattery(prevRefrig.getLastTimeForBattery());
        CurrentRefrig.setLastTimeForTemperature(prevRefrig.getLastTimeForTemperature());
        CurrentRefrig.setBattery(prevRefrig.getBattery());
        CurrentRefrig.setLevel(prevRefrig.getLevel());
        CurrentRefrig.setTemperature(prevRefrig.getTemperature());
        CurrentRefrig.setType(prevRefrig.getType());
    }
}

[Serializable]
public class Refrigerator
{
    private DateTime _LastTimeForBattery;
    private DateTime _LastTimeForTemperature;
    private int _Battery;
    private double _Temperature;
    private int _Type;
    private int _Level;

    #region getter
    public DateTime getLastTimeForBattery() { return this._LastTimeForBattery; }
    public DateTime getLastTimeForTemperature() { return this._LastTimeForTemperature; }
    public int getBattery() { return this._Battery; }
    public double getTemperature() { return this._Temperature; }
    public int getType() { return this._Type; }
    public int getLevel() { return this._Level; }
    #endregion

    #region setter
    public void setLastTimeForBattery(DateTime givenLastTimeForBattery) { this._LastTimeForBattery = givenLastTimeForBattery; }
    public void setLastTimeForTemperature(DateTime givenLastTimeForTemperature) { this._LastTimeForTemperature = givenLastTimeForTemperature; }
    public void setBattery(int givenBattery) { this._Battery = givenBattery; }
    public void setTemperature(double givenTemparature) { this._Temperature = givenTemparature; }
    public void setType(int givenType) { this._Type = givenType; }
    public void setLevel(int givenLevel) { this._Level = givenLevel; }
    #endregion
}
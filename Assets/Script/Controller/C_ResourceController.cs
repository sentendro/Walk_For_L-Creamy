using UnityEngine;
using System.Collections;
using System;

public class C_ResourceController : MonoBehaviour
{
    public GameObject M_Walker;
    public GameObject M_Player;
    public GameObject M_Refrigerator;
    private GameObject View;

    int _step;
    int _power;
    int _battery;
    int _touch;
    int _gold;
    double _temperature;
    DateTime _CurrentTime;


    // Update is called once per frame
    void Start()
    {
        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");


        this._step = 0;
        this._power = 0;
        this._CurrentTime = DateTime.Now;
        this._battery = 0;
        this._temperature = 0;
    }
    void ViewCheck()
    {
        if (GameObject.Find("V_Logo") != null) View = GameObject.Find("V_Logo");
        if (GameObject.Find("V_Refrig") != null) View = GameObject.Find("V_Refrig");
        if (GameObject.Find("V_Shop") != null) View = GameObject.Find("V_Shop");
        if (GameObject.Find("V_MyPage") != null) View = GameObject.Find("V_MyPage");
    }
    void Update()
    {
        ViewCheck();
        if (View.name != "V_Logo")
        {
            renewalPower();
            renewalGold();
            renewalTemperature();
            renewalBattery();
        }
    }

    #region setter
    public void setStep(int givenStep) { this._step = givenStep; }
    public void setPower(int givenPower) { this._power = givenPower; }
    public void setCurrentTime(DateTime givenTime) { this._CurrentTime = givenTime; }
    public void setBattery(int givenBattery) { this._battery = givenBattery; }
    public void setTouch(int givenTouch) { this._touch = givenTouch; }
    public void setGold(int givenGold) { this._gold = givenGold; }
    public void setTemperature(double giveTemperature) { this._temperature = giveTemperature; }
    #endregion

    #region getter
    public int getStep() { return this._step; }
    public int getPower() { return this._power; }
    public DateTime getCurrentTime() { return this._CurrentTime; }
    public int getBattery() { return this._battery; }
    public int getTouch() { return this._touch; }
    public int getGold() { return this._gold; }
    public double getTemperature() { return this._temperature; }
    #endregion

    void renewalPower()
    {
        M_Walker.SendMessage("sendStep");
        M_Walker.SendMessage("sendTouch");
        M_Player.SendMessage("sendPower");
        M_Player.SendMessage("CalcPowerwithStep", this._step);
        M_Player.SendMessage("CalcPowerwithTouch", this._touch);
        View.SendMessage("showPower", this._power);
    }

    void renewalBattery()
    {
        M_Walker.SendMessage("sendCurrentTime");
        M_Refrigerator.SendMessage("CalcBattery", this._CurrentTime);
        View.SendMessage("showBattery", this._battery);
    }
    void renewalGold()
    {
        M_Player.SendMessage("sendGold");
        View.SendMessage("showGold", this._gold);
    }
    void renewalTemperature()
    {
        M_Walker.SendMessage("sendCurrentTime");
        M_Refrigerator.SendMessage("CalcTemperature", this._CurrentTime);
        View.SendMessage("showTemperature", this._temperature);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class C_Refrig : MonoBehaviour {
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject V_Refrig;

    int _step;
    int _power;
    int _battery;
    int _touch;
    int _gold;
    DateTime _CurrentTime;


    // Update is called once per frame
    void Start () {

        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");
        V_Refrig = GameObject.Find("V_Refrig");


        this._step = 0;
        this._power = 0;
        this._CurrentTime = DateTime.Now;
        this._battery = 0;
	}
    void Update()
    {
        renewalPower();
        renewalBattery();
        renewalGold();
    }

    #region setter
    public void setStep(int givenStep)                      { this._step = givenStep; }
    public void setPower(int givenPower)                    { this._power = givenPower; }
    public void setCurrentTime(DateTime givenTime)          { this._CurrentTime = givenTime;}
    public void setBattery(int givenBattery)                { this._battery = givenBattery; }
    public void setTouch(int givenTouch)                    { this._touch = givenTouch; }
    public void setGold(int givenGold)                      { this._gold = givenGold; }
    #endregion

    #region getter
    public int getStep()                                    { return this._step; }
    public int getPower()                                   { return this._power; }
    public DateTime getCurrentTime()                        { return this._CurrentTime; }
    public int getBattery()                                 { return this._battery; }
    public int getTouch()                                   { return this._touch; }
    public int getGold()                                    { return this._gold; }
    #endregion
    void renewalPower()
    {
        M_Walker.SendMessage("sendStep");
        M_Walker.SendMessage("sendTouch");
        M_Player.SendMessage("sendPower");
        M_Player.SendMessage("CalcPowerwithStep",this._step);
        M_Player.SendMessage("CalcPowerwithTouch", this._touch);
        M_Player.SendMessage("sendPower");
        V_Refrig.SendMessage("showPower",this._power);
    }

    void renewalBattery()
    {
        DateTime _OldTime = this._CurrentTime;
        M_Walker.SendMessage("sendCurrentTime");
        M_Refrigerator.SendMessage("CalcBattery", this._CurrentTime-_OldTime);
        V_Refrig.SendMessage("showBattery", this._battery);
    }
    void renewalGold()
    {
        M_Player.SendMessage("sendGold");
        V_Refrig.SendMessage("showGold", this._gold);
    }
    void Clicker()
    {
        M_Walker.SendMessage("Clicker");
    }
}

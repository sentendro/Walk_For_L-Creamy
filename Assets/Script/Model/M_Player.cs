using UnityEngine;
using System.Collections;
using System;

public class M_Player : MonoBehaviour {
    private GameObject Controller;
    private GameObject C_Serializer;
    private GameObject EachController;
    private Player CurrentPlayer;

    public Player getCurrentPlayer() { return this.CurrentPlayer; }
    void Awake()
    {
        C_Serializer = GameObject.Find("C_serialzier");
        Controller = GameObject.Find("C_ResourceController");
        CurrentPlayer = new Player();
    }

    void Start()
    {

        if (PlayerPrefs.HasKey("PLAYERINFO_SAVE_KEY"))
        {
            C_Serializer.SendMessage("LoadPlayer");
            Debug.Log("Loaded");
        }
        else
        {
            Debug.Log("UnLoaded");
            this.CurrentPlayer.setGold(10000);
            this.CurrentPlayer.setPower(5000);
            this.CurrentPlayer.setLastStep(0);
            this.CurrentPlayer.setLastTouch(0);
        }

    }


    void sendGold()
    {
        Controller.SendMessage("setGold", this.CurrentPlayer.getGold());
    }
    void sendPower()
    {
        Controller.SendMessage("setPower", this.CurrentPlayer.getPower());
    }

    //골드 계산방법 
    void CalcGold(int GivenMoney)
    {
        this.CurrentPlayer.setGold(this.CurrentPlayer.getGold() + GivenMoney);
    }

    //전력 계산방법 : 현재 전력 + (현재 걸음 수 - 마지막 걸음 수)
    void CalcPowerwithStep(int GivenStep)
    {
        this.CurrentPlayer.setPower(this.CurrentPlayer.getPower() + (GivenStep - this.CurrentPlayer.getLastStep())*3);
        this.Controller.SendMessage("setPower", this.CurrentPlayer.getPower());
        this.CurrentPlayer.setLastStep(GivenStep);
    }
    void CalcPowerwithTouch(int GivenTouch)
    {
        this.CurrentPlayer.setPower(this.CurrentPlayer.getPower() + (GivenTouch - this.CurrentPlayer.getLastTouch()));
        this.Controller.SendMessage("setPower", CurrentPlayer.getPower());
        this.CurrentPlayer.setLastTouch(GivenTouch);
    }
    void Update()
    {
        this.EachControllerCheck();
    }
    void EachControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) EachController = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) EachController = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) EachController = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) EachController = GameObject.Find("C_MyPage");
    }
    void setUp(Player prevPlayer)
    {
        CurrentPlayer.setGold(prevPlayer.getGold());
        CurrentPlayer.setPower(prevPlayer.getPower());
        CurrentPlayer.setLastStep(prevPlayer.getLastStep());
        CurrentPlayer.setLastTouch(prevPlayer.getLastTouch());
    }
}

[Serializable]
public class Player
{
    private int _Gold;
    private int _Power;
    private int _LastStep;
    private int _LastTouch;


    #region getter
    public int getGold() { return this._Gold; }
    public int getPower() { return this._Power; }
    public int getLastStep() { return this._LastStep; }
    public int getLastTouch() { return this._LastTouch; }
    #endregion

    #region setter
    public void setGold(int givenGold) { this._Gold = givenGold; }
    public void setPower(int givenPower) { this._Power = givenPower; }
    public void setLastStep(int givenLastStep) { this._LastStep = givenLastStep; }
    public void setLastTouch(int givenLastTouch) { this._LastTouch = givenLastTouch; }
    #endregion

    public Player()
    {

    }
}

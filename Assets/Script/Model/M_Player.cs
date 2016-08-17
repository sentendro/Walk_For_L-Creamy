using UnityEngine;
using System.Collections;
using System;

public class M_Player : MonoBehaviour {
    private int _Gold;
    private int _Power;
    private int _LastStep;
    private GameObject Controller;
    private GameObject C_Serializer;
    #region getter
    public int getGold() { return this._Gold; }
    public int getPower() { return this._Power; }
    public int getLastStep() { return this._LastStep; }
    #endregion

    #region setter
    public void setGold(int givenGold) { this._Gold = givenGold; }
    public void setPower(int givenPower) { this._Power = givenPower; }
    public void setLastStep(int givenLastStep) { this._LastStep = givenLastStep; }
    #endregion

    void setUp(M_Player prevPlayer)
    {
        this._Gold = prevPlayer._Gold;
        this._Power = prevPlayer._Power;
        this._LastStep = prevPlayer._LastStep;
    }
    void Awake()
    {
        C_Serializer = GameObject.Find("C_serialzier");

    }
    void Start()
    {

        this._Gold = 0;
        this._Power = 0;
        this._LastStep = 0;
        
    } 
    void Update()
    {

    }
   

    //골드 계산방법 
    void CalcGold(int GivenMoney)
    {
        this._Gold += GivenMoney;
    }

    //전력 계산방법 : 현재 전력 + (현재 걸음 수 - 마지막 걸음 수)
    void CalcPower(int givenStep)
    {
        this._Power = this._Power + (givenStep - _LastStep);
        Controller.SendMessage("setPower",this._Power);
        setLastStep(givenStep);
    }
    void ControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) Controller = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) Controller = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) Controller = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) Controller = GameObject.Find("C_MyPage");
    }
}

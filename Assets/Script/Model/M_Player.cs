using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class M_Player : MonoBehaviour {
    int _Gold;
    int _Power;
    int _lastStep;
    private GameObject C_Refrig;

    void Start()
    {
        this._Gold = 0;
        this._Power = 0;
        this._lastStep = 0;
        
        C_Refrig = GameObject.Find("C_Refrig");
    }
    //Controller에서 부를 것이니...
    void setLastStep(int givenStep)
    {
        this._lastStep = givenStep;
    }
    
   

    //골드 계산방법 
    int CalcGold()
    {
        return 0;
    }

    //전력 계산방법 : 현재 전력 + (현재 걸음 수 - 마지막 걸음 수)
    void CalcPower(int currentStep)
    {
        this._Power = this._Power + (currentStep - _lastStep);
        C_Refrig.SendMessage("setPower", this._Power);
    }
}

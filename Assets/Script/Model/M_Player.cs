using UnityEngine;
using System.Collections;

public class M_Player : MonoBehaviour {
    int _Gold;
    int _Power;
    int _lastStep;
    private GameObject C_Refrig;

    void Start()
    {
        _Gold = 0;
        _Power = 0;
        _lastStep = 0;
        
        C_Refrig = GameObject.Find("C_Refrig");
    }
    //Controller에서 부를 것이니...
    void setLastStep(int givenStep)
    {
        _lastStep = givenStep;
    }
    void getPower(int givenStep)
    {
        CalcPower(givenStep);
        if (C_Refrig != null)
        {
            C_Refrig.SendMessage("setPower", _Power);
        }
    }
   

    //골드 계산방법 
    int CalcGold()
    {
        return 0;
    }

    //전력 계산방법 : 현재 전력 + (현재 걸음 수 - 마지막 걸음 수)
    void CalcPower(int currentStep)
    {
        _Power = _Power + (currentStep - _lastStep);
    }
}

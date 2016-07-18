using UnityEngine;
using System.Collections;

public class M_Player : MonoBehaviour {
    int _Gold;
    int _Power;
    int _lastStep;

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
    int CalcPower(int currentStep)
    {
        return this._Power + (currentStep - this._lastStep);
    }
}

using UnityEngine;
using System.Collections;

public class C_Refrig : MonoBehaviour {
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject V_Refrig;
    
    private int _step;
    private int _time;
    private int _power;
    private int _battery;
    

	// Update is called once per frame
	void Update () {

        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");
        V_Refrig = GameObject.Find("V_Refrig");

        this._step = 0;
        this._power = 0;
        this._time = 0;
        this._battery = 0;
	}

    void setStep(int givenStep)
    {
        this._step = givenStep;
    }
    void setPower(int givenPower)
    {

    }
    void setTime(int givenTime)
    {
        this._time = givenTime;
    }
    void setBattery(int givenBattery)
    {
        this._battery = givenBattery;
    }

    void renewalPower()
    {
        /*
         * 1. M_Walker로 부터 step을 전달받는다.
         * 2. M_Player에 step을 주고 Power를 전달받는다.
         * 3, V_Refrig에 Power를 주고 Power를 갱신시킨다.
         */

        //1
        M_Walker.SendMessage("getStep");
        //2
        M_Player.SendMessage("CalcPower",this._step);
        //3
        V_Refrig.SendMessage("showPower",this._power);
        
    }

    void renewalBattery()
    {
        /*
         * 1. M_Walker로 부터 _time을 전달받는다.
         * 2. M_Refrigerator에 _time을 주고 Battery를 전달받는다.
         * 3. V_Refrig에 Battery를 주고 Battery를 갱신시킨다.
         */
        //1
        M_Walker.SendMessage("getTime");
        //2
        M_Refrigerator.SendMessage("CalcBattery", this._time);
        //3
        V_Refrig.SendMessage("showBattery", this._battery);
    }
}

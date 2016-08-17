using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class C_Refrig : MonoBehaviour {
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject V_Refrig;

    int _step;
    int _time;
    int _power;
    int _battery;
    int _touch;
    

	// Update is called once per frame
	void Start () {

        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");
        V_Refrig = GameObject.Find("V_Refrig");


        this._step = 0;
        this._power = 0;
        this._time = 0;
        this._battery = 0;
	}
    void Update()
    {
        
        renewalPower();
        renewalBattery();
    }

    #region setter
    public void setStep(int givenStep)          { this._step = givenStep; }
    public void setPower(int givenPower)        { this._power = givenPower; }
    public void setTime(int givenTime)          { this._time = givenTime;}
    public void setBattery(int givenBattery)    { this._battery = givenBattery; }
    public void setTouch(int givenTouch)        { this._touch = givenTouch; }
    #endregion

    #region getter
    public int getStep()                        { return this._step; }
    public int getPower()                       { return this._power; }
    public int getTime()                        { return this._time; }
    public int getBattery()                     { return this._battery; }
    public int getTouch()                       { return this._touch; }
    #endregion
    void renewalPower()
    {
        /*
         * 1. M_Walker로 부터 step을 전달받는다.
         * 2. M_Player에 step을 주고 Power를 전달받는다.
         * 3, V_Refrig에 Power를 주고 Power를 갱신시킨다.
         */

        //1
        M_Walker.SendMessage("sendStep");
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
        if (M_Walker != null)
        {
            M_Walker.SendMessage("getTime",this);
        }
        else
            print("M_Walker is missing");
        //2
        if (M_Refrigerator != null)
            M_Refrigerator.SendMessage("CalcBattery", this);
        else
            print("M_Refrigerator is missing");
        //3
        if (V_Refrig != null)
            V_Refrig.SendMessage("showBattery", this._battery);
        else
            print("V_Refrig is missing");
    }
    void renewalGold()
    {
        /*
         * 1. M_Walker로 부터 step을 전달받는다.
         * 2. M_Player에 step을 주고 Power를 전달받는다.
         * 3, V_Refrig에 Power를 주고 Power를 갱신시킨다.
         */

        //1
        M_Walker.SendMessage("getStep", this);
        //2
        M_Player.SendMessage("CalcPower", this);
        //3
        V_Refrig.SendMessage("showPower", this._power);

    }
}

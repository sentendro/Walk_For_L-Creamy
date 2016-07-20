using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class C_Refrig : MonoBehaviour {
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject V_Refrig;
    public Text Gold;
    public Text Power;

    public int _step;
    public int _time;
    public int _power;
    public int _battery;
    

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
        
        //renewalPower();
        //renewalGold();
        renewalBattery();
        Power.text = this._battery.ToString();
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
        M_Walker.SendMessage("getStep",this);
        //2
        M_Player.SendMessage("CalcPower",this);
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
            print(this._time);
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
            V_Refrig.SendMessage("showBattery", this);
        else
            print("V_Refrig is missing");
    }
}

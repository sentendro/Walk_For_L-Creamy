using UnityEngine;
using System.Collections;

public class C_Refrig : MonoBehaviour {
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject V_Refrig;
    private int _step;
    private int _power;

	// Update is called once per frame
	void Update () {

        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        V_Refrig = GameObject.Find("V_Refrig");

        _step = 0;
        _power = 0;
	}

    void setStep(int givenStep)
    {
        this._step = givenStep;
    }
    void setPower(int givenPower)
    {

    }

    void renewalPower()
    {
        /*
         * 1. M_Walker로 부터 step을 설정한다.
         * 2. M_Player에 step을 주고 Power를 반환받는다.
         * 3, V_Refrig에 Power를 주고 Power를 갱신시킨다.
         */

        //1
        if(M_Walker != null)
            M_Walker.SendMessage("setStep");
        //2
        if(M_Player != null)
            M_Player.SendMessage("getPower",_step);
        //3
        if(V_Refrig != null)
            V_Refrig.SendMessage("showPower",_power);
        
    }
}

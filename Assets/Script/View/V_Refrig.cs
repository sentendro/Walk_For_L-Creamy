using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class V_Refrig : MonoBehaviour {
    public Text Gold;
    public Text Power;
    public Text Battery;

    void showPower(int givenPower)
    {
        Power.text = givenPower.ToString();
    }
    void showGold(int givenGold)
    {

    }
    void showBattery(int givenBattery)
    {
        Gold.text = givenBattery.ToString();
        Battery.text = givenBattery.ToString();
    }
}

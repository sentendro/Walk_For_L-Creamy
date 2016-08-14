using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class V_Refrig : MonoBehaviour {
    public Text Gold;
    public Text Power;
    public Text Battery;

    private GameObject SpecialPanel;

    void Awake()
    {
        SpecialPanel = GameObject.Find("POPUP");
    }
    public void turnOnPop(string givenName)
    {
        switch(givenName)
        {
            case "Setting":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Inventory":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }
    public void turnOffPop(string givenName)
    {
        switch (givenName)
        {
            case "exitSetting":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "exitInventory":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(false);
                break;

        }
    }

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

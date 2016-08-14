using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class V_Refrig : MonoBehaviour {
    public Text Gold;
    public Text Power;
    public Text Battery;

    private GameObject SpecialPanel;

    void Awake()
    {
        SpecialPanel = GameObject.Find("POPUP_SCREEN");
    }

    void SelectedName(string givenName)
    {
        switch(givenName)
        {
            case "Setting":
            case "Inventory":
            case "LCreamyInfo":
            case "BatteryInfo":
                turnOnPop(givenName);
                break;
            case "exitSetting":
            case "exitInventory":
            case "exitLCreamyInfo":
            case "exitBatteryInfo":
                turnOffPop(givenName);
                break;
        }
    }
    public void turnOnPop(string givenName)
    {
        switch(givenName)
        {
            case "Setting":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(true);
                turnOnBackGround();
                break;
            case "Inventory":
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(true);
                turnOnBackGround();
                break;
            case "LCreamyInfo":
                SpecialPanel.transform.GetChild(3).gameObject.SetActive(true);
                turnOnBackGround();
                break;
            case "BatteryInfo":
                SpecialPanel.transform.GetChild(4).gameObject.SetActive(true);
                turnOnBackGround();
                break;
        }
    }

    private void turnOnBackGround()
    {
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void turnOffPop(string givenName)
    {
        switch (givenName)
        {
            case "exitSetting":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(false);
                turnOffBackGround();
                break;
            case "exitInventory":
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(false);
                turnOffBackGround();
                break;
            case "exitLCreamyInfo":
                SpecialPanel.transform.GetChild(3).gameObject.SetActive(false);
                turnOffBackGround();
                break;
            case "exitBatteryInfo":
                SpecialPanel.transform.GetChild(4).gameObject.SetActive(false);
                turnOffBackGround();
                break;

        }
    }

    private void turnOffBackGround()
    {
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
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

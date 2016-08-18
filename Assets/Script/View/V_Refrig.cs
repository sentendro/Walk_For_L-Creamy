using UnityEngine;
using UnityEngine.UI;


public class V_Refrig : MonoBehaviour {
    public Text Gold;
    public Text Power;
    public Text Battery;
    public Text Temparature;

    private GameObject SpecialPanel;
    private GameObject C_Serializer;
    private GameObject C_Refrig;
    private GameObject battery;
    private GameObject tempergraphy;

    void Awake()
    {
        SpecialPanel = GameObject.Find("POPUP_SCREEN");
        C_Serializer = GameObject.Find("C_Serializer");
        battery = GameObject.Find("batteryImage");
        tempergraphy = GameObject.Find("tempergraphyImage");
    }

    void SelectedObject(GameObject givenObject)
    {
        if(givenObject.tag == "PopUp")
        {
            turnOnPop(givenObject.name);
        }
        else if(givenObject.tag == "Exit")
        {
            if (givenObject.name == "Setting")
            {
                C_Serializer.SendMessage("SaveSetting");
            }
            turnOffPop(givenObject.name);
        }
        else if(givenObject.tag == "Item")
        {
            useItem(givenObject);
        }
    }

    private void useItem(GameObject givenObject)
    {
        givenObject.SendMessage("useItem");
    }

    public void turnOnPop(string givenName)
    {
        switch(givenName)
        {
            case "Setting":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "Inventory":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Prize":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
                SpecialPanel.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "Dictionary":
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
                SpecialPanel.transform.GetChild(4).gameObject.SetActive(true);
                break;
        }
    }
    

    public void turnOffPop(string givenName)
    {
        switch (givenName)
        {
            case "exitSetting":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(false);
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "exitInventory":
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(false);
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "exitPrize":
                SpecialPanel.transform.GetChild(3).gameObject.SetActive(false);
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "exitDictionary":
                SpecialPanel.transform.GetChild(4).gameObject.SetActive(false);
                SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
                break;

        }
    }

    void showPower(int givenPower)
    {
        Power.text = givenPower.ToString();
    }
    void showGold(int givenGold)
    {
        Gold.text = givenGold.ToString();
    }
    void showBattery(int givenBattery)
    {
        battery.transform.GetChild(1).GetComponent<Transform>().localScale = new Vector3(1.0f,givenBattery/100.0f,1.0f);
        Battery.text = givenBattery.ToString() + "%";
    }
    void showTemperature(double givenTemperature)
    {
        tempergraphy.transform.GetChild(2).GetComponent<Transform>().localScale = new Vector3(1.0f,((float)givenTemperature + 18)/48.0f,1.0f);
        double TemperatureForShow = System.Math.Round(givenTemperature,2);
        Temparature.text = TemperatureForShow.ToString("N1") +"℃";
    }
}
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class V_Shop : MonoBehaviour
{
    public Text Gold;
    public Text Power;

    private GameObject SpecialPanel;
    GameObject C_Shop;
    
    void Awake()
    {
        SpecialPanel = GameObject.Find("POPUP_SCREEN");
        C_Shop = GameObject.Find("C_Shop");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SelectedObject(GameObject givenObject)
    {
        if (givenObject.tag == "Item")          //Item 오브젝트
        {
            turnOnPop(givenObject);
        }
        else if (givenObject.tag == "Exit")     //Text 오브젝트
        {
            turnOffPop(givenObject);
        }
        else if (givenObject.tag == "Use")      //Text 오브젝트
        {
            BuyItem(givenObject);
        }
    }

    private void turnOnPop(GameObject givenObject)
    {
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
        switch (givenObject.name)
        {
            case "item1":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "item2":
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }
    private void turnOffPop(GameObject givenObject)
    {
        //Text 오브젝트 이니까 부모에 접근해서 팝업창 GameObject에 접근
        GameObject PopUp = givenObject.transform.parent.gameObject;
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
        switch (PopUp.name)
        {
            case "item1":
                SpecialPanel.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case "item2":
                SpecialPanel.transform.GetChild(2).gameObject.SetActive(false);
                break;
        }
    }

    void BuyItem(GameObject givenObject)
    {

        //Text 오브젝트 이니까 부모의 이름을 얻어내서 실제 Item GameObject를 Find로 찾아낸다.
        GameObject Item = GameObject.Find(givenObject.transform.parent.name);
        C_Shop.SendMessage("Buy", Item);
        Item.SendMessage("useItem");
    }
    void showPower(int givenPower)
    {
        Power.text = givenPower.ToString();
    }
    void showGold(int givenGold)
    {
        Gold.text = givenGold.ToString();
    }
}

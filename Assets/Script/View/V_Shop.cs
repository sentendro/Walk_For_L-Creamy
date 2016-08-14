using UnityEngine;
using System.Collections;
using System;

public class V_Shop : MonoBehaviour {

    private GameObject SpecialPanel;
    
    void Awake()
    {
        SpecialPanel = GameObject.Find("POPUP_SCREEN");
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
            ItemUse(givenObject);
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

    void ItemUse(GameObject givenObject)
    {
        //Text 오브젝트 이니까 부모의 이름을 얻어내서 실제 Item GameObject를 Find로 찾아낸다.
        GameObject Item = GameObject.Find(givenObject.transform.parent.name);
        Debug.Log(Item.name);
        Item.SendMessage("useItem");
    }


}

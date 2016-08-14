using UnityEngine;
using System.Collections;
using System;

public class V_Shop : MonoBehaviour {

    private GameObject SpecialPanel;
    private GameObject SelectedItem;
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
        if (givenObject.tag == "Item")
        {
            turnOnPop(givenObject.name);
        }
        else if (givenObject.tag == "Exit")
        {
            turnOffPop(givenObject.name);
        }
        else if (givenObject.tag == "Use")
        {
            ItemUse(givenObject);
        }
    }

    private void ItemUse(GameObject givenObject)
    {
        throw new NotImplementedException();
    }

    private void turnOffPop(string givenName)
    {
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(false);
        SpecialPanel.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void turnOnPop(string givenName)
    {
        SpecialPanel.transform.GetChild(0).gameObject.SetActive(true);
        SpecialPanel.transform.GetChild(1).gameObject.SetActive(true);
    }
    

}

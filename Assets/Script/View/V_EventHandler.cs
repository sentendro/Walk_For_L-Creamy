using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class V_EventHandler : MonoBehaviour {
    private GameObject SceneController;

    void Awake()
    {
        SceneController = GameObject.Find("C_SceneController");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("hi");
            if (EventSystem.current.currentSelectedGameObject != null) { 
                print("hi2");
                string SelectedButton = EventSystem.current.currentSelectedGameObject.name;
                SceneController.SendMessage("SceneMove", SelectedButton);
            }
            
        }
    }
}

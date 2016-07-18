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
            if(EventSystem.current.currentSelectedGameObject != null) {
                string SelectedButton = EventSystem.current.currentSelectedGameObject.name;
                print("hi");
                SceneController.SendMessage("SceneMove", SelectedButton);
            }
        }
    }
}

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
            print(EventSystem.current.currentSelectedGameObject.name);
            if(EventSystem.current.currentSelectedGameObject != null) {
                string SelectedButton = EventSystem.current.currentSelectedGameObject.name;
                SceneController.SendMessage("SceneMove", SelectedButton);
            }
        }
    }
}

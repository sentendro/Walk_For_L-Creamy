using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class V_EventHandler : MonoBehaviour {
    public GameObject SceneController;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string SelectedButton = EventSystem.current.currentSelectedGameObject.name;

            //빈곳을 클릭한게 아닐 때
            if(!SelectedButton.Equals(null))
                SceneController.SendMessage("SceneMove", SelectedButton);
        }
    }
}

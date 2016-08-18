using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class V_EventHandler : MonoBehaviour {
    GameObject C_SceneController;
    public GameObject Controller;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    void Awake()
    {
        C_SceneController = GameObject.Find("C_SceneController");
    }
    void Update()
    {
        this.ControllerCheck();
        Click();
        Slide();
    }
    void ControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) Controller = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) Controller = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) Controller = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) Controller = GameObject.Find("C_MyPage");
    }
    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                GameObject SelectedObject = EventSystem.current.currentSelectedGameObject;
                Debug.Log(SelectedObject.name);
                if (SelectedObject.tag == "Button")
                {
                    C_SceneController.SendMessage("SceneMove", SelectedObject.name);
                }
                else if (SelectedObject.scene.name == "01_Refrig")
                {
                    GameObject View = GameObject.Find("V_Refrig");
                    View.SendMessage("SelectedObject", SelectedObject);
                }
                else if (SelectedObject.scene.name == "02_Shop")
                {
                    GameObject View = GameObject.Find("V_Shop");
                    View.SendMessage("SelectedObject", SelectedObject);
                }
            }
            else
            {
                if (Controller.name == "C_Refrig")
                    Controller.SendMessage("Clicker");
            }
        }
    }

    private void Slide()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
            }
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
            }
        }
    }

    
}

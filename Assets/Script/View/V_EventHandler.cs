using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class V_EventHandler : MonoBehaviour {
    private GameObject SceneController;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
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
    public void Swipe()
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
            {
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
    }
}

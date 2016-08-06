using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class V_Pop : MonoBehaviour {

    private GameObject SpecialPanel;
    private GameObject settingButton;

    void Awake()
    {
        SpecialPanel = GameObject.Find("settingScreen");
    }
    // Use this for initialization
    void Start()
    {
        SpecialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                Debug.Log("S3");
                if (EventSystem.current.currentSelectedGameObject.name.Equals("Setting"))
                {
                    Debug.Log("S5");
                    SpecialPanel.SetActive(true);
                }
                if (EventSystem.current.currentSelectedGameObject.name.Equals("exit"))
                {
                    SpecialPanel.SetActive(false);
                }
            }
            
        }

    }

}

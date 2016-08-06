using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class pop : MonoBehaviour {

    private GameObject SpecialPanel;
    private GameObject settingButton;

    void Awake()
    {
        settingButton = GameObject.Find("Setting");
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
            if (settingButton.Equals(EventSystem.current.currentSelectedGameObject))
            {
                SpecialPanel.SetActive(true);
            }
        }

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class C_SceneController : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void SceneMove(string name)
    {
        switch (name)
        {
            //Logo Scene
            case "Start":   //냉장고 씬으로 넘어 간다.
                SceneManager.LoadScene("01_Refrig");
                break;
            case "End":     //앱을 종료 시킨다.
                Application.Quit();               
                break;

            //Refrig Scene
            case "MyPage":
                SceneManager.LoadScene("02_Mypage");
                break;
            case "Shop":
                SceneManager.LoadScene("02_Shop");
                break;
            case "Setting":
                SceneManager.LoadScene("02_Setting");
                break;

            //MyPage Scene
            case "MyPage_Back":
                SceneManager.LoadScene("01_Refrig");
                break;
            //Shop Scene
            case "Shop_Back":
                SceneManager.LoadScene("01_Refrig");
                break;
            //Setting Scene
            case "Setting_Back":
                SceneManager.LoadScene("01_Refrig");
                break;






            //default
            default:
                print("");
                break;

        }
            

    }

}

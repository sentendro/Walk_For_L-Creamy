using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class C_SceneController : MonoBehaviour {

    void SceneMove(string name)
    {
        switch (name)
        {

            #region Logo
            case "Start":   //냉장고 씬으로 넘어 간다.
                SceneManager.LoadScene("01_Refrig");
                break;
            case "End":     //앱을 종료 시킨다.
                Application.Quit();               
                break;
            #endregion

            #region Refrigerator
            case "MyPage":
                SceneManager.LoadScene("02_Mypage");
                break;
            case "Shop":
                SceneManager.LoadScene("02_Shop");
                break;
            case "Setting":
                SceneManager.LoadScene("02_Setting");
                break;
            #endregion

            #region MyPage
            case "MyPage_Back":
                SceneManager.LoadScene("01_Refrig");
                break;
            #endregion

            #region Shop
            case "Shop_Back":
                SceneManager.LoadScene("01_Refrig");
                break;
            #endregion

            #region Setting
            case "Setting_Back":
                SceneManager.LoadScene("01_Refrig");
                break;
            #endregion
            //default
            default:
                print("");
                break;

        }
            

    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class C_Refrig : MonoBehaviour
{
    private GameObject M_Walker;
    void Awake()
    {
        M_Walker = GameObject.Find("M_Walker");
    }
    void Clicker()
    {
        M_Walker.SendMessage("Clicker");
    }
}

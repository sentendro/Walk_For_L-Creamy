using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class M_Walker : MonoBehaviour
{
    private int _step;
    private GameObject C_Refrig;
    
    void Start()
    {
        this._step = 0;
        
        C_Refrig = GameObject.Find("C_Refrig");
    }
    void getStep()
    {
        if(C_Refrig != null)
            C_Refrig.SendMessage("setStep", this._step);

            
    }
}

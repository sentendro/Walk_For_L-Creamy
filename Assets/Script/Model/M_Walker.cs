using UnityEngine;
using System.Collections;

public class M_Walker : MonoBehaviour
{
    private int _step;
    private GameObject C_Refrig;
    
    void Start()
    {
        _step = 0;
        
        C_Refrig = GameObject.Find("C_Refrig");
    }
    void getStep()
    {
        if(C_Refrig != null)
            C_Refrig.SendMessage("setStep", _step);

            
    }
}

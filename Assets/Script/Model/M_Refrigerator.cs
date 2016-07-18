using UnityEngine;
using System.Collections;

public class M_Refrigerator: MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

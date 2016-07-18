using UnityEngine;
using System.Collections;

public class M_Setting : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

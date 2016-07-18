using UnityEngine;
using System.Collections;

public class M_Walker : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

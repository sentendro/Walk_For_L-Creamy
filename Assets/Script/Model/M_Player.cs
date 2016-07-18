using UnityEngine;
using System.Collections;

public class M_Player : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}

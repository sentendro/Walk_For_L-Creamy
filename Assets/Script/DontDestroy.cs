using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DontDestroy : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

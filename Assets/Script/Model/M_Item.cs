using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class M_Item : MonoBehaviour {
    public Text Count;
    public int _count;
	// Use this for initialization
	void Start () {
        this._count = 5;
        Count.text = this._count.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void useItem()
    {
        this._count--;
        Count.text = this._count.ToString();
    }
}

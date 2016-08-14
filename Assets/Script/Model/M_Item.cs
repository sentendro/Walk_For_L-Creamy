using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class M_Item : MonoBehaviour {
    public Text Count;
    public int _count;
    private int _price;
	// Use this for initialization
	void Start () {
        this._count = 5;
        this._price = 1000;
        Count.text = this._count.ToString();

    }

    // Update is called once per frame
    void Update () {
	
	}
    void getPrice(C_Shop script)
    {
        script._price = this._price;
        this._count++;
    }

    void useItem()
    {
        Debug.Log("hi");
        this._count--;
        Count.text = this._count.ToString();
    }
}

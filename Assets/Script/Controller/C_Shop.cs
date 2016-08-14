using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class C_Shop : MonoBehaviour {
    public Text Gold;
    public int _Gold;
    public int _price;

	// Use this for initialization
	void Start () {
        this._Gold = 5000;
        this.Gold.text = this._Gold.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void Buy(GameObject Item)
    {
        Item.SendMessage("getPrice", this);
        this._Gold = this._Gold - this._price;
        this._price = 0; //초기화
        this.Gold.text = this._Gold.ToString();
    }
}

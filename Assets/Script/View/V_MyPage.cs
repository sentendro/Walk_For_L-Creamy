using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class V_MyPage : MonoBehaviour
{
    public Text Gold;
    public Text Power;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }
    void showPower(int givenPower)
    {
        Power.text = givenPower.ToString();
    }
    void showGold(int givenGold)
    {
        Gold.text = givenGold.ToString();
    }
}

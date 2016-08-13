using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public int count;
    public Texture[] ani;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTexture = this.ani[count];
        count++;
        if (count >= ani.Length)
            count = 0;
    }
}

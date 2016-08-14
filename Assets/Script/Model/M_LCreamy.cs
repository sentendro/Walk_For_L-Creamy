using UnityEngine;
using System.Collections;
using System;

public class M_LCreamy : MonoBehaviour {
    private float _time;
    public int _aniCount;
    public Level L;

    public Texture[] _level0;
    public Texture[] _level1;
    public Texture[] _level2;

    public enum Level
    {
        level0,
        level1,
        level2,
    }
    // Use this for initialization
    void Start () {
        this._time = 0;
        this._aniCount = 0;
        this.L = Level.level0;
	}
	
	// Update is called once per frame
	void Update () {
        Anime();
        Grow();
	}

    private void Anime()
    {
        if (L == Level.level0)
            Ani_level0();
        else if (L == Level.level1)
            Ani_level1();
        else if (L == Level.level2)
            Ani_level2();
    }

    private void Ani_level2()
    {
        GetComponent<Renderer>().material.mainTexture = this._level2[this._aniCount];
        this._aniCount++;
        if (this._aniCount >= this._level0.Length)
            this._aniCount = 0;
    }

    private void Ani_level1()
    {
        GetComponent<Renderer>().material.mainTexture = this._level1[this._aniCount];
        this._aniCount++;
        if (this._aniCount >= this._level0.Length)
            this._aniCount = 0;
    }

    private void Ani_level0()
    {
        GetComponent<Renderer>().material.mainTexture = this._level0[this._aniCount];
        this._aniCount++;
        if (this._aniCount >= this._level0.Length)
            this._aniCount = 0;

    }

    private void Grow()
    {
        this._time += Time.deltaTime;
        if (this._time > 2 && this._time<5)
            this.L = Level.level1;
        else if (this._time > 5)
            this.L = Level.level2;
    }
}

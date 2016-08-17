using UnityEngine;
using System.Collections;
using System;

public class M_Walker : MonoBehaviour
{
    private float _step;
    private float _time;
    private int _touch;
    private float _loLim = 0.005F;
    private float _hiLim = 0.3F;
    private bool stateH = false;
    private float _fHigh = 8.0F;
    private float _curAcc = 0F;
    private float _fLow = 0.2F;
    private float _avgAcc;
    float deltaTime;

    private GameObject Controller;
    private GameObject C_Serializer;
    #region setter
    public void setStep(float step) { this._step = step; }
    public void setTouch(int touch) { this._touch = touch; }
    public void setTime(float time) { this._time = time; }
    #endregion

    #region getter
    public float getStep() { return this._step; }
    public int getTouch() { return this._touch; }
    public float getTime() { return this._time; }
    #endregion
    public void setUp(M_Walker prevWalker)
    {
        this._step = prevWalker.getStep();
        this._touch = prevWalker.getTouch();
        this._time = prevWalker.getTime();
    }
    void Awake()
    {
        C_Serializer = GameObject.Find("C_Serializer");
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("WALKERINFO_SAVE_KEY"))
        {
            C_Serializer.SendMessage("LoadWalker");
        }
        else
        {
            this._step = 0;
            this._time = 0;
            this.deltaTime = 0;
            this._touch = 0;
        }
    }

    void Update()
    {
        ControllerCheck();
        stepDetector();
        deltaTime += Time.deltaTime;
        this._time = (int)deltaTime;
    }
    void sendStep()
    {
        Controller.SendMessage("setStep",((int) this._step));
    }
    void sendTouch()
    {
        Controller.SendMessage("setTouch", ((int)this._touch));
    }

    void getTime(C_Refrig script)
    {
        script.setTime((int) this._time);
    }

    public void stepDetector()
    {
        _curAcc = Mathf.Lerp(_curAcc, Input.acceleration.magnitude, Time.deltaTime * _fHigh);
        _avgAcc = Mathf.Lerp(_avgAcc, Input.acceleration.magnitude, Time.deltaTime * _fLow);
        float delta = _curAcc - _avgAcc;
        if (!stateH)
        {
            if (delta > _hiLim)
            {
                stateH = true;
                this._step++;
            }
        }
        else {
            if (delta < _loLim)
            {
                stateH = false;
            }
        }
        _avgAcc = _curAcc;
    }
    void ControllerCheck()
    {
        if (GameObject.Find("C_Logo") != null) Controller = GameObject.Find("C_Logo");
        if (GameObject.Find("C_Refrig") != null) Controller = GameObject.Find("C_Refrig");
        if (GameObject.Find("C_Shop") != null) Controller = GameObject.Find("C_Shop");
        if (GameObject.Find("C_MyPage") != null) Controller = GameObject.Find("C_MyPage");
    }
}

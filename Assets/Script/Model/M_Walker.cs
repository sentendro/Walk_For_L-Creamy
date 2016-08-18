using UnityEngine;
using System.Collections;
using System;

public class M_Walker : MonoBehaviour
{
    private float _loLim = 0.005F;
    private float _hiLim = 0.3F;
    private bool stateH = false;
    private float _fHigh = 8.0F;
    private float _curAcc = 0F;
    private float _fLow = 0.2F;
    private float _avgAcc;

    private GameObject Controller;
    private GameObject C_Serializer;
    public Walker CurrentWalker;

    void Awake()
    {
        C_Serializer = GameObject.Find("C_Serializer");
        CurrentWalker = new Walker();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("WALKERINFO_SAVE_KEY"))
        {
            C_Serializer.SendMessage("LoadWalker");
        }
        else
        {
            CurrentWalker.setStep(0);
            CurrentWalker.setCurrentTime(DateTime.Now);
            CurrentWalker.setTouch(0);
        }
    }

    void Update()
    {
        ControllerCheck();
        stepDetector();
        CurrentWalker.setCurrentTime(DateTime.Now);
        CurrentWalker.sec = CurrentWalker.getCurrentTime().Second;
    }

    void Clicker()
    {
        CurrentWalker.setTouch(CurrentWalker.getTouch() + 1);
    }

    #region sender
    void sendStep()
    {
        Controller.SendMessage("setStep",CurrentWalker.getStep());
    }
    void sendTouch()
    {
        Controller.SendMessage("setTouch", CurrentWalker.getTouch());
    }

    void sendCurrentTime()
    {
        Controller.SendMessage("setCurrentTime",CurrentWalker.getCurrentTime());
    }
    #endregion

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
                CurrentWalker.stepUp();
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
    public void setUp(Walker prevWalker)
    {
        CurrentWalker.setStep(prevWalker.getStep());
        CurrentWalker.setTouch(prevWalker.getTouch());
    }
}

[Serializable]
public class Walker
{
    private int _step;
    private int _touch;
    public DateTime _CurrentTime;
    public int sec;

    #region setter
    public void setStep(int step)                     { this._step = step; }
    public void setTouch(int touch)                     { this._touch = touch; }
    public void setCurrentTime(DateTime CurrentTime)    { this._CurrentTime = CurrentTime; }
    #endregion

    #region getter
    public int getStep()                              { return this._step; }
    public int getTouch()                               { return this._touch; }
    public DateTime getCurrentTime()                    { return this._CurrentTime; }
    #endregion

    public void stepUp()
    {
        this._step++;
    }
}
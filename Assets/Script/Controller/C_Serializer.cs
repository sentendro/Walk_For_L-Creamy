using UnityEngine;
using System.Collections;

public class C_Serializer : MonoBehaviour {
    private readonly string PLAYERKEY = "PLAYERINFO_SAVE_KEY";
    private readonly string SETTINGKEY = "SETTINGINFO_SAVE_KEY";
    private readonly string WALKERKEY = "WALKERINFO_SAVE_KEY";
    private readonly string REFRIGKEY = "REFRIGINFO_SAVE_KEY";

    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject M_Setting;

    private int _SaveTime = 10;

    // Use this for initialization
    void Start () {
        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");
        M_Setting = GameObject.Find("M_Setting");
    }

    // Update is called once per frame
    void Update() {
        if (_SaveTime == 0) {
            _SaveTime = 3;
        }
        else
            _SaveTime = _SaveTime-1;
	}
    public void SavePlayer(Player player)
    {
        string PlayerData = SaveLoad.ObjectToString(player);
        PlayerPrefs.SetString(PLAYERKEY, PlayerData);
    }
    public void SaveSetting()
    {
        string SettingData = SaveLoad.ObjectToString(M_Setting.GetComponent<M_Setting>());
        PlayerPrefs.SetString(SETTINGKEY, SettingData);
    }
    public void SaveWalker(Walker walker)
    {
        string WalkerData = SaveLoad.ObjectToString(walker);
        PlayerPrefs.SetString(WALKERKEY, WalkerData);
    }
    public void SaveRefrig(Refrigerator refrig)
    {
        string RefrigData = SaveLoad.ObjectToString(refrig);
        PlayerPrefs.SetString(REFRIGKEY, RefrigData);
    }
    public void LoadPlayer()
    {
        string LoadData = PlayerPrefs.GetString(PLAYERKEY, string.Empty);
        M_Player.SendMessage("setUp",(SaveLoad.Deserialize<M_Player>(LoadData)));
    }
    public void LoadSetting()
    {
        string LoadData = PlayerPrefs.GetString(SETTINGKEY, string.Empty);
        M_Setting.SendMessage("setUp", (SaveLoad.Deserialize<M_Setting>(LoadData)));
    }
    public void LoadWalker()
    {
        string LoadData = PlayerPrefs.GetString(WALKERKEY, string.Empty);
        M_Walker.SendMessage("setUp", (SaveLoad.Deserialize<M_Walker>(LoadData)));
    }
    public void LoadRefrig()
    {
        string LoadData = PlayerPrefs.GetString(REFRIGKEY, string.Empty);
        M_Refrigerator.SendMessage("setUp", (SaveLoad.Deserialize<M_Refrigerator>(LoadData)));
    }
}

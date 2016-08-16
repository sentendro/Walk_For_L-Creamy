using UnityEngine;
using System.Collections;

public class C_Serializer : MonoBehaviour {
    private readonly string PLAYERKEY = "PLAYERINFO_SAVE_KEY";
    private readonly string SETTINGKEY = "SETTINGINFO_SAVE_KEY";
    private readonly string WALKERKEY = "WALKERINFO_SAVE_KEY";
    private GameObject M_Walker;
    private GameObject M_Player;
    private GameObject M_Refrigerator;
    private GameObject M_Setting;
    // Use this for initialization
    void Start () {
        M_Walker = GameObject.Find("M_Walker");
        M_Player = GameObject.Find("M_Player");
        M_Refrigerator = GameObject.Find("M_Refrigerator");
        M_Setting = GameObject.Find("M_Setting");
    }
	
	// Update is called once per frame
	void Update () {
        SavePlayer(M_Player.GetComponent<M_Player>());
	}
    public void SavePlayer(M_Player player)
    {
        string PlayerData = SaveLoad.ObjectToString(player);
        PlayerPrefs.SetString(PLAYERKEY, PlayerData);
    }
    public void SaveSetting(M_Setting setting)
    {
        string SettingData = SaveLoad.ObjectToString(setting);
        PlayerPrefs.SetString(SETTINGKEY, SettingData);
    }
    public void SaveWalker(M_Walker walker)
    {
        string WalkerData = SaveLoad.ObjectToString(walker);
        PlayerPrefs.SetString(WALKERKEY, WalkerData);
    }
    public M_Player LoadPlayer()
    {
        string LoadData = PlayerPrefs.GetString(PLAYERKEY, string.Empty);
        return SaveLoad.Deserialize<M_Player>(LoadData);
    }
    public M_Setting LoadSetting()
    {
        string LoadData = PlayerPrefs.GetString(SETTINGKEY, string.Empty);
        return SaveLoad.Deserialize<M_Setting>(LoadData);
    }
    public M_Walker LoadWalker()
    {
        string LoadData = PlayerPrefs.GetString(WALKERKEY, string.Empty);
        return SaveLoad.Deserialize<M_Walker>(LoadData);
    }
}

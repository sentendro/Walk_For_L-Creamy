using UnityEngine;
using System.Collections;

public class C_Serializer : MonoBehaviour {
    private readonly string PLAYERKEY = "PLAYERINFO_SAVE_KEY";
    private readonly string SETTINGKEY = "SETTINGINFO_SAVE_KEY";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}

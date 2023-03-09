using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;

    [SerializeField] public Player Player;
    [SerializeField] public Player Opponent;
    [SerializeField] public Horseman Horseman;
    [SerializeField] public List<Player> PlayerDatabase;

    [Header("Panel Info Variable")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _silver;
    [SerializeField] private TextMeshProUGUI _crystals;
    [SerializeField] private TextMeshProUGUI _gold;
    [SerializeField] private TextMeshProUGUI _globalTime;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        PlayerDatabase = new List<Player>(50);

        for (int i = 0; i < 51; i++)
        {
            PlayerDatabase.Add(ScriptableObject.CreateInstance<Player>());
            PlayerDatabase[i].RandomInit();
            PlayerDatabase[i].SetName(PlayerDatabase[i].Name + $"{i}");

            Debug.Log(PlayerDatabase[i].Name);
        } 
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;

        if (LoadPlayerCharacteristicsData()[0] != 0)
        {
            Debug.Log(LoadPlayerCharacteristicsData()[0]);
            Player = ScriptableObject.CreateInstance<Player>();
            Player.InitFromDatabase(LoadPlayerCharacteristicsData());
            LoadPlayerNameData(Player);
        }
        else
        {
            Player = ScriptableObject.CreateInstance<Player>();
            Player.Init();
        }
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;

        SavePlayerData(Player);
    }

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        RetargetTime();
        RetargetInfoPanel();
        
    }

    private void Start()
    {
        _globalTime = GameObject.Find("Time-text").GetComponent<TextMeshProUGUI>();

        _name = GameObject.Find("Scythian-text").GetComponent<TextMeshProUGUI>();
        _level = GameObject.Find("CheckMark-text").GetComponent<TextMeshProUGUI>();
        _health = GameObject.Find("Health-text").GetComponent<TextMeshProUGUI>();
        _silver = GameObject.Find("Silver-text").GetComponent<TextMeshProUGUI>();
        //_crystals = GameObject.Find("Diamond-text").GetComponent<TextMeshProUGUI>();
        //_gold = GameObject.Find("Gold-text").GetComponent<TextMeshProUGUI>();

        _name.SetText(Player.Name);
        _level.SetText(Player.Level.ToString());
        _health.SetText(Player.CurrentHealth.ToString());
        _silver.SetText(Player.CurrencyBag.Silver.Amount.ToString());
        //_crystals.SetText(_player.CurrencyBag.Crystals.Amount.ToString());
        //_gold.SetText(_player.CurrencyBag.Gold.Amount.ToString());

        Player.StartMyCoroutine();
    }


    private void Update()
    {
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        _globalTime.SetText(currentTime);

        _silver.SetText(Player.CurrencyBag.Silver.Amount.ToString());
    }

    private void RetargetTime()
    {
        _globalTime = GameObject.Find("Time-text").GetComponent<TextMeshProUGUI>();
    }

    private void RetargetInfoPanel()
    {
        _name = GameObject.Find("Scythian-text").GetComponent<TextMeshProUGUI>();
        _level = GameObject.Find("CheckMark-text").GetComponent<TextMeshProUGUI>();
        _health = GameObject.Find("Health-text").GetComponent<TextMeshProUGUI>();
        _silver = GameObject.Find("Silver-text").GetComponent<TextMeshProUGUI>();
        //_crystals = GameObject.Find("Diamond-text").GetComponent<TextMeshProUGUI>();
        //_health = GameObject.Find("Gold-text").GetComponent<TextMeshProUGUI>();

        _name.SetText(Player.Name);
        _level.SetText(Player.Level.ToString());
        _health.SetText(Player.CurrentHealth.ToString());
        _silver.SetText(Player.CurrencyBag.Silver.Amount.ToString());
        //_crystals.SetText(_player.CurrencyBag.Crystals.Amount.ToString());
        //_gold.SetText(_player.CurrencyBag.Gold.Amount.ToString());
    }

    public void RetargetInfoPanelManually()
    {
        RetargetTime();
        RetargetInfoPanel();
    }

    private void SavePlayerData(Player player)
    {
        PlayerPrefs.SetString("Name", player.Name);

        PlayerPrefs.SetInt("Level", player.Level);
        PlayerPrefs.SetInt("Experience", player.Experience);

        PlayerPrefs.SetInt("PowerLevel", player.PowerLevel);
        PlayerPrefs.SetInt("PowerUpgradeCost", player.PowerUpgradeCost);

        PlayerPrefs.SetInt("ProtectionLevel", player.ProtectionLevel);
        PlayerPrefs.SetInt("ProtectionUpgradeCost", player.ProtectionUpgradeCost);

        PlayerPrefs.SetInt("AgilityLevel", player.AgilityLevel);
        PlayerPrefs.SetInt("AgilityUpgradeCost", player.AgilityUpgradeCost);

        PlayerPrefs.SetInt("MasteryLevel", player.MasteryLevel);
        PlayerPrefs.SetInt("MasteryUpgradeCost", player.MasteryUpgradeCost);

        PlayerPrefs.SetInt("VitalityLevel", player.VitalityLevel);
        PlayerPrefs.SetInt("VitalityUpgradeCost", player.VitalityUpgradeCost);

        PlayerPrefs.SetInt("MaxHealth", player.MaxHealth);
        PlayerPrefs.SetInt("CurrentHealth", player.CurrentHealth);
        

        //string json = JsonUtility.ToJson(player);
        //PlayerPrefs.SetString("Player", json);

    }

    private int[] LoadPlayerCharacteristicsData()
    {
        
        int[] playerStats = new int[14] ;

        playerStats[0] = PlayerPrefs.GetInt("Level");
        playerStats[1] = PlayerPrefs.GetInt("Experience");

        playerStats[2] = PlayerPrefs.GetInt("PowerLevel");
        playerStats[3] = PlayerPrefs.GetInt("PowerUpgradeCost");

        playerStats[4] = PlayerPrefs.GetInt("ProtectionLevel");
        playerStats[5] = PlayerPrefs.GetInt("ProtectionUpgradeCost");

        playerStats[6] = PlayerPrefs.GetInt("AgilityLevel");
        playerStats[7] = PlayerPrefs.GetInt("AgilityUpgradeCost");

        playerStats[8] = PlayerPrefs.GetInt("MasteryLevel");
        playerStats[9] = PlayerPrefs.GetInt("MasteryUpgradeCost");

        playerStats[10] = PlayerPrefs.GetInt("VitalityLevel");
        playerStats[11] = PlayerPrefs.GetInt("VitalityUpgradeCost");

        playerStats[12] = PlayerPrefs.GetInt("MaxHealth");
        playerStats[13] = PlayerPrefs.GetInt("CurrentHealth");
        

        //string json = PlayerPrefs.GetString("Player");
        //Debug.Log(json);
        //Player player = ScriptableObject.CreateInstance<Player>();
        //player = JsonUtility.FromJson<Player>(json);
        //
        //return player;

        return playerStats;
    }

    private void LoadPlayerNameData(Player player)
    {
        player.SetName(PlayerPrefs.GetString("Name"));
    }
}

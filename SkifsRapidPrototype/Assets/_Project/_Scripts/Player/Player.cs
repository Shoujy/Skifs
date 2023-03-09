using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Player", menuName = "Units/CreateNewPlayer", order = 1)]
public class Player : ScriptableObject
{
    private const int _consNumberForFormula = 4;

    private const double _raisedNumForPower = 2.6;
    private const double _raisedNumForProtection = 2.35;
    private const double _raisedNumForAgility = 2.3;
    private const double _raisedNumForMastery = 2.5;
    private const double _raisedNumForVitality = 2.45;

    private const double _regenerationRate = 0.017;

    private int _previousExperienceAmount;
    private int _nextExperienceAmount;


    #region Player Properties

    public string Name { get; private set; } = "Skif";
    public int Level { get; private set; } = 3;
    public int Experience { get; private set; } = 0;

    public int PowerLevel { get; private set; } = 6;
    public int PowerUpgradeCost { get; private set; } = 1;
    public int ProtectionLevel { get; private set; } = 6;
    public int ProtectionUpgradeCost { get; private set; } = 1;
    public int AgilityLevel { get; private set; } = 6;
    public int AgilityUpgradeCost { get; private set; } = 1;
    public int MasteryLevel { get; private set; } = 6;
    public int MasteryUpgradeCost { get; private set; } = 1;
    public int VitalityLevel { get; private set; } = 6;
    public int VitalityUpgradeCost { get; private set; } = 1;
    public int MaxHealth { get; private set; } = 105;
    
    public int CurrentHealth { get; private set; } = 105;


    #endregion

    public CurrencyBag CurrencyBag;
    public void Init()
    {
        PowerLevel = 6;
        ProtectionLevel = 6;
        AgilityLevel = 6;
        MasteryLevel = 6;
        VitalityLevel = 6;

        // CurrencyBag = new CurrencyBag();
    }

    public void RandomInit()
    {
        Level = Random.Range(1, 6);

        PowerLevel = Random.Range(6, 18);
        ProtectionLevel = Random.Range(6, 18);
        AgilityLevel = Random.Range(6, 18);
        MasteryLevel = Random.Range(6, 18);
        VitalityLevel = Random.Range(6, 18);

        // CurrencyBag = new CurrencyBag();
    }

    public void InitFromDatabase(int [] playerStats) 
    {
        PowerLevel = playerStats[0];
        Experience = playerStats[1];

        PowerLevel = playerStats[2];
        PowerUpgradeCost = playerStats[3];

        ProtectionLevel = playerStats[4];
        ProtectionUpgradeCost = playerStats[5];

        AgilityLevel = playerStats[6];
        AgilityUpgradeCost = playerStats[7];

        MasteryLevel = playerStats[8];
        MasteryUpgradeCost = playerStats[9];

        VitalityLevel = playerStats[10];
        VitalityUpgradeCost = playerStats[11];

        MaxHealth = playerStats[12];
        CurrentHealth = playerStats[13];

        // CurrencyBag = new CurrencyBag();
    }

    private void OnEnable()
    {
        CurrencyBag = CreateInstance<CurrencyBag>();
        CurrencyBag.Init();
    }

    public void ExperienceReceive(int amount)
    {
        if(amount > 0)
        {
            Experience += amount;
        }
        else
        {
            Debug.Log("Amount of experience can't be negative");
        }
    }

    private void LevelUp()
    {
        Level++;
    }

    public void TakeDamage(int damage)
    {
        if(CurrentHealth - damage >= 0)
        {
            CurrentHealth -= damage;
        } 
        else
        {
            CurrentHealth = 0;
        }
    }

    public void SetName(string newName)
    {
        Name = newName;
    }


    #region Regeneration Coroutine

    private Coroutine myCoroutine;

    public void StartMyCoroutine()
    {
        if (myCoroutine == null && CoroutineHelper.Instance != null)
        {
            myCoroutine = CoroutineHelper.Instance.StartCoroutine(RegenerateHealth());
        }
    }

    public void StopMyCoroutine()
    {
        if (myCoroutine != null)
        {
            CoroutineHelper.Instance.StopCoroutine(myCoroutine);
            myCoroutine = null;
        }
    }

    public IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // wait for 10 minutes
            if(CurrentHealth < MaxHealth)
            {
                if(CurrentHealth + (int)(MaxHealth * _regenerationRate) >= MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
                else
                {
                    CurrentHealth += (int)(MaxHealth * _regenerationRate);
                }
            }
        }
    }

    #endregion

    #region Characteristics Training

    public void PowerUpgrade()
    {
        if (PowerUpgradeCost <= CurrencyBag.Silver.Amount)
        {
            this.CurrencyBag.Silver.RemoveCurrency(PowerUpgradeCost);
            var result = Math.Round(Math.Pow(PowerLevel - _consNumberForFormula, _raisedNumForPower), 0, MidpointRounding.AwayFromZero);
            PowerUpgradeCost = Convert.ToInt32(result);

            PowerLevel++;
        }
        else
        {
            Debug.Log("Недостаточно серебра для улучшения");
            return;
        }
    }

    public void ProtectionUpgrade()
    {
        if (ProtectionUpgradeCost <= CurrencyBag.Silver.Amount)
        {
            this.CurrencyBag.Silver.RemoveCurrency(ProtectionUpgradeCost);
            var result = Math.Round(Math.Pow(ProtectionLevel - _consNumberForFormula, _raisedNumForProtection), 0, MidpointRounding.AwayFromZero);
            ProtectionUpgradeCost = Convert.ToInt32(result);

            ProtectionLevel++;
        }
        else
        {
            Debug.Log("Недостаточно серебра для улучшения");
            return;
        }
    }

    public void AgilityUpgrade()
    {
        if (AgilityUpgradeCost <= CurrencyBag.Silver.Amount)
        {
            this.CurrencyBag.Silver.RemoveCurrency(AgilityUpgradeCost);
            var result = Math.Round(Math.Pow(AgilityLevel - _consNumberForFormula, _raisedNumForAgility), 0, MidpointRounding.AwayFromZero);
            AgilityUpgradeCost = Convert.ToInt32(result);

            AgilityLevel++;
        }
        else
        {
            Debug.Log("Недостаточно серебра для улучшения");
            return;
        }  
    }

    public void MasteryUpgrade()
    {
        if (MasteryUpgradeCost <= CurrencyBag.Silver.Amount)
        {
            this.CurrencyBag.Silver.RemoveCurrency(MasteryUpgradeCost);
            var result = Math.Round(Math.Pow(MasteryLevel - _consNumberForFormula, _raisedNumForMastery), 0, MidpointRounding.AwayFromZero);
            MasteryUpgradeCost = Convert.ToInt32(result);

            MasteryLevel++;
        }
        else
        {
            Debug.Log("Недостаточно серебра для улучшения");
            return;
        }
    }

    public void VitalityUpgrade()
    {
        if (VitalityUpgradeCost <= CurrencyBag.Silver.Amount)
        {
            this.CurrencyBag.Silver.RemoveCurrency(VitalityUpgradeCost);
            var result = Math.Round(Math.Pow(VitalityLevel - _consNumberForFormula, _raisedNumForVitality), 0, MidpointRounding.AwayFromZero);
            VitalityUpgradeCost = Convert.ToInt32(result);

            VitalityLevel++;

            MaxHealth = MaxHealth + 5 * VitalityLevel;
        }
        else
        {
            Debug.Log("Недостаточно серебра для улучшения");
            return;
        }
    }

    #endregion
}

public class CoroutineHelper : MonoBehaviour
{
    public static CoroutineHelper Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

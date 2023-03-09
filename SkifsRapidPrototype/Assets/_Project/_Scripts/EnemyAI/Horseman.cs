using UnityEngine;

[CreateAssetMenu(fileName = "Horseman", menuName = "Units/CreateNewHorseman", order = 2)]
public class Horseman : ScriptableObject
{

    #region Horseman properties
    public int PowerLevel { get; protected set; } = 6;
    public int ProtectionLevel { get; protected set; } = 6;
    public int AgilityLevel { get; protected set; } = 6;
    public int MasteryLevel { get; protected set; } = 6;
    public int VitalityLevel { get; protected set; } = 6;
    public int MaxHealth { get; protected set; } = 105;

    #endregion

    public CurrencyBag CurrencyBag;

    public virtual void Init()
    {
        PowerLevel = 6;
        ProtectionLevel = 6;
        AgilityLevel = 6;
        MasteryLevel = 6;

        // CurrencyBag = new CurrencyBag();
    }

    public virtual void Init(int powerLevel, int protectionLevel, int agilityLevel, int masteryLevel, int maxHealth)
    {
        PowerLevel = powerLevel;
        ProtectionLevel = protectionLevel;
        AgilityLevel = agilityLevel;
        MasteryLevel = masteryLevel;
        MaxHealth = maxHealth;

        // CurrencyBag = new CurrencyBag();
    }

    private void OnEnable()
    {
        CurrencyBag = CreateInstance<CurrencyBag>();
        CurrencyBag.Init();
    }

    public void TakeDamage(int damage)
    {
        if (MaxHealth - damage >= 0)
        {
            MaxHealth -= damage;
        }
        else
        {
            MaxHealth = 0;
        }
    }

}

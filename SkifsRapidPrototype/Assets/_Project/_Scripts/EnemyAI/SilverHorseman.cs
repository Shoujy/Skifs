using UnityEngine;

public class SilverHorseman : Horseman
{
    public override void Init()
    {
        PowerLevel = Random.Range(6, 9);
        ProtectionLevel = Random.Range(6, 9);
        AgilityLevel = Random.Range(6, 9);
        MasteryLevel = Random.Range(6, 9);
        VitalityLevel = Random.Range(6, 9);
    }

    public override void Init(int playerPower, int playerProtection, int playerAgility, int playerMastery, int playerVitality)
    {
        PowerLevel = (int)(playerPower - playerPower * Random.Range(0.05f, 0.15f));
        ProtectionLevel = (int)(playerProtection - playerProtection * Random.Range(0.05f, 0.15f));
        AgilityLevel = (int)(playerAgility - playerAgility * Random.Range(0.05f, 0.15f));
        MasteryLevel = (int)(playerMastery - playerMastery * Random.Range(0.05f, 0.15f));
        VitalityLevel = (int)(playerVitality - playerVitality * Random.Range(0.05f, 0.15f));
    }
}

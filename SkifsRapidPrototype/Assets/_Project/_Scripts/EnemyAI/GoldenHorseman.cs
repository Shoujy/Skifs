using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldenHorseman : Horseman
{
    public override void Init()
    {
        PowerLevel = Random.Range(16, 21);
        ProtectionLevel = Random.Range(16, 21);
        AgilityLevel = Random.Range(16, 21);
        MasteryLevel = Random.Range(16, 21);
        VitalityLevel = Random.Range(16, 21);
    }

    public override void Init(int playerPower, int playerProtection, int playerAgility, int playerMastery, int playerVitality)
    {
        PowerLevel = (int)Math.Round(playerPower + playerPower * Random.Range(0.1f, 0.2f), 0, MidpointRounding.AwayFromZero);
        ProtectionLevel = (int)Math.Round(playerProtection + playerProtection * Random.Range(0.1f, 0.2f), 0, MidpointRounding.AwayFromZero);
        AgilityLevel = (int)Math.Round(playerAgility + playerAgility * Random.Range(0.1f, 0.2f), 0, MidpointRounding.AwayFromZero);
        MasteryLevel = (int)Math.Round(playerMastery + playerMastery * Random.Range(0.1f, 0.2f), 0, MidpointRounding.AwayFromZero);
        VitalityLevel = (int)Math.Round(playerVitality + playerVitality * Random.Range(0.1f, 0.2f), 0, MidpointRounding.AwayFromZero);
    }
}

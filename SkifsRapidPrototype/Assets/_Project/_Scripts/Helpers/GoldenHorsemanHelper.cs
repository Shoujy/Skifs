using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldenHorsemanHelper : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _horsemanCharacteristics;

    private void Awake()
    {
        Player player = GameSystem.Instance.Player;
        GoldenHorseman goldenHorseman = ScriptableObject.CreateInstance<GoldenHorseman>();
        goldenHorseman.Init(player.PowerLevel, player.ProtectionLevel, player.AgilityLevel, player.MasteryLevel, player.VitalityLevel);

        GameSystem.Instance.Horseman = goldenHorseman;

        _horsemanCharacteristics[0].SetText(goldenHorseman.PowerLevel.ToString());
        _horsemanCharacteristics[1].SetText(goldenHorseman.ProtectionLevel.ToString());
        _horsemanCharacteristics[2].SetText(goldenHorseman.AgilityLevel.ToString());
        _horsemanCharacteristics[3].SetText(goldenHorseman.MasteryLevel.ToString());
        _horsemanCharacteristics[4].SetText(goldenHorseman.VitalityLevel.ToString());
    }
}

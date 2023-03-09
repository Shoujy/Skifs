using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalHorsemanHelper : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _horsemanCharacteristics;

    private void Awake()
    {
        Player player = GameSystem.Instance.Player;
        CrystalHorseman crystalHorseman = ScriptableObject.CreateInstance<CrystalHorseman>();
        crystalHorseman.Init(player.PowerLevel, player.ProtectionLevel, player.AgilityLevel, player.MasteryLevel, player.VitalityLevel);

        GameSystem.Instance.Horseman = crystalHorseman;

        _horsemanCharacteristics[0].SetText(crystalHorseman.PowerLevel.ToString());
        _horsemanCharacteristics[1].SetText(crystalHorseman.ProtectionLevel.ToString());
        _horsemanCharacteristics[2].SetText(crystalHorseman.AgilityLevel.ToString());
        _horsemanCharacteristics[3].SetText(crystalHorseman.MasteryLevel.ToString());
        _horsemanCharacteristics[4].SetText(crystalHorseman.VitalityLevel.ToString());
    }
}

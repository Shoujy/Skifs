using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SilverHorsemanHelper : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _horsemanCharacteristics;

    private void Awake()
    {
        Player player = GameSystem.Instance.Player;
        SilverHorseman silverHorseman = ScriptableObject.CreateInstance<SilverHorseman>();
        silverHorseman.Init(player.PowerLevel, player.ProtectionLevel, player.AgilityLevel, player.MasteryLevel, player.VitalityLevel);

        Debug.Log(silverHorseman.PowerLevel.ToString());
        Debug.Log(silverHorseman.ProtectionLevel.ToString());
        Debug.Log(silverHorseman.AgilityLevel.ToString());
        Debug.Log(silverHorseman.MasteryLevel.ToString());
        Debug.Log(silverHorseman.VitalityLevel.ToString());

        GameSystem.Instance.Horseman = silverHorseman;

        _horsemanCharacteristics[0].SetText(silverHorseman.PowerLevel.ToString());
        _horsemanCharacteristics[1].SetText(silverHorseman.ProtectionLevel.ToString());
        _horsemanCharacteristics[2].SetText(silverHorseman.AgilityLevel.ToString());
        _horsemanCharacteristics[3].SetText(silverHorseman.MasteryLevel.ToString());
        _horsemanCharacteristics[4].SetText(silverHorseman.VitalityLevel.ToString());
    }   
}

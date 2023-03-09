using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacteristicsHorsmanManagerUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _horsemanCharacteristics;

    private TemplateSwitcherUI _templateSwitcherUI;

    public Horseman Horseman;

    private void Awake()
    {
        _templateSwitcherUI = FindObjectOfType<TemplateSwitcherUI>();
    }

    private void OnEnable()
    {

        if(_templateSwitcherUI.IsSilver)
        {
            Horseman = ScriptableObject.CreateInstance<SilverHorseman>();
            Horseman.Init();

            GameSystem.Instance.Horseman = Horseman;
        } 
        else if (_templateSwitcherUI.IsCrystal)
        {
            Horseman = ScriptableObject.CreateInstance<CrystalHorseman>();
            Horseman.Init();

            GameSystem.Instance.Horseman = Horseman;
        }
        else if (_templateSwitcherUI.IsGolden)
        {
            Horseman = ScriptableObject.CreateInstance<GoldenHorseman>();
            Horseman.Init();

            GameSystem.Instance.Horseman = Horseman;
        }
        else
        {
            Debug.Log("Don't find any horseman");
        }


        _horsemanCharacteristics[0].SetText(Horseman.PowerLevel.ToString());
        _horsemanCharacteristics[1].SetText(Horseman.ProtectionLevel.ToString());
        _horsemanCharacteristics[2].SetText(Horseman.AgilityLevel.ToString());
        _horsemanCharacteristics[3].SetText(Horseman.MasteryLevel.ToString());
        _horsemanCharacteristics[4].SetText(Horseman.VitalityLevel.ToString());
    }

    private void OnDisable()
    {

    }
}

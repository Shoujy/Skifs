using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacteristicsPlayerManagerUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _playerCharacteristics;

    private Player _player;

    private void OnEnable()
    {
        _player = GameSystem.Instance.Player;

        _playerCharacteristics[0].SetText(_player.PowerLevel.ToString());
        _playerCharacteristics[1].SetText(_player.ProtectionLevel.ToString());
        _playerCharacteristics[2].SetText(_player.AgilityLevel.ToString());
        _playerCharacteristics[3].SetText(_player.MasteryLevel.ToString());
        _playerCharacteristics[4].SetText(_player.VitalityLevel.ToString());
    }

    private void OnDisable()
    {
        
    }
}

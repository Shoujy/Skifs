using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainingHandlerUI : MonoBehaviour
{
    private Player _player;

    [SerializeField] private List<TextMeshProUGUI> _characteristicsInfoUI= new List<TextMeshProUGUI>();

    private void Awake()
    {
        _player = GameSystem.Instance.Player;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _characteristicsInfoUI[0].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.PowerLevel}\r\nЦена улучшения: {_player.PowerUpgradeCost} серебра");
        _characteristicsInfoUI[1].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.ProtectionLevel}\r\nЦена улучшения: {_player.ProtectionUpgradeCost} серебра");
        _characteristicsInfoUI[2].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.AgilityLevel}\r\nЦена улучшения: {_player.AgilityUpgradeCost} серебра");
        _characteristicsInfoUI[3].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.MasteryLevel}\r\nЦена улучшения: {_player.MasteryUpgradeCost} серебра");
        _characteristicsInfoUI[4].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.VitalityLevel}\r\nЦена улучшения: {_player.VitalityUpgradeCost} серебра");
    }


    #region Upgrade Button
    public void PowerUpgrade()
    {
        _player.PowerUpgrade();

        _characteristicsInfoUI[0].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.PowerLevel}\r\nЦена улучшения: {_player.PowerUpgradeCost} серебра");
    }

    public void ProtectionUpgrade()
    {
        _player.ProtectionUpgrade();

        _characteristicsInfoUI[1].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.ProtectionLevel}\r\nЦена улучшения: {_player.ProtectionUpgradeCost} серебра");
    }

    public void AgilityUpgrade()
    {
        _player.AgilityUpgrade();

        _characteristicsInfoUI[2].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.AgilityLevel}\r\nЦена улучшения: {_player.AgilityUpgradeCost} серебра");
    }

    public void MasteryUpgrade()
    {
        _player.MasteryUpgrade();

        _characteristicsInfoUI[3].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.MasteryLevel}\r\nЦена улучшения: {_player.MasteryUpgradeCost} серебра");
    }

    public void VitalityUpgrade()
    {
        _player.VitalityUpgrade();

        _characteristicsInfoUI[4].SetText($"Определяет какой урон ты можешь заблокировать\r\nУровень: {_player.VitalityLevel}\r\nЦена улучшения: {_player.VitalityUpgradeCost} серебра");
    }

    #endregion
}

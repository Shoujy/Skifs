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
        _characteristicsInfoUI[0].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.PowerLevel}\r\n���� ���������: {_player.PowerUpgradeCost} �������");
        _characteristicsInfoUI[1].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.ProtectionLevel}\r\n���� ���������: {_player.ProtectionUpgradeCost} �������");
        _characteristicsInfoUI[2].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.AgilityLevel}\r\n���� ���������: {_player.AgilityUpgradeCost} �������");
        _characteristicsInfoUI[3].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.MasteryLevel}\r\n���� ���������: {_player.MasteryUpgradeCost} �������");
        _characteristicsInfoUI[4].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.VitalityLevel}\r\n���� ���������: {_player.VitalityUpgradeCost} �������");
    }


    #region Upgrade Button
    public void PowerUpgrade()
    {
        _player.PowerUpgrade();

        _characteristicsInfoUI[0].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.PowerLevel}\r\n���� ���������: {_player.PowerUpgradeCost} �������");
    }

    public void ProtectionUpgrade()
    {
        _player.ProtectionUpgrade();

        _characteristicsInfoUI[1].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.ProtectionLevel}\r\n���� ���������: {_player.ProtectionUpgradeCost} �������");
    }

    public void AgilityUpgrade()
    {
        _player.AgilityUpgrade();

        _characteristicsInfoUI[2].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.AgilityLevel}\r\n���� ���������: {_player.AgilityUpgradeCost} �������");
    }

    public void MasteryUpgrade()
    {
        _player.MasteryUpgrade();

        _characteristicsInfoUI[3].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.MasteryLevel}\r\n���� ���������: {_player.MasteryUpgradeCost} �������");
    }

    public void VitalityUpgrade()
    {
        _player.VitalityUpgrade();

        _characteristicsInfoUI[4].SetText($"���������� ����� ���� �� ������ �������������\r\n�������: {_player.VitalityLevel}\r\n���� ���������: {_player.VitalityUpgradeCost} �������");
    }

    #endregion
}

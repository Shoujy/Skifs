using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayers : MonoBehaviour
{
    [SerializeField] private GameObject _mainTemplate;
    [SerializeField] private BattleSystemPlayers _battleSystem;
    [SerializeField] private GameObject _battleResult;

    public void BattleButton()
    {
        _mainTemplate.SetActive(false);

        _battleSystem.gameObject.SetActive(true);
        _battleResult.SetActive(true);

        GameSystem.Instance.RetargetInfoPanelManually();
    }
}

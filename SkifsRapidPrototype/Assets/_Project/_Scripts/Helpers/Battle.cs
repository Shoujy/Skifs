using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private GameObject _mainTemplate;
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private GameObject _battleResult;

    public void BattleButton()
    {
        _mainTemplate.SetActive(false);

        _battleSystem.gameObject.SetActive(true);
        _battleResult.SetActive(true);

        GameSystem.Instance.RetargetInfoPanelManually();
    }
}

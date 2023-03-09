using UnityEngine;

public class TemplateSwitcherUI : MonoBehaviour
{
    [SerializeField] private GameObject _silverTemplate;
    [SerializeField] private GameObject _crystalTemplate;
    [SerializeField] private GameObject _goldenTemplate;
    [SerializeField] private GameObject _resultTemplate;

    [SerializeField] private BattleSystem _battleSystem;

    public bool IsSilver = true;
    public bool IsCrystal;
    public bool IsGolden;

    private void Awake()
    {
        _silverTemplate.SetActive(true);
        _crystalTemplate.SetActive(false);
        _goldenTemplate.SetActive(false);
        _resultTemplate.SetActive(false);

        IsSilver = true;
        IsCrystal = false;
        IsGolden = false;
    }

    public void SwitchTemplateToCrystal()
    {
        _silverTemplate.SetActive(false);
        _crystalTemplate.SetActive(true);
        _goldenTemplate.SetActive(false);
        _resultTemplate.SetActive(false);

        GameSystem.Instance.RetargetInfoPanelManually();

        IsSilver = false;
        IsCrystal = true;
        IsGolden = false;
    }

    public void SwitchTemplateToGolden()
    {
        _silverTemplate.SetActive(false);
        _crystalTemplate.SetActive(false);
        _goldenTemplate.SetActive(true);
        _resultTemplate.SetActive(false);

        GameSystem.Instance.RetargetInfoPanelManually();

        IsSilver = false;
        IsCrystal = false;
        IsGolden = true;
    }

    public void SwitchTemplateToSilver()
    {
        _silverTemplate.SetActive(true);
        _crystalTemplate.SetActive(false);
        _goldenTemplate.SetActive(false);
        _resultTemplate.SetActive(false);

        GameSystem.Instance.RetargetInfoPanelManually();

        IsSilver = true;
        IsCrystal = false;
        IsGolden = false;
    }

    public void SwitchTemplateToResult()
    {
        _silverTemplate.SetActive(false);
        _crystalTemplate.SetActive(false);
        _goldenTemplate.SetActive(false);

        _battleSystem.gameObject.SetActive(true);

        _resultTemplate.SetActive(true);

        GameSystem.Instance.RetargetInfoPanelManually();
    }
}

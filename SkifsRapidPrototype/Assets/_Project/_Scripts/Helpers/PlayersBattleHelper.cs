using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayersBattleHelper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _opponentName;
    [SerializeField] private List<TextMeshProUGUI> _opponentCharacteristics;
    [SerializeField] private List<TextMeshProUGUI> _opponentDetail;

    [SerializeField] private int _requiredLevel;

    private List<Player> _database;
    private List<Player> _equalToPlayerLevel;

    private void Awake()
    {
        _database = GameSystem.Instance.PlayerDatabase;
        

        if (_requiredLevel == 0)
        {
            _equalToPlayerLevel = _database.Where(player => player.Level == GameSystem.Instance.Player.Level).ToList();
        } 
        else if(_requiredLevel == -1)
        {
            _equalToPlayerLevel = _database.Where(player => player.Level == GameSystem.Instance.Player.Level - 2).ToList();
        }
        else if (_requiredLevel == 1)
        {
            _equalToPlayerLevel = _database.Where(player => player.Level == GameSystem.Instance.Player.Level + 2).ToList();
        }
        else
        {
            Debug.Log("You put not supported value. Required value: -1, 0, 1");
        }



        if (_equalToPlayerLevel.Count > 0)
        {
            int randomIndex = Random.Range(0, _equalToPlayerLevel.Count);

            Player opponent = _equalToPlayerLevel[randomIndex];

            Debug.Log(opponent.PowerLevel.ToString());
            Debug.Log(opponent.ProtectionLevel.ToString());
            Debug.Log(opponent.AgilityLevel.ToString());
            Debug.Log(opponent.MasteryLevel.ToString());
            Debug.Log(opponent.VitalityLevel.ToString());

            GameSystem.Instance.Opponent = opponent;

            _opponentName.SetText(opponent.Name);

            _opponentCharacteristics[0].SetText(opponent.PowerLevel.ToString());
            _opponentCharacteristics[1].SetText(opponent.ProtectionLevel.ToString());
            _opponentCharacteristics[2].SetText(opponent.AgilityLevel.ToString());
            _opponentCharacteristics[3].SetText(opponent.MasteryLevel.ToString());
            _opponentCharacteristics[4].SetText(opponent.VitalityLevel.ToString());

            _opponentDetail[0].SetText(opponent.Level.ToString());
            _opponentDetail[1].SetText(opponent.Experience.ToString());
            _opponentDetail[2].SetText("Побед: 0");
            _opponentDetail[3].SetText("Награбил: 0");
            _opponentDetail[4].SetText("Община: Не состоит");
            _opponentDetail[5].SetText("Гильдия: Не состоит");
            _opponentDetail[6].SetText("Слава: 0");
        }
        else
        {
            Debug.Log("Don't find any equal opponents");
        }

        

       
    }
}

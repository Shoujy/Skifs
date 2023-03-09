using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleSystemPlayers : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _resultInfoTexts;
    [SerializeField] private Sprite _silver;

    private Player _player;
    public Player Opponent;

    private int _playerDamage;
    private int _opponentDamage;


    // For Debuggin
    private string _battlesResult = "";

    private int[] _probability = new int[151];

    private void OnEnable()
    {
        Init();

        Battle();

        Debug.Log("Player overall damage: " + _playerDamage);
        Debug.Log("Horseman overall damage: " + _opponentDamage);

        WinnerDeside();

        Debug.Log(_player.CurrencyBag.Silver.Amount);
        Debug.Log(Opponent.CurrencyBag.Silver.Amount);

        /* Debug and check results
        int j = 1;
        while (j <= 10)
        {
            Debug.Log("Round 1");
            RoundOne();
            Debug.Log("Round 2");
            RoundOne();
            Debug.Log("Round 3");
            RoundOne();

            j++;
        }

        Debug.Log(_battlesResult);
        */
    }

    private void Init()
    {
        _player = GameSystem.Instance.Player;
        Opponent = GameSystem.Instance.Opponent;

        _playerDamage = 0;
        _opponentDamage = 0;

        for (int i = 0; i < _probability.Length; i++)
        {
            _probability[i] = i;
        }
    }

    private void Battle()
    {
        for (int j = 0; j < 3; j++)
        {
            RoundOne();
        }
    }

    private void RoundOne()
    {
        int playerPower = Convert.ToInt32(Math.Ceiling(_player.PowerLevel * 1.5));
        int playerProtection = Convert.ToInt32(Math.Ceiling(((double)_player.ProtectionLevel * _probability[Random.Range(30, 76)] / 100)));
        int playerAgility = Convert.ToInt32(Math.Ceiling(((double)_player.AgilityLevel * _probability[Random.Range(20, 61)] / 100)));
        int playerMastery = Convert.ToInt32(Math.Ceiling(((double)_player.MasteryLevel * _probability[Random.Range(10, 51)] / 100)));

        int horsemanPower = Convert.ToInt32(Math.Ceiling((Opponent.PowerLevel * 1.5)));
        int horsemanProtection = Convert.ToInt32(Math.Ceiling(((double)Opponent.ProtectionLevel * _probability[Random.Range(30, 76)] / 100)));
        int horsemanAgility = Convert.ToInt32(Math.Ceiling(((double)Opponent.AgilityLevel * _probability[Random.Range(20, 61)] / 100)));
        int horsemanMastery = Convert.ToInt32(Math.Ceiling(((double)Opponent.MasteryLevel * _probability[Random.Range(10, 51)] / 100)));

        int playerDamage = playerPower - horsemanProtection - horsemanAgility + playerMastery;
        int horsemanDamage = horsemanPower - playerProtection - playerAgility + horsemanMastery;

        Debug.Log("Player damage: " + playerDamage);
        Debug.Log("Horseman damage: " + horsemanDamage);

        _battlesResult += "Player damage: " + playerDamage + "\r\n";
        _battlesResult += "Horseman damage: " + horsemanDamage + "\r\n";

        _playerDamage += playerDamage;
        _opponentDamage += horsemanDamage;

        _player.TakeDamage(horsemanDamage);
        Opponent.TakeDamage(playerDamage);
    }

    private void WinnerDeside()
    {
        if (_playerDamage > _opponentDamage)
        {
            Debug.Log("Player Win");
            int received = CalculateCurrencyReceive(_player.CurrencyBag, Opponent.CurrencyBag);

            _resultInfoTexts[0].color = Color.green;
            _resultInfoTexts[0].SetText($"Ти победил! Твоя награда - {received} серебра");

            _resultInfoTexts[1].SetText("Причина - Победитель нанес больше сумарного урона");

            _resultInfoTexts[2].SetText($"<color=yellow>Нанесенный урон:</color> \nТы - {_playerDamage} \n{Opponent.Name} - {_opponentDamage}");

            _resultInfoTexts[3].SetText($"<color=yellow>Осталось здоровья:</color> \nУ тебя - {_player.CurrentHealth} \nУ {Opponent.Name} - {Opponent.CurrentHealth}");

            _resultInfoTexts[4].color = Color.yellow;
            _resultInfoTexts[4].SetText("Дополнительная Информация: ");
        }
        else if (_playerDamage < _opponentDamage)
        {
            Debug.Log("Horseman Win");
            int loss = CalculateCurrencyLoss(_player.CurrencyBag, Opponent.CurrencyBag);


            _resultInfoTexts[0].color = Color.red;
            _resultInfoTexts[0].SetText($"Ти проиграл! Ты потерял - {loss} серебра");

            _resultInfoTexts[1].SetText("Причина - Победитель нанес больше сумарного урона");

            _resultInfoTexts[2].SetText($"<color=yellow>Нанесенный урон:</color> \nТы - {_playerDamage} \n{Opponent.Name} - {_opponentDamage}");

            _resultInfoTexts[3].SetText($"<color=yellow>Осталось здоровья:</color> \nУ тебя - {_player.CurrentHealth} \nУ {Opponent.Name} - {Opponent.CurrentHealth}");

            _resultInfoTexts[4].color = Color.yellow;
            _resultInfoTexts[4].SetText("Дополнительная Информация: ");
        }
        else
        {
            Debug.Log("Equel Damage");
        }
    }

    private int CalculateCurrencyReceive(CurrencyBag playerBag, CurrencyBag opponentBag)
    {
        int opponentSilver = opponentBag.Silver.Amount;

        int currencyReceived = Convert.ToInt32(Math.Round(((double)opponentSilver * _probability[Random.Range(6, 13)] / 100), 0, MidpointRounding.AwayFromZero));
        opponentBag.Silver.RemoveCurrency(currencyReceived);
        playerBag.Silver.AddCurrency(currencyReceived);

        return currencyReceived;
    }

    private int CalculateCurrencyLoss(CurrencyBag playerBag, CurrencyBag opponentBag)
    {
        int playerSilver = playerBag.Silver.Amount;

        int currencyLoss = Convert.ToInt32(Math.Round(((double)playerSilver * _probability[Random.Range(6, 13)] / 100), 0, MidpointRounding.AwayFromZero));
        playerBag.Silver.RemoveCurrency(currencyLoss);
        opponentBag.Silver.AddCurrency(currencyLoss);

        return currencyLoss;
    }
}

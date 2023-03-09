using UnityEngine;

public class Currency : ScriptableObject
{
    public string Name { get; private set; }
    public int Amount { get; private set; }

    public void Init(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }

    public void AddCurrency(int currencyAmountToChange)
    {
        Amount += currencyAmountToChange;
    }

    public void RemoveCurrency(int currencyAmountToChange)
    {
        if(Amount - currencyAmountToChange >= 0)
        {
            Amount -= currencyAmountToChange;
        }
        else
        {
            Amount = 0;
        }
    }
}

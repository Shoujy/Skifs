using UnityEngine;

public class CurrencyBag : ScriptableObject
{
    public Currency Silver { get; private set; }
    //public Currency Crystals { get; private set; }
    //public Currency Gold { get; private set; }

    private void OnEnable()
    {
        Silver = CreateInstance<Currency>();
    }

    public void Init()
    {
        Silver.Init("Silver", 1000);
        //Crystals.Init("Crystals", 5);
       // Gold.Init("Gold", 5);
    }
}

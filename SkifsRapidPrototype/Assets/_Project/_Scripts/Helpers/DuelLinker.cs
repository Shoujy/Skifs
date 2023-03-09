using UnityEngine;
using UnityEngine.SceneManagement;

public class DuelLinker : MonoBehaviour
{
    public void SilverButton()
    {
        SceneManager.LoadScene("SilverHorsemen");
    }
    public void NextSilverButton()
    {
        SceneManager.LoadScene("SilverHorsemen");
    }

    public void CrystalButton()
    {
        SceneManager.LoadScene("CrystalHorsemen");
    }

    public void NextCrystalButton()
    {
        SceneManager.LoadScene("CrystalHorsemen");
    }

    public void GoldenButton()
    {
        SceneManager.LoadScene("GoldenHorsemen");
    }

    public void NextGoldenButton()
    {
        SceneManager.LoadScene("GoldenHorsemen");
    }

    public void DuelButton()
    {
        SceneManager.LoadScene("Duel");
    }



    public void NextOpponentButton()
    {
        SceneManager.LoadScene("EquelPlayer");
    }

    public void NextSmallerPlayerButton()
    {
        SceneManager.LoadScene("SmallerPlayer");
    }

    public void NextBiggerPlayerButton()
    {
        SceneManager.LoadScene("BiggerPlayer");
    }

}

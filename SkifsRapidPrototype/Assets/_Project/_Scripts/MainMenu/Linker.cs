using UnityEngine;
using UnityEngine.SceneManagement;

public class Linker : MonoBehaviour
{
    #region Main Menu

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SkifButton()
    {
        SceneManager.LoadScene("Skif");
    }

    #endregion

    #region Skif
    public void TrainingButton()
    {
        SceneManager.LoadScene("Training");
    }

    #endregion

    #region Duel
    public void DuelButton()
    {
        SceneManager.LoadScene("Duel");
    }

    #endregion

    #region Horseman
    public void HorsemenButton()
    {
        SceneManager.LoadScene("SilverHorsemen");
    }

    #endregion

    #region Equel
    public void EquelPlayerButton()
    {
        SceneManager.LoadScene("EquelPlayer");
    }

    #endregion

    #region Smaller
    public void SmallerPlayerButton()
    {
        SceneManager.LoadScene("SmallerPlayer");
    }

    #endregion

    #region Bigger
    public void BiggerPlayerButton()
    {
        SceneManager.LoadScene("BiggerPlayer");
    }

    #endregion
}

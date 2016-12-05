using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class EndScreen : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public Text congrats;

    /// <summary>
    /// 
    /// </summary>
    public Text congratsShadow;

    /// <summary>
    /// This function calls the game to switch over to the character select screen.
    /// </summary>
    public void CharSelect()
    {
        OmniController.Reset();
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// This function keeps the players in the game and causes the game to play again.
    /// </summary>
    public void Rematch()
    {
        SceneManager.LoadScene(1);
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class MainSound : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static MainSound soundMain;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource bomb;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource rocket;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource click;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource win;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource lose;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource mine;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource hurt;

    /// <summary>
    /// 
    /// </summary>
     public AudioSource charge;


    public void Start()
    {
        soundMain = this;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayRocket()
    {
        if (!soundMain.rocket) return;
        soundMain.rocket.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayBomb()
    {
        if (!soundMain.bomb) return;
        soundMain.bomb.volume = .25f;
        soundMain.bomb.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayMine()
    {
        if (!soundMain.mine) return;
        soundMain.mine.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayDamage()
    {
        if (!soundMain.hurt) return;
        soundMain.hurt.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayLose()
    {
        if (!soundMain.lose) return;
        soundMain.lose.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayCharge()
    {
        if (!soundMain.charge) return;
        soundMain.charge.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayWin()
    {
        if (!soundMain.win) return;
        soundMain.win.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PlayClick()
    {
        if (!soundMain.click) return;
        soundMain.click.Play();
    }
}

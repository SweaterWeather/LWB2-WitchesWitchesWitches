using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class MasterController : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    public FollowPlayers cam;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> black;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> cyan;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> magenta;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> yellow;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> green;

    /// <summary>
    /// 
    /// </summary>
    public PlayerMove p1;

    /// <summary>
    /// 
    /// </summary>
    public PlayerMove p2;

    /// <summary>
    /// 
    /// </summary>
    public PlayerMove p3;

    /// <summary>
    /// 
    /// </summary>
    public PlayerMove p4;

    /// <summary>
    /// 
    /// </summary>
    public PlayerMove p5;

    /// <summary>
    /// 
    /// </summary>
    public TakeDamage p1damage;

    /// <summary>
    /// 
    /// </summary>
    public TakeDamage p2damage;

    /// <summary>
    /// 
    /// </summary>
    public TakeDamage p3damage;

    /// <summary>
    /// 
    /// </summary>
    public TakeDamage p4damage;

    /// <summary>
    /// 
    /// </summary>
    public TakeDamage p5damage;

    /// <summary>
    /// 
    /// </summary>
    PlayerInput input;

    /// <summary>
    /// 
    /// </summary>
    AudioSource musicPlayer;

    /// <summary>
    /// 
    /// </summary>
    public AudioClip music;

    /// <summary>
    /// 
    /// </summary>
    List<PlayerMove> players;

    /// <summary>
    /// 
    /// </summary>
    void Start () {
        if(p1)StartBlack();
        if(p2)StartCyan();
        if(p3)StartGreen();
        if(p4)StartYellow();
        if(p5)StartMagenta();

        /*if (p1)
        {
            p1.controller = GetComponentInChildren<Controller0>();
            p1.gameObject.GetComponent<Animate>().sprites = black;
            cam.player1 = p1;
        }
        if (p2)
        {
            p2.controller = GetComponentInChildren<Controller1>();
            p2.gameObject.GetComponent<Animate>().sprites = cyan;
            cam.player2 = p2;
        }
        if (p3)
        {
            p3.controller = GetComponentInChildren<Controller2>();
            p3.gameObject.GetComponent<Animate>().sprites = green;
            cam.player3 = p3;
        }
        if (p4)
        {
            p4.controller = GetComponentInChildren<Controller3>();
            p4.gameObject.GetComponent<Animate>().sprites = yellow;
            cam.player4 = p4;
        }
        if (p5)
        {
            p5.controller = GetComponentInChildren<Controller4>();
            p5.gameObject.GetComponent<Animate>().sprites = magenta;
            //cam.p0 = p5;
        }*/

        input = GetComponent<PlayerInput>();

        Physics.gravity = new Vector3(0, -50, 0);

        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = music;
        musicPlayer.loop = true;
        musicPlayer.volume = .25f;
        musicPlayer.Play();
        
    }
	
	/// <summary>
    /// 
    /// </summary>
	void Update ()
    {
        if (p1damage && p1damage.health <= 0) {
            Destroy(p1damage.gameObject);
            MainSound.PlayLose();
        }
        if (p2damage && p2damage.health <= 0) {
            Destroy(p2damage.gameObject);
            MainSound.PlayLose();
        }
        if (p3damage && p3damage.health <= 0) {
            Destroy(p3damage.gameObject);
            MainSound.PlayLose();
        }
        if (p4damage && p4damage.health <= 0)
        {
            Destroy(p4damage.gameObject);
            MainSound.PlayLose();
        }
        if (p5damage && p5damage.health <= 0)
        {
            Destroy(p5damage.gameObject);
            MainSound.PlayLose();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartBlack()
    {
        switch (OmniController.witchBlack)
        {
            case -1:
                Destroy(p1.gameObject);
                break;
            case 0:
                p1.controller = GetComponentInChildren<Controller0>();
                p1.gameObject.GetComponent<Animate>().sprites = black;
                cam.player1 = p1;
                break;
            case 1:
                p1.controller = GetComponentInChildren<Controller1>();
                p1.gameObject.GetComponent<Animate>().sprites = black;
                cam.player1 = p1;
                break;
            case 2:
                p1.controller = GetComponentInChildren<Controller2>();
                p1.gameObject.GetComponent<Animate>().sprites = black;
                cam.player1 = p1;
                break;
            case 3:
                p1.controller = GetComponentInChildren<Controller3>();
                p1.gameObject.GetComponent<Animate>().sprites = black;
                cam.player1 = p1;
                break;
            case 4:
                p1.controller = GetComponentInChildren<Controller4>();
                p1.gameObject.GetComponent<Animate>().sprites = black;
                cam.player1 = p1;
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartCyan()
    {
        switch (OmniController.witchCyan)
        {
            case -1:
                Destroy(p2.gameObject);
                break;
            case 0:
                p2.controller = GetComponentInChildren<Controller0>();
                p2.gameObject.GetComponent<Animate>().sprites = cyan;
                cam.player2 = p2;
                break;
            case 1:
                p2.controller = GetComponentInChildren<Controller1>();
                p2.gameObject.GetComponent<Animate>().sprites = cyan;
                cam.player2 = p2;
                break;
            case 2:
                p2.controller = GetComponentInChildren<Controller2>();
                p2.gameObject.GetComponent<Animate>().sprites = cyan;
                cam.player2 = p2;
                break;
            case 3:
                p2.controller = GetComponentInChildren<Controller3>();
                p2.gameObject.GetComponent<Animate>().sprites = cyan;
                cam.player2 = p2;
                break;
            case 4:
                p2.controller = GetComponentInChildren<Controller4>();
                p2.gameObject.GetComponent<Animate>().sprites = cyan;
                cam.player2 = p2;
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartGreen()
    {
        switch (OmniController.witchGreen)
        {
            case -1:
                Destroy(p3.gameObject);
                break;
            case 0:
                p3.controller = GetComponentInChildren<Controller0>();
                p3.gameObject.GetComponent<Animate>().sprites = green;
                cam.player3 = p3;
                break;
            case 1:
                p3.controller = GetComponentInChildren<Controller1>();
                p3.gameObject.GetComponent<Animate>().sprites = green;
                cam.player3 = p3;
                break;
            case 2:
                p3.controller = GetComponentInChildren<Controller2>();
                p3.gameObject.GetComponent<Animate>().sprites = green;
                cam.player3 = p3;
                break;
            case 3:
                p3.controller = GetComponentInChildren<Controller3>();
                p3.gameObject.GetComponent<Animate>().sprites = green;
                cam.player3 = p3;
                break;
            case 4:
                p3.controller = GetComponentInChildren<Controller4>();
                p3.gameObject.GetComponent<Animate>().sprites = green;
                cam.player3 = p3;
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartYellow()
    {
        switch (OmniController.witchYellow)
        {
            case -1:
                Destroy(p4.gameObject);
                break;
            case 0:
                p4.controller = GetComponentInChildren<Controller0>();
                p4.gameObject.GetComponent<Animate>().sprites = yellow;
                cam.player4 = p4;
                break;
            case 1:
                p4.controller = GetComponentInChildren<Controller1>();
                p4.gameObject.GetComponent<Animate>().sprites = yellow;
                cam.player4 = p4;
                break;
            case 2:
                p4.controller = GetComponentInChildren<Controller2>();
                p4.gameObject.GetComponent<Animate>().sprites = yellow;
                cam.player4 = p4;
                break;
            case 3:
                p4.controller = GetComponentInChildren<Controller3>();
                p4.gameObject.GetComponent<Animate>().sprites = yellow;
                cam.player4 = p4;
                break;
            case 4:
                p4.controller = GetComponentInChildren<Controller4>();
                p4.gameObject.GetComponent<Animate>().sprites = yellow;
                cam.player4 = p4;
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void StartMagenta()
    {
        switch (OmniController.witchMagenta)
        {
            case -1:
                Destroy(p5.gameObject);
                break;
            case 0:
                p5.controller = GetComponentInChildren<Controller0>();
                p5.gameObject.GetComponent<Animate>().sprites = magenta;
                cam.player4 = p5;
                break;
            case 1:
                p5.controller = GetComponentInChildren<Controller1>();
                p5.gameObject.GetComponent<Animate>().sprites = magenta;
                cam.player4 = p5;
                break;
            case 2:
                p5.controller = GetComponentInChildren<Controller2>();
                p5.gameObject.GetComponent<Animate>().sprites = magenta;
                cam.player4 = p5;
                break;
            case 3:
                p5.controller = GetComponentInChildren<Controller3>();
                p5.gameObject.GetComponent<Animate>().sprites = magenta;
                cam.player4 = p5;
                break;
            case 4:
                p5.controller = GetComponentInChildren<Controller4>();
                p5.gameObject.GetComponent<Animate>().sprites = magenta;
                cam.player4 = p5;
                break;
        }
    }
}

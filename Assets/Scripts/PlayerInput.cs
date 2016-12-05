using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class PlayerInput : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    bool everyOther = false;

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
    public MagicBolt bolt;

    /// <summary>
    /// 
    /// </summary>
    public MagicMine mine;

    /// <summary>
    /// 
    /// </summary>
    public MagicBomb bomb;

    /// <summary>
    /// 
    /// </summary>
    public List<MagicBolt> bolts = new List<MagicBolt>();

    /// <summary>
    /// 
    /// </summary>
    public List<MagicMine> mines = new List<MagicMine>();

    /// <summary>
    /// 
    /// </summary>
    public List<MagicBomb> bombs = new List<MagicBomb>();

    public FollowPlayers cam;

    /// <summary>
    /// 
    /// </summary>
    void Start () {
	
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        everyOther = !everyOther;
        Control(p1);
        Control(p2);
        Control(p3);
        Control(p4);
    }

    /// <summary>
    /// 
    /// </summary>
    void Control(PlayerMove player)
    {
        if (!player) return;
        float check = 0;
        if (player.controller && player.controller.fire1 > 0)
        {
            if (player.canShoot)
            {
                MakeBolts(player);
                player.canShoot = false;
            }
            player.charging.x += Time.deltaTime;
        }
        else if (player.controller && player.controller.fire1 == 0)
        {
            check++;
            player.charging.x = 0;
        }
        if (player.controller && player.controller.fire2 > 0)
        {
            if (player.canShoot)
            {
                MakeMines(player);
                player.canShoot = false;
            }
            player.charging.y += Time.deltaTime;
        }
        else if (player.controller && player.controller.fire2 == 0)
        {
            check++;
            player.charging.y = 0;
        }
        if (player.controller && player.controller.fire3 > 0)
        {
            if (player.canShoot)
            {
                MakeBombs(player);
                player.canShoot = false;
            }
            player.charging.z += Time.deltaTime;
        }
        else if (player.controller && player.controller.fire3 == 0)
        {
            check++;
            player.charging.z = 0;
        }

        if (check >= 3) player.canShoot = true;

        if (player.charging.x >= 1)
        {
            player.charging = new Vector3();
            player.chargeShot = new Vector3(10, 0, 0);
        }
        if (player.charging.y >= 1)
        {
            player.charging = new Vector3();
            player.chargeShot = new Vector3(0, 10, 0);
        }
        if (player.charging.z >= 1)
        {
            player.charging = new Vector3();
            player.chargeShot = new Vector3(0, 0, 10);
        }

        if (player.chargeShot.x > 0 && everyOther)
        {
            player.chargeShot.x--;
            player.charging = new Vector3();
            MakeBolts(player);
        }
        if (player.chargeShot.y > 0 && everyOther)
        {
            player.chargeShot.y--;
            player.charging = new Vector3();
            MakeMines(player);
        }
        if (player.chargeShot.z > 0 && everyOther)
        {
            player.chargeShot.z--;
            player.charging = new Vector3();
            MakeBombs(player);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    MagicBolt MakeBolts(PlayerMove player)
    {
        MagicBolt mBolt = Instantiate(bolt, player.transform.position, Quaternion.identity) as MagicBolt;
        mBolt.transform.eulerAngles = player.transform.eulerAngles;
        bolts.Add(mBolt);

        MainSound.PlayRocket();

        return mBolt;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    MagicMine MakeMines(PlayerMove player)
    {
        MagicMine mMine = Instantiate(mine, player.transform.position, Quaternion.identity) as MagicMine;
        mMine.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        mMine.body = mMine.GetComponent<Rigidbody>();
        mMine.body.velocity = player.body.velocity;
        mines.Add(mMine);

        return mMine;
    }


    MagicBomb MakeBombs(PlayerMove player)
    {
        MagicBomb mBomb = Instantiate(bomb, player.transform.position, Quaternion.identity) as MagicBomb;
        mBomb.transform.eulerAngles = player.transform.eulerAngles;
        mBomb.body = mBomb.GetComponent<Rigidbody>();
        mBomb.body.velocity = player.body.velocity * 1.05f;
        mBomb.body.AddRelativeForce(-750, 150, 0);
        bombs.Add(mBomb);

        MainSound.PlayBomb();

        return mBomb;
    }
}

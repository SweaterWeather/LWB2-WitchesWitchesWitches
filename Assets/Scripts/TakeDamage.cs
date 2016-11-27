using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class TakeDamage : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    public Vector3 color;

    /// <summary>
    /// 
    /// </summary>
    public Rotate hp;

    /// <summary>
    /// 
    /// </summary>
    public SpriteRenderer shieldBase;

    /// <summary>
    /// 
    /// </summary>
     Rotate hp1;

    /// <summary>
    /// 
    /// </summary>
     Rotate hp2;

    /// <summary>
    /// 
    /// </summary>
     Rotate hp3;

    /// <summary>
    /// 
    /// </summary>
    SpriteRenderer shield;

    /// <summary>
    /// 
    /// </summary>
    public int health = 3;

    /// <summary>
    /// 
    /// </summary>
    public float shielded = 0;

    /// <summary>
    /// 
    /// </summary>
    public ControllerBase controller;

    /// <summary>
    /// 
    /// </summary>
    bool canShield = true;

    /// <summary>
    /// 
    /// </summary>
    float iFrames = 0;

    /// <summary>
    /// 
    /// </summary>
    PlayerMove playerMove;

	/// <summary>
    /// 
    /// </summary>
	void Start ()
    {
        hp1 = Instantiate(hp);
        hp2 = Instantiate(hp);
        hp3 = Instantiate(hp);
        shield = Instantiate(shieldBase);
        shield.transform.localScale *= 1.5f;

        playerMove = GetComponent<PlayerMove>();
        controller = playerMove.controller;
        
        hp1.transform.localEulerAngles = new Vector3(0, 0, 120);
        hp2.transform.localEulerAngles = new Vector3(0, 0, 240);
        hp3.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
	
	/// <summary>
    /// 
    /// </summary>
	void Update ()
    {
        if (hp1)hp1.transform.position = transform.position;
        if(hp2)hp2.transform.position = transform.position;
        if(hp3)hp3.transform.position = transform.position;
        if(shield)shield.transform.position = transform.position;

        if(shield)shield.enabled = (shielded > 0) ? true : false;

        if (!controller) return;

        if(shielded <= 0 && controller.shield > 0 && canShield)
        {
            shielded = 1;
            canShield = false;
        }
        else if(shielded > 0){
            shielded -= Time.deltaTime;
            iFrames -= Time.deltaTime;
        }

        if(controller.shield <= 0 && iFrames <= 0)
        {
            shielded = 0;
            canShield = true;
            playerMove.body.useGravity = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (shielded > 0) return;
        if(collision.gameObject.tag == "Rocket" || collision.gameObject.tag == "Mine" || collision.gameObject.tag == "Bomb")
        {
            Vector3 launch = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            Vector3.Normalize(launch);
            playerMove.body.AddRelativeForce(launch * 1000);
            playerMove.body.useGravity = true;
            health--;
            shielded = 1;
            iFrames = 1;

            MainSound.PlayDamage();

            if (health == 2)
            {
                Destroy(hp1.gameObject);
            }
            else if (health == 1) Destroy(hp2.gameObject);
            else if (health == 0)
            {
                Destroy(hp3.gameObject);
                Destroy(shield.gameObject);

                //Destroy(this.gameObject);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// This is the script to control player movement.  It accepts movement related controller inputs, shield inputs,
/// and then applies those inputs to modify the physics being exerted on the player character.  It also locks out
/// input not relevant to this player in the event of a multiplayer match.
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// This float represents the speed at which the player may move.
    /// </summary>
    public float speed = 50;

    /// <summary>
    /// This is the ammount at which players will twist while turning.
    /// </summary>
    public float twist = 5;

    /// <summary>
    /// This controller accepts input from the player 0 controller (the keyboard).
    /// </summary>
    public Controller0 p0;

    /// <summary>
    /// This controller accepts input from the player 1 controller.
    /// </summary>
    public Controller1 p1;

    /// <summary>
    /// This controller accepts input from the player 2 controller.
    /// </summary>
    public Controller2 p2;

    /// <summary>
    /// This controller accepts input from the player 3 controller.
    /// </summary>
    public Controller3 p3;

    /// <summary>
    /// This controller accepts input from the player 4 controller.
    /// </summary>
    public Controller4 p4;

    /// <summary>
    /// This is the controller that the player will actually use.  In the master controller script's start function, this
    /// will be immediatly set as controller 0-4 as needed.
    /// </summary>
    public ControllerBase controller;

    /// <summary>
    /// This int tracks which player this player is.
    /// </summary>
    public int playerNum = 1;

    /// <summary>
    /// This is a reference to the physical body of the player.
    /// </summary>
    public Rigidbody body;

    /// <summary>
    /// 
    /// </summary>
    public ParticleSystem chargeStars;

    /// <summary>
    /// 
    /// </summary>
    public bool canShoot = true;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 charging = new Vector3();

    /// <summary>
    /// 
    /// </summary>
    public Vector3 chargeShot = new Vector3();

    /// <summary>
    /// 
    /// </summary>
    public ParticleSystem part;

    /// <summary>
    /// 
    /// </summary>
    TakeDamage damage;

    /// <summary>
    /// This is the startup function for the playermove script.
    /// </summary>
    void Start () {
        body = GetComponent<Rigidbody>();
        ParticleSystem.EmissionModule em = chargeStars.emission;
        em.enabled = false;

        damage = GetComponent<TakeDamage>();
        damage.controller = controller;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        ParticleSystem.EmissionModule em = chargeStars.emission;
        if (charging.x > .1f || charging.y > .1f || charging.z > .1f)
        {
            em.enabled = true;
            //OmniController.PlayCharge(GetComponentInParent<MasterController>().GetComponentInChildren<FollowPlayers>().transform.position);
        }
        else em.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag != "Environment") return;

        transform.eulerAngles += new Vector3(0, 0, 180);
    }
	
	/// <summary>
    /// This is the primary update function of the playermove script.  It calls the subsequent control and move functions.
    /// </summary>
	void FixedUpdate ()
    {
        Control();
    }

    /// <summary>
    /// This is the control update function.  It takes instruction from the controller monobehavior, and then calls for
    /// the appropriate movement action to corrospond.
    /// </summary>
    void Control()
    {
        //Test();

        if (!controller) return;

        Vector3 input = new Vector3(controller.horizontal, controller.vertical);
        if (input.sqrMagnitude > 1) input.Normalize();

        if (damage.shielded > 0) input = new Vector3();

        ParticleSystem.EmissionModule emm = part.emission;
        if (input != new Vector3(0, 0, 0))
        {
            body.drag = 10;
            body.angularDrag = 10;
            Move(input);
            foreach(Transform child in part.transform)
            {
                ParticleSystem parts = child.GetComponent<ParticleSystem>();
                ParticleSystem.EmissionModule em = parts.emission;
                em.enabled = true;
                emm.enabled = true;
            }
        }
        else
        {
            body.drag = 1;
            body.angularDrag = 5;
            foreach (Transform child in part.transform)
            {
                ParticleSystem parts = child.GetComponent<ParticleSystem>();
                ParticleSystem.EmissionModule em = parts.emission;
                em.enabled = false;
                emm.enabled = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void TwistClockwise(float angle)
    {
        body.AddTorque(new Vector3(0, 0, angle * -twist));
    }

    /// <summary>
    /// 
    /// </summary>
    void TwistCounterClockwise(float angle)
    {
        body.AddTorque(new Vector3(0, 0, angle * twist));
    }

    /// <summary>
    /// 
    /// </summary>
    void Advance()
    {
        body.AddRelativeForce(0, speed, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    void Rotate(float X, float Y)
    {
        transform.eulerAngles += new Vector3 (0, 0, Mathf.Atan2(Y, X));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    void Move(Vector3 input)
    {
        float angle = transform.eulerAngles.z;
        float inputAngle = Mathf.Atan2(input.y, input.x) * 180 / Mathf.PI;

        //if (inputAngle < 0) inputAngle += 360;
        inputAngle -= angle - 90;

        if (inputAngle < 0) inputAngle += 360;
        //inputAngle += 360;
        //angle += 360;

        if (183 > inputAngle)
        {
            TwistClockwise(360 - inputAngle);
        }
        else if (177 < inputAngle)
        {
            TwistCounterClockwise(inputAngle);
        }

        Advance();
    }

    /// <summary>
    /// 
    /// </summary>
    void Test()
    {

        ///input test field
        if (Input.GetAxis("PausePad1") > 0 || Input.GetAxis("PauseKey") > 0)
        {
            print("Pause");
        }
        if (Input.GetAxis("Fire1Pad1") > 0 || Input.GetAxis("Fire1Key") > 0)
        {
            print("Fire1");
        }
        if (Input.GetAxis("Fire2Pad1") > 0 || Input.GetAxis("Fire2Key") > 0)
        {
            print("Fire2");
        }
        if (Input.GetAxis("Fire3Pad1") > 0 || Input.GetAxis("Fire3Key") > 0)
        {
            print("Fire3");
        }
        if (Input.GetAxis("ShieldPad1") > 0 || Input.GetAxis("ShieldKey") > 0)
        {
            print("Shield");
        }

        if(Input.GetAxis("HorizontalKey") > 0 || Input.GetAxis("VerticalKey") > 0)
        {
            body.AddRelativeForce(0, 50, 0);
        }
        if(Input.GetAxis("ShieldKey") > 0)
        {
            body.AddTorque(0, 0, -5);
        }
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class MagicBolt : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public float speed;

    /// <summary>
    /// 
    /// </summary>
    public Rigidbody body;

    /// <summary>
    /// 
    /// </summary>
    float timeTillActive = .1f;

    /// <summary>
    /// 
    /// </summary>
    BoxCollider bCollider;

    /// <summary>
    /// 
    /// </summary>
    float lifeSpan = 7f;

	/// <summary>
    /// 
    /// </summary>
	void Start () {
        body = GetComponent<Rigidbody>();
        body.AddRelativeForce(0, speed, 0);

        bCollider = GetComponent<BoxCollider>();
        bCollider.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update ()
    {
        if (timeTillActive > 0 && !bCollider.enabled) timeTillActive -= Time.deltaTime;
        else bCollider.enabled = true;

        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0) Destroy(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}

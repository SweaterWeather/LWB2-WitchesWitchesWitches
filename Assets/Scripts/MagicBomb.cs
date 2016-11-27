using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class MagicBomb : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    public Rigidbody body;

    /// <summary>
    /// 
    /// </summary>
    float timeTillActive = .2f;

    /// <summary>
    /// 
    /// </summary>
    CapsuleCollider cCollider;

    /// <summary>
    /// 
    /// </summary>
    float lifeSpan = 7f;

    /// <summary>
    /// 
    /// </summary>
    void Start () {
        cCollider = GetComponent<CapsuleCollider>();
        cCollider.enabled = false;

        body = GetComponent<Rigidbody>();
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        if (timeTillActive > 0 && !cCollider.enabled) timeTillActive -= Time.deltaTime;
        else cCollider.enabled = true;

        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0 || body.velocity.sqrMagnitude < .1f) Destroy(this.gameObject);
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag != "Environment") return;
        
        body.velocity = new Vector3(body.velocity.x, -body.velocity.y, body.velocity.z);        
    }
}

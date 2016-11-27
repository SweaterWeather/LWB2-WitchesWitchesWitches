using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class MagicMine : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    public Rigidbody body;

    /// <summary>
    /// 
    /// </summary>
    float timeTillActive = 2f;

    /// <summary>
    /// 
    /// </summary>
    SphereCollider sCollider;

    /// <summary>
    /// 
    /// </summary>
    Animate animate;

    /// <summary>
    /// 
    /// </summary>
    void Start () {
        sCollider = GetComponent<SphereCollider>();
        sCollider.enabled = false;

        body = GetComponent<Rigidbody>();
        animate = GetComponent<Animate>();
        animate.pause = true;
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update ()
    {
        if (timeTillActive > 0 && !sCollider.enabled) timeTillActive -= Time.deltaTime;
        else sCollider.enabled = true;

        if (sCollider.enabled)
        {
            if (animate.pause == true)
            {
                MainSound.PlayMine();
            }

            animate.pause = false;

            transform.localScale += new Vector3(1, 1, 1) * 30 * Time.deltaTime;
            if (transform.localScale.x > 25) Destroy(this.gameObject);
        }
    }
}

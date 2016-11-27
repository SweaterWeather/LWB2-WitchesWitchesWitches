using UnityEngine;
using System.Collections;

/// <summary>
/// This script just makes the health icons rotate the player.
/// </summary>
public class Rotate : MonoBehaviour {
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        transform.localEulerAngles += new Vector3(0, 0, 360) * Time.deltaTime;
	}
}

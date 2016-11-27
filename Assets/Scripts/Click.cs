using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Click : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
	public void PlayClick()
    {
        AudioSource click = GetComponent<AudioSource>();
        click.Play();
    }
}

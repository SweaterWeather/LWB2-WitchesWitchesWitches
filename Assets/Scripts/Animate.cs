using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class Animate : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public float frameRate = 24;

    /// <summary>
    /// 
    /// </summary>
    public bool pause;

    /// <summary>
    /// 
    /// </summary>
    float frameSwitch = 0;

    /// <summary>
    /// 
    /// </summary>
    int currentFrame;

    /// <summary>
    /// 
    /// </summary>
    public List<Sprite> sprites;

    /// <summary>
    /// 
    /// </summary>
    SpriteRenderer rend;

	/// <summary>
    /// 
    /// </summary>
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        if(sprites.Count > 0 && sprites[0] is Sprite) rend.sprite = sprites[0] as Sprite;
        currentFrame = 0;
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        if (pause) return;

        rend.sprite = sprites[currentFrame];

        frameSwitch += Time.deltaTime * frameRate;
        if (frameSwitch >= 1)
        {
            frameSwitch = 0;
            currentFrame++;
            if (currentFrame > sprites.Count - 1) currentFrame = 0;
        }
	}
}

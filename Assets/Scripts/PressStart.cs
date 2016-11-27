using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class PressStart : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    public Transform text1;

    /// <summary>
    /// 
    /// </summary>
    public Transform text2;

    /// <summary>
    /// 
    /// </summary>
    public Transform text3;

    /// <summary>
    /// 
    /// </summary>
    Vector3 start1;

    /// <summary>
    /// 
    /// </summary>
    Vector3 start2;

    /// <summary>
    /// 
    /// </summary>
    Vector3 start3;

    /// <summary>
    /// 
    /// </summary>
    AudioSource music;

    /// <summary>
    /// 
    /// </summary>
    public Click click;

    /// <summary>
    /// 
    /// </summary>
    void Start ()
    {
        start1 = text1.transform.position;
        start2 = text2.transform.position;
        start3 = text3.transform.position;

        text1.transform.position = new Vector3(5000, 5000);
        text2.transform.position = new Vector3(5000, 5000);
        text3.transform.position = new Vector3(5000, 5000);

        music = GetComponent<AudioSource>();
        music.volume = .3f;
        music.Play();
    }
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        if (OmniController.numberReady >= 2)
        {
            text1.transform.position = start1;
            text2.transform.position = start2;
            text3.transform.position = start3;

            if (Input.GetAxis("PauseKey") > 0 || Input.GetAxis("PausePad1") > 0 || Input.GetAxis("PausePad2") > 0 || Input.GetAxis("PausePad3") > 0 || Input.GetAxis("PausePad4") > 0)
            {
                click.PlayClick();
                SceneManager.LoadScene("main");
            }
        }
	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class CamPivot : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    bool start = false;


    public Click click;
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
	if(Input.GetAxis("PauseKey") > 0 || Input.GetAxis("PausePad1") > 0 || Input.GetAxis("PausePad2") > 0 || Input.GetAxis("PausePad3") > 0 || Input.GetAxis("PausePad4") > 0)
        {
            click.PlayClick();
            start = true;
        }
        if (start)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Time.deltaTime * 100);
            if (transform.eulerAngles.y < 300) transform.eulerAngles = new Vector3();
        }
	}
}

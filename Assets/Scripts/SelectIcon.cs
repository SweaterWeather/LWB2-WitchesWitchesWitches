using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class SelectIcon : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public ControllerBase controller;

    /// <summary>
    /// 
    /// </summary>
    public int contID;

    /// <summary>
    /// 
    /// </summary>
    int selectID;

    /// <summary>
    /// 
    /// </summary>
    bool canSwap = true;

    /// <summary>
    /// 
    /// </summary>
    bool lockedIn = false;

    /// <summary>
    /// 
    /// </summary>
    public int thisController;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 black;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 cyan;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 magenta;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 yellow;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 green;

    /// <summary>
    /// 
    /// </summary>
    public Click click;

    /// <summary>
    /// 
    /// </summary>
    SpriteRenderer rend;

    /// <summary>
    /// 
    /// </summary>
    public static bool canBlack = true;

    /// <summary>
    /// 
    /// </summary>
    public static bool canCyan = true;

    /// <summary>
    /// 
    /// </summary>
    public static bool canMagenta = true;

    /// <summary>
    /// 
    /// </summary>
    public static bool canYellow = true;

    /// <summary>
    /// 
    /// </summary>
    public static bool canGreen = true;

    /// <summary>
    /// 
    /// </summary>
    void Start () {
        /*switch (contID)
        {
            case 0:
                controller = new Controller0();
                break;
            case 1:
                controller = new Controller1();
                break;
            case 2:
                controller = new Controller2();
                break;
            case 3:
                controller = new Controller3();
                break;
            case 4:
                controller = new Controller4();
                break;
        }*/

        rend = GetComponent<SpriteRenderer>();

        rend.enabled = false;
	}
	
	/// <summary>
    /// 
    /// </summary>
	void Update () {
        if (lockedIn) return;
        if (OmniController.numberReady >= 4) Destroy(this.gameObject);

        switch (selectID)
        {
            case 0:
                transform.localPosition = black;

                if (!canSwap) break;
                //right
                if(controller.horizontal > 0)
                {
                    canSwap = false;
                    selectID = 2;
                    rend.enabled = true;
                    //left
                }else if (controller.horizontal < 0)
                {
                    canSwap = false;
                    selectID = 1;
                    rend.enabled = true;
                    //up or down
                }else if (controller.vertical != 0)
                {
                    canSwap = false;
                    selectID = 3;
                    rend.enabled = true;
                }

                if (controller.shield > 0 && canBlack || controller.fire2 > 0 && canBlack)
                {
                    OmniController.SetBlack(thisController);
                    lockedIn = true;
                    canBlack = false;
                    click.PlayClick();
                }
                break;
            case 1:
                transform.localPosition = cyan;

                if (!canSwap) break;
                //right
                if (controller.horizontal > 0)
                {
                    canSwap = false;
                    selectID = 0;
                    rend.enabled = true;
                }
                //left
                else if (controller.horizontal < 0)
                {
                    canSwap = false;
                    selectID = 4;
                    rend.enabled = true;
                }
                //down
                else if (controller.vertical < 0)
                {
                    canSwap = false;
                    selectID = 0;
                    rend.enabled = true;
                    //up
                }else if (controller.vertical > 0)
                {
                    canSwap = false;
                    selectID = 3;
                    rend.enabled = true;
                }

                if (controller.shield > 0 && canCyan|| controller.fire2 > 0 && canCyan)
                {
                    OmniController.SetCyan(thisController);
                    lockedIn = true;
                    canCyan = false;
                    click.PlayClick();
                }
                break;
            case 2:
                transform.localPosition = magenta;

                if (!canSwap) break;
                //right
                if (controller.horizontal > 0)
                {
                    canSwap = false;
                    selectID = 1;
                    rend.enabled = true;
                }
                //left
                else if (controller.horizontal < 0)
                {
                    canSwap = false;
                    selectID = 0;
                    rend.enabled = true;
                }
                //down
                else if (controller.vertical < 0)
                {
                    canSwap = false;
                    selectID = 4;
                    rend.enabled = true;
                }
                //up
                else if (controller.vertical > 0)
                {
                    canSwap = false;
                    selectID = 3;
                    rend.enabled = true;
                }

                if (controller.shield > 0 && canMagenta|| controller.fire2 > 0 && canMagenta)
                {
                    OmniController.SetMagenta(thisController);
                    lockedIn = true;
                    canMagenta = false;
                    click.PlayClick();
                }
                break;
            case 3:
                transform.localPosition = yellow;

                if (!canSwap) break;
                //right
                if (controller.horizontal > 0)
                {
                    canSwap = false;
                    selectID = 2;
                    rend.enabled = true;
                }
                //left
                else if (controller.horizontal < 0)
                {
                    canSwap = false;
                    selectID = 1;
                    rend.enabled = true;
                }
                //down
                else if (controller.vertical < 0)
                {
                    canSwap = false;
                    selectID = 0;
                    rend.enabled = true;
                }
                //up
                else if (controller.vertical > 0)
                {
                    canSwap = false;
                    selectID = 4;
                    rend.enabled = true;
                }

                if (controller.shield > 0 && canYellow || controller.fire2 > 0 && canYellow)
                {
                    OmniController.SetYellow(thisController);
                    lockedIn = true;
                    canYellow = false;
                    click.PlayClick();
                }
                break;
            case 4:
                transform.localPosition = green;

                if (!canSwap) break;
                //right
                if (controller.horizontal > 0)
                {
                    canSwap = false;
                    selectID = 1;
                    rend.enabled = true;
                }
                //left
                else if (controller.horizontal < 0)
                {
                    canSwap = false;
                    selectID = 0;
                    rend.enabled = true;
                }
                //down
                else if (controller.vertical < 0)
                {
                    canSwap = false;
                    selectID = 3;
                    rend.enabled = true;
                }
                //up
                else if (controller.vertical > 0)
                {
                    canSwap = false;
                    selectID = 2;
                    rend.enabled = true;
                }

                if(controller.shield > 0 && canGreen || controller.fire2 > 0 && canGreen)
                {
                    OmniController.SetGreen(thisController);
                    lockedIn = true;
                    canGreen = false;
                    click.PlayClick();
                }
                break;
        }
        if(controller.horizontal == 0 && controller.vertical == 0)
        {
            canSwap = true;
        }
	}
}

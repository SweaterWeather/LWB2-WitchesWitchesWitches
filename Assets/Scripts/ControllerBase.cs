using UnityEngine;
using System.Collections;

/// <summary>
/// This is the generic version of the controller script, all it does is establish the various floats that its children need.
/// </summary>
public class ControllerBase : MonoBehaviour {


    /// <summary>
    /// This is set equal to the horizontal input axis of the corrosponding controller.
    /// </summary>
    public float horizontal;

    /// <summary>
    /// This is set equal to the vertical input axis of the corrosponding controller.
    /// </summary>
    public float vertical;

    /// <summary>
    /// This is set equal to the fire1 input axis of the corrosponding controller.
    /// </summary>
    public float fire1;

    /// <summary>
    /// This is set equal to the fire2 input axis of the corrosponding controller.
    /// </summary>
    public float fire2;

    /// <summary>
    /// This is set equal to the up fire3 axis of the corrosponding controller.
    /// </summary>
    public float fire3;

    /// <summary>
    /// This is set equal to the pause input axis of the corrosponding controller.
    /// </summary>
    public float pause;

    /// <summary>
    /// This is set equal to the shield input axis of the corrosponding controller.
    /// </summary>
    public float shield;
}

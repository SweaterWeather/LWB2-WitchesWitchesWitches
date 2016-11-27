using UnityEngine;
using System.Collections;

/// <summary>
/// This script serves as an easy to use buffer between the axis inputs and the player control.  It makes sure that the player
/// will use inputs from only the correct controller while still only having to input a simple request such as "fire1" instead
/// of having to type out "Fire1Pad3" for example.
/// 
/// This particular script handles keyboard input.
/// </summary>
public class Controller3 : ControllerBase
{

    /// <summary>
    /// This is the update loop for this interface class.  Every frame it updates the various public fields so they match the
    /// proper interface input.
    /// </summary>
    void Update()
    {
        horizontal = Input.GetAxis("HorizontalPad3");
        vertical = Input.GetAxis("VerticalPad3");
        fire1 = Input.GetAxis("Fire1Pad3");
        fire2 = Input.GetAxis("Fire2Pad3");
        fire3 = Input.GetAxis("Fire3Pad3");
        shield = Input.GetAxis("ShieldPad3");
        pause = Input.GetAxis("PausePad3");
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// This script serves as an easy to use buffer between the axis inputs and the player control.  It makes sure that the player
/// will use inputs from only the correct controller while still only having to input a simple request such as "fire1" instead
/// of having to type out "Fire1Pad3" for example.
/// 
/// This particular script handles keyboard input.
/// </summary>
public class Controller1 : ControllerBase
{

    /// <summary>
    /// This is the update loop for this interface class.  Every frame it updates the various public fields so they match the
    /// proper interface input.
    /// </summary>
    void Update()
    {
        horizontal = Input.GetAxis("HorizontalPad1");
        vertical = Input.GetAxis("VerticalPad1");
        fire1 = Input.GetAxis("Fire1Pad1");
        fire2 = Input.GetAxis("Fire2Pad1");
        fire3 = Input.GetAxis("Fire3Pad1");
        shield = Input.GetAxis("ShieldPad1");
        pause = Input.GetAxis("PausePad1");
    }
}

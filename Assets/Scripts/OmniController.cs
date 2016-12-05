using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public static class OmniController : object
{

    /// <summary>
    /// 
    /// </summary>
    public static int witchBlack = -1;

    /// <summary>
    /// 
    /// </summary>
    public static int witchCyan = -1;

    /// <summary>
    /// 
    /// </summary>
    public static int witchMagenta = -1;

    /// <summary>
    /// 
    /// </summary>
    public static int witchYellow = -1;

    /// <summary>
    /// 
    /// </summary>
    public static int witchGreen = -1;

    /// <summary>
    /// 
    /// </summary>
    public static int numberReady = 0;

    /// <summary>
    /// 
    /// </summary>
    public static void Reset()
    {
        SelectIcon.canBlack = true;
        SelectIcon.canCyan = true;
        SelectIcon.canGreen = true;
        SelectIcon.canMagenta = true;
        SelectIcon.canYellow = true;

        witchBlack = -1;
        witchCyan = -1;
        witchGreen = -1;
        witchMagenta = -1;
        witchYellow = -1;

        numberReady = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetBlack(int index)
    {
        witchBlack = index;
        numberReady++;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetCyan(int index)
    {
        witchCyan = index;
        numberReady++;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetMagenta(int index)
    {
        witchMagenta = index;
        numberReady++;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetYellow(int index)
    {
        witchYellow = index;
        numberReady++;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetGreen(int index)
    {
        witchGreen = index;
        numberReady++;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This script tracks the target location of the camera so that it is always pointed directly in the middle of the combating witches, and
/// is zoomed out so that everyone can see what they are doing.
/// For a weird bit of convience on my part, this script also handles many functions related to the final win screen, since it has to keep 
/// track of how many players are in the game anyway it only makes sense for it to declare the only remaining player the winner.
/// </summary>
public class FollowPlayers : MonoBehaviour
{
    /// <summary>
    /// This int tracks the total number of players in the game.
    /// </summary>
    int totalPlayers = 2;

    /// <summary>
    /// This float tracks the speed of the camera?  I'm not sure, I don't think this property is actually used but I'm too scared to delete it.
    /// </summary>
    public float speed = 200;

    /// <summary>
    /// This is a reference to the magenta witch.
    /// </summary>
    public PlayerMove player0;

    /// <summary>
    /// This is a reference to the black witch.
    /// </summary>
    public PlayerMove player1;

    /// <summary>
    /// This is a reference to the cyan witch.
    /// </summary>
    public PlayerMove player2;

    /// <summary>
    /// This is a reference to the green witch.
    /// </summary>
    public PlayerMove player3;

    /// <summary>
    /// This is a reference to the yellow witch.
    /// </summary>
    public PlayerMove player4;

    /// <summary>
    /// This is the position of the magenta witch.
    /// </summary>
    Vector3 p0 = new Vector3();

    /// <summary>
    /// This is the position of the black witch.
    /// </summary>
    Vector3 p1 = new Vector3();

    /// <summary>
    /// This is the position of the cyan witch.
    /// </summary>
    Vector3 p2 = new Vector3();

    /// <summary>
    /// This is the position of the green witch.
    /// </summary>
    Vector3 p3 = new Vector3();

    /// <summary>
    /// This is the position of the yellow witch.
    /// </summary>
    Vector3 p4 = new Vector3();

    /// <summary>
    /// This is the point in space that the camera should move towards.
    /// </summary>
    Vector3 target;

    /// <summary>
    /// This is a reference to the UI element from the end of the game.
    /// </summary>
    public EndScreen endScreen;

    /// <summary>
    /// This is a reference to the event system of this scene.
    /// </summary>
    public EventSystem events;

    /// <summary>
    /// This bool tracks whether or not the ending has triggered or not.
    /// </summary>
    bool hasEnded = false;

    /// <summary>
    /// This is the button to play a rematch.
    /// </summary>
    public Button rematch;
	
	/// <summary>
    /// This is the fixed update loop
    /// </summary>
	void FixedUpdate ()
    {
        totalPlayers = 0;
        if (player0) totalPlayers++;
        if (player1) totalPlayers++;
        if (player2) totalPlayers++;
        if (player3) totalPlayers++;
        if (player4) totalPlayers++;

        if (totalPlayers > 1)
        {
            endScreen.gameObject.SetActive(false);
            if (player0) p0 = player0.transform.position;
            if (player1) p1 = player1.transform.position;
            if (player2) p2 = player2.transform.position;
            if (player3) p3 = player3.transform.position;
            if (player4) p4 = player4.transform.position;


            CalcTarget();

            transform.position = FindMiddle(transform.position, FindMiddle(target, transform.position));

            float zoom = CalcZoom();
            if (zoom > 700) zoom = 700;
            transform.position = new Vector3(transform.position.x, transform.position.y, -zoom - 10);
        }else
        {
            endScreen.gameObject.SetActive(true);

            if (!hasEnded)
            {
                hasEnded = true;
                events.SetSelectedGameObject(rematch.gameObject);
            }

            if (player0)
            {
                endScreen.congrats.text = "Congratulations\nMagenta Witch!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }
            else if (player1)
            {
                endScreen.congrats.text = "Congratulations\nBlack Witch!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }
            else if (player2)
            {
                endScreen.congrats.text = "Congratulations\nCyan Witch!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }
            else if (player3)
            {
                endScreen.congrats.text = "Congratulations\nGreen Witch!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }
            else if (player4)
            {
                endScreen.congrats.text = "Congratulations\nYellow Witch!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }else
            {
                endScreen.congrats.text = "Congratulations\nNo One!";
                endScreen.congratsShadow.text = endScreen.congrats.text;
            }


            Vector3 transforming = new Vector3(transform.position.x * .9f, transform.position.y * .9f, transform.position.z);
            transform.position = transforming;

            if(transform.position.z > -700)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + transform.position.z * .05f));
                if (transform.position.z < -700) transform.position = new Vector3(transform.position.x, transform.position.y, -700);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void CalcTarget()
    {
        bool canp1 = (player1) ? true : false;
        bool canp2 = (player2) ? true : false;
        bool canp3 = (player3) ? true : false;
        bool canp4 = (player4) ? true : false;
        if (!player1)
        {
            if (canp2)
            {
                canp2 = SetEqual(out p1, p2);
            }
            else if (canp3)
            {
                canp3 = SetEqual(out p1, p3);
            }
            else if (canp4)
            {
                canp4 = SetEqual(out p1, p4);
            }
        }
        if (!player2)
        {
            if (canp1)
            {
                canp1 = SetEqual(out p2, p1);
            }
            else if (canp3)
            {
                canp3 = SetEqual(out p2, p3);
            }
            else if (canp4)
            {
                canp4 = SetEqual(out p2, p4);
            }
        }
        if (!player3)
        {
            if (canp2)
            {
                canp2 = SetEqual(out p3, p2);
            }
            else if (canp1)
            {
                canp1 = SetEqual(out p3, p1);
            }
            else if (canp4)
            {
                canp4 = SetEqual(out p3, p4);
            }
        }
        if (!player4)
        {
            if (canp2)
            {
                canp2 = SetEqual(out p4, p2);
            }
            else if (canp3)
            {
                canp3 = SetEqual(out p4, p3);
            }
            else if (canp1)
            {
                canp1 = SetEqual(out p4, p1);
            }
        }

        Vector3 targetA = (p1 + p2) / 2;
        Vector3 targetB = (p3 + p4) / 2;

        target = (targetA + targetB)/2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    bool SetEqual(out Vector3 a, Vector3 b)
    {
        a = new Vector3();
        a = b;
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    Vector3 FindMiddle(Vector3 a, Vector3 b)
    {
        Vector3 result = (a + b) / 2;
        
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    float CalcZoom()
    {
        Vector3 pos0 = new Vector3();
        Vector3 pos1 = new Vector3();
        Vector3 pos2 = new Vector3();
        Vector3 pos3 = new Vector3();
        Vector3 pos4 = new Vector3();
        if (player0) pos0 = new Vector3(p0.x, p0.y * 1.7778f);
        if (player1) pos1 = new Vector3(p1.x, p1.y * 1.7778f);
        if (player2) pos2 = new Vector3(p2.x, p2.y * 1.7778f);
        if (player3) pos3 = new Vector3(p3.x, p3.y * 1.7778f);
        if (player4) pos4 = new Vector3(p4.x, p4.y * 1.7778f);

        float dist = 0;

        /*if (pos0.sqrMagnitude != 0)
        {
            if (pos1.sqrMagnitude != 0 && dist < Vector3.Distance(pos0, pos1)) dist = Vector3.Distance(pos0, pos1);
            if (pos2.sqrMagnitude != 0 && dist < Vector3.Distance(pos0, pos2)) dist = Vector3.Distance(pos0, pos2);
            if (pos3.sqrMagnitude != 0 && dist < Vector3.Distance(pos0, pos3)) dist = Vector3.Distance(pos0, pos3);
            if (pos4.sqrMagnitude != 0 && dist < Vector3.Distance(pos0, pos4)) dist = Vector3.Distance(pos0, pos4);
        }*/
        if (pos1.sqrMagnitude != 0)
        {
            if (pos0.sqrMagnitude != 0 && dist < Vector3.Distance(pos1, pos0)) dist = Vector3.Distance(pos1, pos0);
            if (pos2.sqrMagnitude != 0 && dist < Vector3.Distance(pos1, pos2)) dist = Vector3.Distance(pos1, pos2);
            if (pos3.sqrMagnitude != 0 && dist < Vector3.Distance(pos1, pos3)) dist = Vector3.Distance(pos1, pos3);
            if (pos4.sqrMagnitude != 0 && dist < Vector3.Distance(pos1, pos4)) dist = Vector3.Distance(pos1, pos4);
        }
        if (pos2.sqrMagnitude != 0)
        {
            if (pos0.sqrMagnitude != 0 && dist < Vector3.Distance(pos2, pos0)) dist = Vector3.Distance(pos2, pos0);
            if (pos1.sqrMagnitude != 0 && dist < Vector3.Distance(pos2, pos1)) dist = Vector3.Distance(pos2, pos1);
            if (pos3.sqrMagnitude != 0 && dist < Vector3.Distance(pos2, pos3)) dist = Vector3.Distance(pos2, pos3);
            if (pos4.sqrMagnitude != 0 && dist < Vector3.Distance(pos2, pos4)) dist = Vector3.Distance(pos2, pos4);
        }
        if (pos3.sqrMagnitude != 0)
        {
            if (pos0.sqrMagnitude != 0 && dist < Vector3.Distance(pos3, pos0)) dist = Vector3.Distance(pos3, pos0);
            if (pos1.sqrMagnitude != 0 && dist < Vector3.Distance(pos3, pos1)) dist = Vector3.Distance(pos3, pos1);
            if (pos2.sqrMagnitude != 0 && dist < Vector3.Distance(pos3, pos2)) dist = Vector3.Distance(pos3, pos2);
            if (pos4.sqrMagnitude != 0 && dist < Vector3.Distance(pos3, pos4)) dist = Vector3.Distance(pos3, pos4);
        }
        if (pos4.sqrMagnitude != 0)
        {
            if (pos0.sqrMagnitude != 0 && dist < Vector3.Distance(pos4, pos0)) dist = Vector3.Distance(pos4, pos0);
            if (pos1.sqrMagnitude != 0 && dist < Vector3.Distance(pos4, pos1)) dist = Vector3.Distance(pos4, pos1);
            if (pos2.sqrMagnitude != 0 && dist < Vector3.Distance(pos4, pos2)) dist = Vector3.Distance(pos4, pos2);
            if (pos3.sqrMagnitude != 0 && dist < Vector3.Distance(pos4, pos3)) dist = Vector3.Distance(pos4, pos3);
        }
        
        return dist;
    }
}

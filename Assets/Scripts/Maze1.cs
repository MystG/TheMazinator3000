using UnityEngine;
using System.Collections;

/// <summary>
/// If the player is touching Maze1 (the maze they start on; the maze at -50 y position), then broadcast the defineGravity function as false.
/// </summary>

public class Maze1 : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        PlayerMovement p = c.gameObject.GetComponent<PlayerMovement>();
        if (p != null)
        {
            p.currentMaze("maze1");
        }
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public float turnSpeed = 100f;                          //the turn speed for the player
    public float speedToMoveAt = 3f;                        //self explanatory
    public float gravity = -10f;                             //the gravity of the situation

    float rotation;                                         
    float zdirection;                                       //forward (1f) or backward (-1f)?
    float xdirection;                                       //direction we're turning in. left = -1f; right = 1f;
    float ydirection;


    bool gravityUp = false;                                 //Maze1 = gravityDown != gravityUp. Maze2 = gravityUp 
    bool maze1 = true;                                      //are we on the maze we started on or not?
    bool maze2 = false;                                     //are we on the second maze?
    bool jumping = false;                                   //are we jumping now?
    bool canRotate = false;                                 //can I as a rigidbody rotate?

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

        ////////////////////////////////////////////
        // MOVEMENT
        ////////////////////////////////////////////

        //z movement aka Forward-Backward movement. W and S are the keys
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0f)
        {
            zdirection = 1f;
        }
        else if (CrossPlatformInputManager.GetAxis("Vertical") < 0f)
        {
            zdirection = -1f;
        }
        else { zdirection = 0f; }

        //x movement aka Left-Right movement. A and D are the keys
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0f)
        {
            xdirection = 1f;
        }
        else if (CrossPlatformInputManager.GetAxis("Horizontal") < 0f)
        {
            xdirection = -1f;
        }
        else { xdirection = 0f; }


        /////////////////////////////////////////
        // ROTATION. it works.
        /////////////////////////////////////////
        if (Input.GetKey("q"))
        {
            //if we are pressing the q key, rotation is to the right
            rotation = 1f;
        }
        else if (Input.GetKey("e"))
        {
            //if we are pressing the e key, rotation is to the left
            rotation = -1f;
        }
        //otherwise, don't rotate
        else { rotation = 0f; }


        //This pushes the player in the negative y direction until gravity is reversed.
        if (!gravityUp)     //if we are not on Maze2, the gravity is down.
        {
            ydirection = 1f;
        }
        else if (gravityUp) //otherwise, gravity is upward
        {
            ydirection = -1f;
        }

        //we move the rigidbody which in turn moves the object
        if (!jumping)
        {   //if we are not jumping, then allow movement in the x and z directions
            rb.transform.Translate(xdirection * Time.fixedDeltaTime * speedToMoveAt, 0.0f, 0.0f, Space.Self);    //x
            rb.transform.Translate(0.0f, 0.0f, zdirection * Time.fixedDeltaTime * speedToMoveAt, Space.Self);    //z
        }
        //if we are jumping/at any moment, rotation and gravity are allowed
        rb.transform.Rotate(0.0f, rotation * -turnSpeed * Time.fixedDeltaTime, 0.0f);
        rb.transform.Translate(0.0f, ydirection * Time.fixedDeltaTime * gravity, 0.0f, Space.World);          //y



        //////////////////////////////////////////
        // CHANGE IN GRAVITY. triggered by the jump key (space)
        //////////////////////////////////////////
        if (Input.GetKeyDown("f")) 
        {   //press f to change mazes
            if (maze1)
            {   //if we are on maze1, change gravity to be upward
                //we are also no longer on maze1 so that's false
                //we are now jumping so jumping = true;
                gravityUp = true;
                maze1 = false;
                jumping = true;
            }
            else if (maze2)
            {   //if we are maze2, change gravity to be downward
                //we are no longer on maze2, so set maze2 to false
                //we are now jumping
                gravityUp = false;
                maze2 = false;
                jumping = true;
            }
            //when we are jumping, we can rotate
            canRotate = true;
        }

        if (rb.transform.position.y >=-10f && rb.transform.position.y <= 10f && canRotate)
        {   //if we are in a certain range when traveling to the other maze
            //and if we can rotate
            //rotate so that we're right side up on the opposite maze
            //we can no longer rotate
            rb.transform.Rotate(180f, 180f, 0.0f);
            canRotate = false;
        }
    }


    public void currentMaze(string maze)
    {
        /// <summary>
        /// The mazes access this.If we touch one of the mazes, the maze lets us know. 
        /// We are no longer jumping, either.
        /// </summary>
        if (maze == "maze1")
        {
            maze1 = true;
            maze2 = false;          //just in case
            jumping = false;
        }
        else if (maze == "maze2")
        {
            maze2 = true;
            maze1 = false;
            jumping = false;
        }
    }
}

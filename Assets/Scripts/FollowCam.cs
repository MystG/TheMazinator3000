using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    /// <summary>
    ///         This script goes on the camera rig. A camera is the child of the camera rig.
    ///    A camera rig is used for when you want to make a camera follow a player/target with better stuff than Unity defaults.
    ///    Think of it as a camera on a tripod that is attached to a target. The tripod is free to follow the target,
    ///        while the camera, being a child, follows the rig wherever it goes. This allows for better, simpler 
    ///        movement and more versatility in the camera scripting (I believe). 
    ///    A camera rig is an empty object you can create in the hierarchy.
    ///
    ///    This is the movement script for the camera rig. It allows for ease-in and ease-out rotation and transforming
    /// </summary>

    public Transform target;            //so we can track the position of our target
    public float moveSpeed = 25f;        //the speed at which the camera rig moves to catch up to the moving/moved target
    public float turnSpeed = 3f;        //the speed at which the camera rig moves to catch up to the rotating/rotated target

    Camera cm;
	
	// Update is called once per frame
	void Update () {
        //transform.position = target.position;       // the camera follows the position of the object
        //we're not doing that because we wanna lerp aka interpolate
        // basically, with the following code we can create an ease in, ease out sort of motion
        transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);

        //transform.rotation = target.rotation;
        //you can slerp between rotations. expensive but accurate
        // we create an ease in, ease out sort of motion with the following code
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, turnSpeed * Time.deltaTime);
        
    }
}

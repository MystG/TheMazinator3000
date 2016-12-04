using UnityEngine;
using System.Collections;

public class maze1items : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        PlayerMovement p = c.gameObject.GetComponent<PlayerMovement>();
        if (p != null)
        {
            p.currentMaze("maze2");
        }
    }
}

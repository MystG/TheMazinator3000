using UnityEngine;
using System.Collections;

public class M2_Items : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        PlayerMovement p = c.gameObject.GetComponent<PlayerMovement>();
        PlayerStats s = c.gameObject.GetComponent<PlayerStats>();
        if (s != null)
        {
            s.IncreaseCounter(2);
        }
        if (p != null)
        {
            Destroy(gameObject);
        }

    }
}

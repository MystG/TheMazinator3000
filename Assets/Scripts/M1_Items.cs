using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M1_Items : MonoBehaviour {


    void OnCollisionEnter(Collision c)
    {
        PlayerMovement p = c.gameObject.GetComponent<PlayerMovement>();
        PlayerStats s = c.gameObject.GetComponent<PlayerStats>();
        if (s != null)
        {
            s.IncreaseCounter(1);
        }
        if (p != null)
        {
            Destroy(gameObject);
        }

    }
}

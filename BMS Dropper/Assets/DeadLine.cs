using UnityEngine;
using System.Collections;

public class DeadLine : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class bar : MonoBehaviour {

    public Object flare;
    void Start()
    {
        flare = Resources.Load("Flares/FlareCore-Autumn");
        //flare
    }
    void OnCollisionEnter(Collision collision)
    {
        Object newFlare = Instantiate(flare, collision.transform.position, Quaternion.identity);
        //newFlare.Play();
        Destroy(newFlare, 0.3f);
    }
}

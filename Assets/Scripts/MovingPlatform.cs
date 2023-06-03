using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject collider=col.gameObject;
        if (collider.CompareTag("Player"))
        {
            collider.transform.SetParent(gameObject.transform);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        GameObject collider=col.gameObject;
        if (collider.CompareTag("Player"))
        {
            collider.transform.SetParent(null);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] Mechanism target;
    [SerializeField] int polarity;
    [SerializeField] bool active;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(active && col.gameObject.GetComponent<PlayerMovement>().polarity==polarity)
            {
                active=false;
                target.Deactivate();
            }
            else if(!active && col.gameObject.GetComponent<PlayerMovement>().polarity!=polarity)
            {
                active=true;
                target.Activate();
            }
        }
    }
}

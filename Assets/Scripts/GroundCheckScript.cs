using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    void Start()
    {
        player=gameObject.GetComponentInParent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.CompareTag("Ground"))
        {
            
            player.GroundedSwitch(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            player.GroundedSwitch(false);
        }
    }
}

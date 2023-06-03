using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MagnetField : MonoBehaviour
{
    
    [SerializeField] int polarity;
    Vector2 change;
    [SerializeField] float intensity;
    // Start is called before the first frame update
   

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.CompareTag("Player"))
        {
            
            
            PlayerMovement con=col.gameObject.GetComponent<PlayerMovement>();
            
            if (con.polarity==polarity)
            {
                change=(col.gameObject.transform.position-gameObject.transform.position).normalized*intensity;
                con.ChangeVelocityModifier(change);
                
            }
            else
            {
                change=(gameObject.transform.position-col.gameObject.transform.position).normalized*intensity;
                con.ChangeVelocityModifier(change);
            }
            
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            
            
            col.gameObject.GetComponent<PlayerMovement>().ChangeVelocityModifier(Vector2.zero);
            
        }

        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            
            
            PlayerMovement con=col.gameObject.GetComponent<PlayerMovement>();
            
            if (con.polarity==polarity)
            {
                change=(col.gameObject.transform.position-gameObject.transform.position).normalized*intensity;
                con.ChangeVelocityModifier(change);
                
            }
            else
            {
                change=(gameObject.transform.position-col.gameObject.transform.position).normalized*intensity;
                con.ChangeVelocityModifier(change);
            }
            ;
            
        }
    }

    

    
}

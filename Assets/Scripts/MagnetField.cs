using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(ParticleSystem))]
public class MagnetField : MonoBehaviour
{
    
    [SerializeField] int polarity;
    Vector2 change;
    [SerializeField] float intensity;
    ParticleSystem ps;
    ParticleSystemRenderer psr;
    GameManager gm;
    float range;
    // Start is called before the first frame update
    void Start()
    {
        //gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        range = gameObject.GetComponent<CircleCollider2D>().radius;
        ps=gameObject.GetComponent<ParticleSystem>();
        psr=gameObject.GetComponent<ParticleSystemRenderer>();
        var particleprop=ps.shape;
        particleprop.enabled=false;
        var main=ps.main;
        main.duration=10;
        main.startSize=range;
        main.maxParticles=1;
        psr.renderMode=ParticleSystemRenderMode.Mesh;
        psr.mesh=Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        if (polarity==-1)
        {
            //psr.material=gm.bluemat;
        }
        else
        {
            //psr.material=gm.redmat;
        }
        psr.sortingLayerName="Field";
        

    }

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

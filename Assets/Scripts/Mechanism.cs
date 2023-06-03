using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour
{
    [SerializeField] bool active=false;
    [SerializeField] bool move;
    
    [SerializeField] Vector2 pos1,pos2;
    [SerializeField] float movespeed;
    Vector2 curpos;
    int posdir=1;
    GameManager GM;
    // Start is called before the first frame update
    
    void Start()
    {
        GM=GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!GM.pause)
        {    
            curpos=new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
            if (active)
            {
                if(curpos==pos2)
                {
                    if (move)
                    {
                        posdir=1;
                    }
                    else
                    {
                        active=false;
                    }
                }
                else if(curpos==pos1)
                {
                    posdir=1;
                }
                
                
                    
                if (posdir==1)
                {
                    transform.position=Vector2.MoveTowards(transform.position,pos2,movespeed*Time.deltaTime);
                }
                else
                {
                    transform.position=Vector2.MoveTowards(transform.position,pos1,movespeed*Time.deltaTime);
                }
            }    
                
            
            
            
        }
    }
    public void Activate()
    {
        active=true;
    }

    public void Deactivate()
    {
        active=false;
    }
}

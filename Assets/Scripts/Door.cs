using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    bool open;
    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        anim=gameObject.GetComponentInChildren<Animator>();
        GM=GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(open && col.gameObject.CompareTag("Player"))
        {
            GM.LevelComplete();
        }
        else if(col.gameObject.CompareTag("Player") && unlocked)
        {
            anim.SetTrigger("Open");
            open=true;
        }
        
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && unlocked)
        {
            anim.SetTrigger("Close");
            open=false;
        }
    }
}

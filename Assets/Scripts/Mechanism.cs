using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour
{
    bool active=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {

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

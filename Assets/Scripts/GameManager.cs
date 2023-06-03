using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Material redmat;
    public Material bluemat;

    void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    
}

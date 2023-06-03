using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Material redmat;
    public Material bluemat;
    int sceneno;
    public int maxsceneno;
    [SerializeField] GameObject mainMenu,pauseMenu,deadMenu,endMenu,nextMenu;
    public bool pause;

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
    void Start()
    {
        maxsceneno=SceneManager.sceneCountInBuildSettings-1;
    }
    public void StartGame()
    {
        Unpause();
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        sceneno=1;
        SceneManager.LoadScene(1);
        
    }
    public void Quit()
    {

        Application.Quit();
    }
    public void MainMenu()
    {
        Unpause();
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        sceneno=0;
        SceneManager.LoadScene(0);
        
    }
    public void NextLevel()
    {
        Unpause();
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        sceneno++;
        SceneManager.LoadScene(sceneno);
    }

    public void Pause()
    {
        
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        Time.timeScale=0;
        pause=true;

    }
    public void Unpause()
    {
        
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        Time.timeScale=1;
        pause=false;
    }

    public void Restart()
    {
        Unpause();
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
        SceneManager.LoadScene(sceneno);
    }
    public void Dead()
    {

        Time.timeScale=0;
        pause=true;
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(true);
        endMenu.SetActive(false);
        nextMenu.SetActive(false);
    }

    public void LevelComplete()
    {
        if (sceneno==maxsceneno)
        {
            GameFinish();
        }
        else
        {
            MoreLevel();
        }
    }

    void GameFinish()
    {
        Time.timeScale=0;
        pause=true;
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(true);
        nextMenu.SetActive(false);
    }

    void MoreLevel()
    {
        Time.timeScale=0;
        pause=true;
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        endMenu.SetActive(false);
        nextMenu.SetActive(true);
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    
}

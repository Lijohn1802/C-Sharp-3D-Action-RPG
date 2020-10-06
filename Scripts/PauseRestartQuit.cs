using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseRestartQuit: MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
       // if(!dialouge.activeInHierarchy)
        //{
            Time.timeScale = 1f;
        //}
        this.gameObject.SetActive(false);
        //Pause.paused=false;
    }
    public void Restart()
    {   Cursor.lockState = CursorLockMode.Locked;   
        //CharacterStats.score=0;
        //Pause.paused = false;
        FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
        //CharacterStats.score = 0;
        //Spawner.enemycount = 0;
        SceneManager.LoadScene("OpenWorld");
        Time.timeScale = 1f;
        //Shooting.maxammo = 75;
        //Shooting.maxammo2 = 99;
        //Shooting.maxammo3 = 3;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().dead = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

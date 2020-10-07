using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void LoadScene()
    {            
        CharacterStats.score=0;
        Pause.paused = false;
        FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
        CharacterStats.score = 0;
        Spawner.enemycount = 0;
        SceneManager.LoadScene(SceneToLoad);
        Time.timeScale = 1f;
        Shooting.maxammo = 75;
        Shooting.maxammo2 = 99;
        Shooting.maxammo3 = 3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().dead = false;
    }
    public void Quite()
    {
        Application.Quit();
    }
}

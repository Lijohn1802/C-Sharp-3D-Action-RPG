using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
   //public int enemynum;
    //public GameObject[] enemyPrefabs;    
    public GameObject[] Level1Enemies;
    public GameObject[] Level2Enemies;
    public GameObject[] Level3Enemies;
    public GameObject[] Level4Enemies;
    public GameObject[] Level5Enemies;
    private GameObject currentenemy;
    //public float spawnInterval;
    /*public float xrangemin;
    public float xrangemax;
    public float yrangemin;
    public float yrangemax;*/
    //public float enemiesLeft;
    //public float maxnumenemies;
    //public int level;
    //public GameObject[] enemies;
    //public int i;
    public void Start()
    {
        InvokeRepeating("Spawn",0.1f,2f);
        //enemies = GameObject.FindGameObjectsWithTag("enemy");
        //enemiesLeft = enemies.Length;
        //int enemynum = level;
        /*for (i = 0; i < maxnumenemies; i++)
        {
            //Vector3 randomLocatione = new Vector3(Random.Range(transform.position.x + xrangemin, transform.position.x + xrangemax), Random.Range(transform.position.y + yrangemin, transform.position.y + yrangemax), 0);
            currentenemy = enemyPrefabs[enemynum];
            Instantiate(currentenemy, this.transform.position, Quaternion.Euler(0, 0, 0));
        }*/
    }
   /* public void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemiesLeft = enemies.Length;
        if (i==8 && enemiesLeft<maxnumenemies)
        {
              //Vector3 randomLocatione = new Vector3(Random.Range(transform.position.x + xrangemin, transform.position.x + xrangemax), Random.Range(transform.position.y + yrangemin, transform.position.y + yrangemax), 0);
              currentenemy = enemyPrefabs[enemynum];
              Instantiate(currentenemy, this.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }*/
    /*public void Spawn1()
    {
        int CurrentLevel1Enemies = Random.Range(0,1);
        Instantiate(Level1Enemies[CurrentLevel1Enemies],this.transform.position, Quaternion.identity);
    }*/
    public static int enemycount;
    //public int CurrentLevel2Enemies;
    public void Spawn()
    {   if(enemycount<maxenemies)
        {
        float x = Random.Range(0,100);
        if(x>=0 && x<50)
        {
            Instantiate(Level1Enemies[Random.Range(0,Level1Enemies.Length)],this.transform.position, Quaternion.identity);
            enemycount++;
        }
        if(x>=50 && x<75  && CharacterStats.score>10)
        {
            Instantiate(Level2Enemies[Random.Range(0,Level2Enemies.Length)],this.transform.position, Quaternion.identity);
            enemycount++;
        }
        if(x>=75 && x<85  && CharacterStats.score>20)
        {
            Instantiate(Level3Enemies[Random.Range(0,Level3Enemies.Length)],this.transform.position, Quaternion.identity);
            enemycount++;
        }
        if(x>=85 && x<95  && CharacterStats.score>30)
        {
            Instantiate(Level4Enemies[Random.Range(0,Level4Enemies.Length)],this.transform.position, Quaternion.identity);
            enemycount++;
        }
        if(x>=95 && x<=100 && CharacterStats.score>40)
        {
            Instantiate(Level5Enemies[Random.Range(0,Level5Enemies.Length)],this.transform.position, Quaternion.identity);
            enemycount++;
        }
        }
    }
    /*
    public void Spawn2()
    {
        Instantiate(Level2Enemies[Random.Range(0,Level2Enemies.Length)],this.transform.position, Quaternion.identity);
        enemycount++;
    }   
    public void Spawn3()
    {
        Instantiate(Level3Enemies[Random.Range(0,Level3Enemies.Length)],this.transform.position, Quaternion.identity);
        enemycount++;
    }    
    public void Spawn4()
    {
        Instantiate(Level4Enemies[Random.Range(0,Level4Enemies.Length)],this.transform.position, Quaternion.identity);
        enemycount++;
    }    
    public void Spawn5()
    {
        Instantiate(Level5Enemies[Random.Range(0,Level5Enemies.Length)],this.transform.position, Quaternion.identity);
        enemycount++;
    }
    */    
    public Text score;
    public float maxenemies=5;
    public GameObject heli; 
    public void Update()
    {        
        score.text = "Wave: " + wavecount.ToString();
        if(enemycount>=maxenemies)
        {
            CancelInvoke();
            if(costarted == false && CharacterStats.score == maxenemies + prevscore)
            {        
                
                StartWaveCountDown();
            StartCoroutine(NextWave());
            }          
        }
        timerem -= Time.deltaTime;
        WaveCD.GetComponent<Text>().text = "Next Wave In: " + Mathf.Round(timerem).ToString();
    }
    /*
    public GameObject[] enemiesLeft;
    public void checkwaveend()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");

    }
    */
    private bool costarted;
    public float prevscore = 0;
    public GameObject dia2;
    public GameObject diaman;
    IEnumerator NextWave()
    {
        costarted = true;
        yield return new WaitForSeconds(15);
        WaveCD.SetActive(false);
        enemycount = 0;
        maxenemies+= 2;
        wavecount+=1;
        InvokeRepeating("Spawn",0.1f,2f);
        costarted = false;
        prevscore = CharacterStats.score;
        dia2.SetActive(true);
        diaman.GetComponent<DialougeManager>().StartCoroutine("PlayText");
        Time.timeScale=0f;
        //dia2.GetComponent<DialougeTrigger>().startdia();
        if(wavecount==8)
        {
            Instantiate(heli, new Vector3(0,-10,-35), Quaternion.Euler(0,90,-90));
            FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("Helicopter");
        }
    }
    public GameObject WaveCD;
    public float timerem;
    public float wavecount=1;
    public void StartWaveCountDown()
    {
        timerem=15f;
        WaveCD.SetActive(true);
    }
}

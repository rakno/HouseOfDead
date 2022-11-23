using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    enum GamePhase { start, checkP1, checkP2, checkP3,shootingCP1, shootingCP2, shootingCP3 }
    GamePhase gp;
    public Transform Panel;
    GameObject zombieBossPrefab;
    float MutantHealth = 100f;
    GameObject zombieGirlsPrefab;
    float GirlHealth = 2f;

    public Camera _mainCamera;
    public AudioSource horrorLoop;
    public AudioSource bulletS;
    public AudioSource mutantDied;
    public AudioSource zombieGirlDied;
    public Transform CheckP1;
    public Transform CheckP2;
    public Transform CheckP3;

    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;

    public GameObject MainPlayer;


    public int numberOfEnemy = 4;
    int enemyCounter;

    float playerSpeed = 5;
    //float playerHealth = 100;


    //  transform.position = Vector3.MoveTowards(transform.position, CheckP1.position, 5*Time.deltaTime);

    void Start()
    {
       // _mainCamera = Camera.main;
        zombieBossPrefab = Resources.Load<GameObject>("Prefabs/Mutant");
        zombieGirlsPrefab = Resources.Load<GameObject>("Prefabs/Zombiegirl");

        enemyCounter = numberOfEnemy;
        gp = GamePhase.start;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (gp)
        {
            case GamePhase.start:
                {
                    Debug.Log("StartPhase");
                   // if (Input.GetKey(KeyCode.KeypadEnter))
                  //  {
                        MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP1.position, playerSpeed * Time.deltaTime);
                        if (MainPlayer.transform.position == CheckP1.position)
                        {
                            gp = GamePhase.checkP1;
                        }
                    //}
                }
                break;
            case GamePhase.checkP1:
                {
                    Debug.Log("CHeckP1");

                    CheckPoint1();
                    gp = GamePhase.shootingCP1;


                }
                break;
            case GamePhase.checkP2:
                {

                    Debug.Log("CHeckP2");
                    CheckPoint2();
                    gp = GamePhase.shootingCP2;

                
                }
                break;
            case GamePhase.checkP3:
                {
                    Debug.Log("CHeckP3");
                    CheckPoint3();
                    gp = GamePhase.shootingCP3;
              
                }
                break;
            case GamePhase.shootingCP1:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        bulletS.Play();
                        Shooting();
                    }
                    if(numberOfEnemy<=0)
                    {
                        gp = GamePhase.checkP2;
                    }
                }
                break; case GamePhase.shootingCP2:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        bulletS.Play();
                        Shooting();
                    }
                    if(numberOfEnemy <= 0)
                    {
                        
                        gp = GamePhase.checkP3;
                    }
                }
                break; case GamePhase.shootingCP3:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        bulletS.Play();
                        Shooting();
                    }
                    if(numberOfEnemy <= 0)
                    {
                        Debug.Log("win");
                    }
                }
                break;


        }



    }


   
    public void SpawnEnemy(Transform SpawnName)
    {
        
        GameObject zombieBoss = GameObject.Instantiate(zombieBossPrefab);
        zombieBoss.transform.position = SpawnName.position;
        for (int i = 0; i < numberOfEnemy; i++)
        {

            GameObject zombieGirls = GameObject.Instantiate(zombieGirlsPrefab);
            
            zombieGirls.transform.position = SpawnName.position;


        }
    }

    public void Shooting()
    {
        
        RaycastHit hit;
        
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_mainCamera.transform.position,_mainCamera.transform.forward,out hit))
        {
            if (hit.collider.gameObject.CompareTag("zombieBoss"))
            {
                Debug.Log("MuTantdamage");
                MutantHealth = MutantHealth - 20;
                if (MutantHealth <= 0)
                {
                    GameObject.Destroy(hit.transform.gameObject);
                    mutantDied.Play();

                }
            }
            if (hit.collider.gameObject.CompareTag("zombieGirls"))
            {
               Debug.Log("Girldamage");
              GirlHealth = GirlHealth - 1;
                if (GirlHealth <= 0)
                {
                    GameObject.Destroy(hit.transform.gameObject);
                    zombieGirlDied.Play();
                    numberOfEnemy = numberOfEnemy - 1;
                }
            }

        }
    }

    public void CheckPoint1()
    {
        MainPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        SpawnEnemy(Spawn1);
    }
    public void CheckPoint2()
    {
        this.numberOfEnemy = 4;
        MainPlayer.transform.rotation = Quaternion.Euler(MainPlayer.transform.rotation.x, MainPlayer.transform.rotation.y-90, MainPlayer.transform.rotation.z);
       
       
            MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP2.position, playerSpeed * Time.deltaTime);
        
        MainPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        SpawnEnemy(Spawn2);

    }
    public void CheckPoint3()
    {
        this.numberOfEnemy = 4;
        MainPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
       
        
            MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP2.position, playerSpeed * Time.deltaTime);
        
        MainPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        SpawnEnemy(Spawn3);
    }

 


   
}





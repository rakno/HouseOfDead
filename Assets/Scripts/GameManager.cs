using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    enum GamePhase { start, checkP1, checkP2, checkP3,shootingCP1, shootingCP2, shootingCP3 }
    GamePhase gp;
   
    GameObject zombieBossPrefab;
    float MutantHealth = 100f;
    GameObject zombieGirlsPrefab;
    float GirlHealth = 2f;

    public Camera _mainCamera;

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
        _mainCamera = Camera.main;
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
                    if (Input.GetKey(KeyCode.KeypadEnter))
                    {
                        MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP1.position, playerSpeed * Time.deltaTime);
                        if (MainPlayer.transform.position == CheckP1.position)
                        {
                            gp = GamePhase.checkP1;
                        }
                    }
                }
                break;
            case GamePhase.checkP1:
                {
                    Debug.Log("CHeckP1");

                    CheckPoint1();
                    gp = GamePhase.shootingCP1;
                    //transform.rotation = new (transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
                    //transform.rotation = Quaternion.Euler(0, 90, 0);

                    //SpawnEnemy(Spawn1);
                    //if (Input.GetKey(KeyCode.Mouse0))
                    //{ 
                    //    Shooting();

                    //}

                    //if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    //{
                    //    gp = GamePhase.checkP2;
                    //}
                    //else
                    //{
                    //    Debug.Log("PlayerDied");
                    //    gp = GamePhase.start;
                    //}
                    //if (enemyCounter<=0)
                    //{
                    //    MainPlayer.transform.rotation = Quaternion.RotateTowards(MainPlayer.transform.rotation,
                    //                                              CheckP2.transform.rotation,
                    //                                               playerSpeed * Time.deltaTime);
                    //    gp = GamePhase.checkP2;

                    //}

                }
                break;
            case GamePhase.checkP2:
                {
                    //MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP2.position, playerSpeed * Time.deltaTime);

                    //MainPlayer.transform.rotation = Quaternion.RotateTowards(MainPlayer.transform.rotation,
                    //                                              Spawn2.transform.rotation,
                    //                                               playerSpeed * Time.deltaTime);

                    CheckPoint2();
                    gp = GamePhase.shootingCP2;

                    // SpawnEnemy(Spawn2);
                    //if (Input.GetKey(KeyCode.Mouse0))
                    //{
                    //    // Shooting();

                    //}
                    //if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    //{
                    //    gp = GamePhase.checkP3;
                    //}
                    //else
                    //{
                    //    Debug.Log("PlayerDied");
                    //  //  gp = GamePhase.start;
                    //}

                    //if (enemyCounter <= 0)
                    //{
                    //    MainPlayer.transform.rotation = Quaternion.RotateTowards(MainPlayer.transform.rotation,
                    //                                              CheckP3.transform.rotation,
                    //                                               playerSpeed * Time.deltaTime);
                    //gp = GamePhase.checkP3;
                        

                    //}
                }
                break;
            case GamePhase.checkP3:
                {
                    CheckPoint3();
                    gp = GamePhase.shootingCP3;
                    //MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP3.position, playerSpeed * Time.deltaTime);
                    //MainPlayer.transform.rotation = Quaternion.RotateTowards(MainPlayer.transform.rotation,
                    //                      Spawn3.transform.rotation,
                    //                       playerSpeed * Time.deltaTime);
                    //// SpawnEnemy(Spawn3);
                    //if (Input.GetKey(KeyCode.Mouse0))
                    //{
                    //    // Shooting();

                    //}
                    //if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    //{
                    //    gp = GamePhase.end;
                    //}
                    //else
                    //{
                    //    Debug.Log("PlayerDied");
                    //    //gp = GamePhase.start;
                    //}

                 

                }
                break;
            case GamePhase.shootingCP1:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        Shooting();
                    }
                    if(enemyCounter<=0)
                    {
                        gp = GamePhase.checkP2;
                    }
                }
                break; case GamePhase.shootingCP2:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        Shooting();
                    }
                    if(enemyCounter<=0)
                    {
                        gp = GamePhase.checkP3;
                    }
                }
                break; case GamePhase.shootingCP3:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        Shooting();
                    }
                    if(enemyCounter<=0)
                    {
                        Debug.Log("win");
                    }
                }
                break;


        }



    }


   
    public void SpawnEnemy(Transform SpawnName)
    {
        // enemyCounter = this.numberOfEnemy;
        GameObject zombieBoss = GameObject.Instantiate(zombieBossPrefab);
        zombieBoss.transform.position = SpawnName.position;
        for (int i = 0; i < enemyCounter; i++)
        {

            GameObject zombieGirls = GameObject.Instantiate(zombieGirlsPrefab);
            SpawnName.position = new Vector3(SpawnName.position.x, SpawnName.position.y, SpawnName.position.z + i);
            zombieGirls.transform.position = SpawnName.position;


        }
    }

    public void Shooting()
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("zombieBoss"))
            {
                Debug.Log("damage");
                MutantHealth = MutantHealth - 20;
                if (MutantHealth <= 0)
                {
                    GameObject.Destroy(gameObject);
                    enemyCounter = enemyCounter - 1;
                }
            }
            if (hit.collider.gameObject.CompareTag("zombieGirls"))
            {
                GirlHealth = GirlHealth - 1;
                if (GirlHealth <= 0)
                {
                    GameObject.Destroy(gameObject);
                    numberOfEnemy = numberOfEnemy - 1;
                }
                Debug.Log("damage");
            }

        }
    }

    public void CheckPoint1()
    {
        //  MainPlayer.transform.rotation = Quaternion.RotateTowards(MainPlayer.transform.rotation,
        //  Spawn1.transform.rotation,
        //  playerSpeed * Time.deltaTime);
        //  MainPlayer.transform.rotation = new (MainPlayer.transform.rotation.x, MainPlayer.transform.rotation.y + 90, MainPlayer.transform.rotation.z);
        MainPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        SpawnEnemy(Spawn1);
    }
    public void CheckPoint2()
    {
        MainPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP2.position, playerSpeed * Time.deltaTime);
        MainPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        SpawnEnemy(Spawn2);

    }
    public void CheckPoint3()
    {
        MainPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        MainPlayer.transform.position = Vector3.MoveTowards(MainPlayer.transform.position, CheckP2.position, playerSpeed * Time.deltaTime);
        MainPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        SpawnEnemy(Spawn3);
    }

 


   
}





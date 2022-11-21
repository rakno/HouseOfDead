using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    enum GamePhase { start, checkP1, checkP2, checkP3, end }
    GamePhase gp;
    Rigidbody rb;
    GameObject DancingZom;
    GameObject NormalZom;

    public Transform CheckP1;
    public Transform CheckP2;
    public Transform CheckP3;

    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;

    public int numberOfEnemy = 2;

    float playerSpeed = 5;
    float playerHealth = 10;
    float bulletSpeed = 100;
    //  transform.position = Vector3.MoveTowards(transform.position, CheckP1.position, 5*Time.deltaTime);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DancingZom = Resources.Load<GameObject>("Prefabs/Mutant");
        NormalZom = Resources.Load<GameObject>("Prefabs/Zombiegirl");
        gp = GamePhase.start;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (gp)
        {
            case GamePhase.start:
                {
                    if (Input.GetKey(KeyCode.KeypadEnter))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, CheckP1.position, playerSpeed * Time.deltaTime);
                        if (transform.position == CheckP1.position)
                        {
                            gp = GamePhase.checkP1;
                        }
                    }
                }
                break;
            case GamePhase.checkP1:
                {

                    SpawnEnemy();
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        // Shooting();

                    }
                    if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    {
                        gp = GamePhase.checkP2;
                    }
                    else
                    {
                        Debug.Log("PlayerDied");
                        gp = GamePhase.start;
                    }
                }
                break;
            case GamePhase.checkP2:
                {
                    transform.position = Vector3.MoveTowards(transform.position, CheckP2.position, playerSpeed * Time.deltaTime);

                    SpawnEnemy();
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        // Shooting();

                    }
                    if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    {
                        gp = GamePhase.checkP3;
                    }
                    else
                    {
                        Debug.Log("PlayerDied");
                        gp = GamePhase.start;
                    }

                }
                break;
            case GamePhase.checkP3:
                {
                    transform.position = Vector3.MoveTowards(transform.position, CheckP3.position, playerSpeed * Time.deltaTime);

                    SpawnEnemy();
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        // Shooting();

                    }
                    if (!(playerHealth <= 0) && numberOfEnemy <= 0)
                    {
                        gp = GamePhase.end;
                    }
                    else
                    {
                        Debug.Log("PlayerDied");
                        gp = GamePhase.start;
                    }
                }
                break;
            case GamePhase.end:
                {
                    Debug.Log("Win");
                }
                break;
        }



    }

    public void SpawnEnemy()
    {
        GameObject zombieBoss = GameObject.Instantiate(DancingZom);
        zombieBoss.transform.position = Spawn1.position;
        for (int i = 0; i < numberOfEnemy; i++)
        {

            GameObject zombieGirls = GameObject.Instantiate(NormalZom);
            zombieGirls.transform.position = Spawn1.position;

        }
    }


    public void Shooting()
    {




    }

}

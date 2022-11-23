using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameLoader : MonoBehaviour
{

    public void onClickStart()
    {

        SceneManager.LoadScene("SampleScene");

    }
}

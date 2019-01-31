using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour {


    void Update()
    {
        if (Game.isInit)
            SceneManager.LoadScene("1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    public static bool isInit = false;
    public static Settings settings;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        isInit = false;
        settings = Settings.GetSettings();
        isInit = true;
    }
    void Start()
    {
        Debug.Log(settings.Localization);
    }
  
}

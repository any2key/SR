using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using API;

public class Game : MonoBehaviour
{
    public static bool isInit = false;
    public static Settings settings;
    public static Localization localization;
    public static GameState gameState;

    public static string Folder;
    public static int LogKeepDays;
    public static int LogLevel;
    public static string LogFolder;

    void Awake()
    {
        Folder = GetComponent<Properties>().Folder;
        LogKeepDays = GetComponent<Properties>().LogKeepDays;
        LogLevel = GetComponent<Properties>().LogLevel;
        LogFolder = GetComponent<Properties>().LogFolder;

        API.Logger.Log(API.LogLevel.Debug, "Начало Awake() в Game");
        DontDestroyOnLoad(gameObject);
        isInit = false;
        API.Logger.Log(API.LogLevel.Debug, "Пытаюсь проинициализировать настройки");
        settings = Settings.GetSettings();
        API.Logger.Log(API.LogLevel.Debug, "Настройки проинициализированы: " + settings.ToXML());
        API.Logger.Log(API.LogLevel.Debug, "Пытаюсь проинициализировать локализацию");
        localization = Localization.GetLocalization();
        API.Logger.Log(API.LogLevel.Debug, "Локализация проинициализирована: " + localization.ToXML());
        API.Logger.Log(API.LogLevel.Debug, "Пытаюсь проинициализировать состояние игры");
        gameState = GameState.GetState();
        API.Logger.Log(API.LogLevel.Debug, "Состояние игры проинициализировано: " + gameState.ToXML());
        isInit = true;
    }
    void Start()
    {
    }

}
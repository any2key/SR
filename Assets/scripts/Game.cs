using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Any2key.Game.Api;
using UnityEngine.EventSystems;
using System;

public class Game : MonoBehaviour
{
    public static bool isInit = false;
    public static Settings settings;
    public static Localization localization;
    public static GameState gameState;
    void Awake()
    {
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Начало Awake() в Game");
        DontDestroyOnLoad(gameObject);
        isInit = false;
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Пытаюсь проинициализировать настройки");
        settings = Settings.GetSettings();
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Настройки проинициализированы: " + settings.ToXML());
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Пытаюсь проинициализировать локализацию");
        localization = Localization.GetLocalization();
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Локализация проинициализирована: " + localization.ToXML());
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Пытаюсь проинициализировать состояние игры");
        gameState = GameState.GetState();
        Any2key.Game.Api.Logger.Log(LogLevel.Debug, "Состояние игры проинициализировано: " + gameState.ToXML());
        isInit = true;
    }
    void Start()
    {
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Any2key.Game.Api;

public class GameState  {
    private static string path = Path.Combine(IO._directoryPath, "gs.bp");
    private static GameState instance;
    private List<Profile> _profiles;

    public static GameState GetSettings()
    {
        if (instance == null)
        {
            instance = new GameState();
            IO.GetInstance(ref instance, path);
            return instance;
        }
        return instance;
    }

    public GameState()
    {
        _profiles = new List<Profile>();
    }
}

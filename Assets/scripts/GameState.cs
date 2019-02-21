using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Any2key.Game.Api;
using System.IO;
using System.Linq;
using System;
using API;

public class GameState
{
    private static string path = Path.Combine(IO._directoryPath, "gs.bp");
    private static GameState instance;
    private List<Profile> _profiles;

    public delegate void GameStateChangedHandler();
    public event GameStateChangedHandler GameStateChanged;


    public GameState()
    {
        _profiles = new List<Profile>();
        GameStateChanged += Write;
       // Profile.ProfileStateChanged += Write;
    }


    public static GameState GetState()
    {
        if (instance == null)
        {
            instance = new GameState();
            IO.GetInstance(ref instance, path);
            return instance;
        }
        return instance;
    }

    public List<Profile> Profiles
    {
        get { return _profiles; }
        set { _profiles = value; }
    }

    public void AddProfile(Profile profile)
    {
        if (_profiles.Count < 3)
        {
            _profiles.Add(profile);
            GameStateChanged();
        }

    }

    public void RemoveProfile(Guid guid)
    {
        _profiles.RemoveAll(g => g.Guid == guid);

        GameStateChanged();
    }


    private void Write()
    {
        if (GameStateChanged != null)
            IO.WriteFile(path, GetState().ToXML());
    }
}

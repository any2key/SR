using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Any2key.Game.Api;

public class Save  {
    private static string path = Path.Combine(IO._directoryPath, "ss.bp");

    private static Save instance;

    private List<Profile> _profiles;

    public Save()
    {

    }


    public static Save GetSettings()
    {
        if (instance == null)
        {
            instance = new Save();
            IO.GetInstance(ref instance, path);
            return instance;
        }
        return instance;
    }

}

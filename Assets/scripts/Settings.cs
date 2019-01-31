using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Any2key.Game.Api;
using System.IO;

public class Settings
{
    private static string path = Path.Combine(IO._directoryPath, "s.bp");
    private static Settings instance;
    private string _localization;
    public delegate void SettingsChangedHandler();
    public  event SettingsChangedHandler SettingsChanged;

    public Settings()
    {
        _localization = "ctor  Value";
        SettingsChanged += Write;
    }

    public static Settings GetSettings()
    {
        if (instance == null)
        {
            instance = new Settings();
            IO.GetInstance(ref instance, path);
            //if (instance == null)
            //{
            //    return new Settings();
            //}
            return instance;
        }
        return instance;
    }

    public string Localization
    {
        get { return _localization; }
        set
        {
            _localization = value;
            if (SettingsChanged != null)
                SettingsChanged();
        }
    }


    private void Write()
    {
        if (SettingsChanged != null)
            IO.WriteFile(path, instance.ToXML());
    }
}

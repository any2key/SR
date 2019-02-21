using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Any2key.Game.Api;
using System.IO;
using API;

public class Settings
{
    private static string path = Path.Combine(IO._directoryPath, "s.bp");

    private static Settings instance;

    private string _localization;
    private GraphicSetttings _quality;
    private AudioSetttings _audio;
    private InputSettings _input;


    public delegate void SettingsChangedHandler();
    public event SettingsChangedHandler SettingsChanged;

    public Settings()
    {
        _localization = "ru-RU";
        _quality = new GraphicSetttings()
        {
            AnisotropicFiltering = AnisotropicFiltering.Enable,
            AntiAliasing = 8,
            QLevel = QualityLevel.Fantastic,
            Resolution = new Resolution() { height = Screen.height, width = Screen.width },
            ShadowQuality = ShadowQuality.All,
            ShadowResolution = ShadowResolution.VeryHigh,
            TextRes = 0,
            vSync = 1
        };
        _audio = new AudioSetttings()
        {
            Music=50,
            Sound=50
        };
        _input = new InputSettings();
        SettingsChanged += Write;
    }

    public static Settings GetSettings()
    {
        if (instance == null)
        {
            instance = new Settings();
            IO.GetInstance(ref instance, path);
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

    public GraphicSetttings Quality
    {
        get { return _quality; }
        set
        {
            _quality = value;
            if (SettingsChanged != null)
                SettingsChanged();
        }
    }

    public AudioSetttings Audio
    {
        get { return _audio; }
        set
        {
            _audio = value;
            if (SettingsChanged != null)
                SettingsChanged();
        }
    }

    public InputSettings Input
    {
        get { return _input; }
        set
        {
            _input = value;
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

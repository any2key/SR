using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Any2key.Game.Api;
using System.Linq;
using System.IO;
using API;

public class Localization {
   // private string path = Path.Combine(IO._directoryPath, @"Files\Localization\Reflection\" + Game.settings.Localization + ".xml");
    private List<Dictionary> dictionary;
    private static Localization instance;
    public Localization()
    {
        string cryptValue = Resources.Load<TextAsset>(Game.settings.Localization).text;
        if(string.IsNullOrEmpty(cryptValue))
            cryptValue = Resources.Load<TextAsset>("en-EN").text;

        string xmlValue = Crypto.DecryptStringAES(cryptValue, "Let the force be with you");
        dictionary = IO.FromXml<List<Dictionary>>(xmlValue);
        Game.settings.SettingsChanged += SetLocalization;
    }

    public string this[string key]
    {
        get
        {
            return string.IsNullOrEmpty(dictionary.FirstOrDefault(e => e.key == key).value) ? "Undefined": dictionary.FirstOrDefault(e => e.key == key).value;
        }
    }

    public static Localization GetLocalization()
    {
        if (instance == null)
        {
           instance= new Localization();
        }
        return instance;
    }

    void SetLocalization()
    {
        string cryptValue = Resources.Load<TextAsset>(Game.settings.Localization).text;
        if (string.IsNullOrEmpty(cryptValue))
            cryptValue = Resources.Load<TextAsset>("en-EN").text;

        string xmlValue = Crypto.DecryptStringAES(cryptValue, "Let the force be with you");
        dictionary = IO.FromXml<List<Dictionary>>(xmlValue);
    }
}

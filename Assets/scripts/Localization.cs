using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Any2key.Game.Api;
using System.Linq;
using System.IO;

public class Localization  {
    private string path = Path.Combine(IO._directoryPath, @"Files\Localization\Reflection\"+Game.settings.Localization+".xml");
    private List<Dictionary> dictionary;
    public string  this[string key]
    {
        get
        { 
           return string.IsNullOrEmpty(dictionary.FirstOrDefault(e => e.key == key).value)? dictionary.FirstOrDefault(e => e.key == key).value:"Undefined";
        }
    }

    public Localization()
    {

    }
}

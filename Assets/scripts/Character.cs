using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    
    private string _prefabName, _name, _descriptionKey;
    
    public Skills _minSkills;

    public delegate void CharacterStateChangedHandler();
    public event CharacterStateChangedHandler CharacterStateChanged;

    public Character()
    {
        _prefabName = "default_prefab";
        _name = "Default character";
        _descriptionKey = "default_char_description";
        _minSkills = new Skills();

        CharacterStateChanged += DoSomething;

    }

    public string PrefabName
    {
        get { return _prefabName; }
        set
        {
            _prefabName = value;
            if (CharacterStateChanged != null)
                CharacterStateChanged();
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            if (CharacterStateChanged != null)
                CharacterStateChanged();
        }
    }

    public string DescriptionKey
    {
        get { return _descriptionKey; }
        set
        {
            _descriptionKey = value;
            if (CharacterStateChanged != null)
                CharacterStateChanged();
        }
    }

    public void DoSomething() { }

}
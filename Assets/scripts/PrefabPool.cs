using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrefabPool : MonoBehaviour {
    [SerializeField]
    private List<CharacterObject> _availableCharacters;
    public static List<CharacterObject> AvailableCharacters;

    void Start()
    {
        AvailableCharacters = _availableCharacters;
    }
    public CharacterObject this[string key]
    {
        get
        {
            return _availableCharacters.FirstOrDefault(e => e._name == key);
        }
    }
}

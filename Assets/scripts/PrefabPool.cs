using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrefabPool : MonoBehaviour
{
    [SerializeField]
    private List<CharacterObject> _availableCharacters;
    public static List<CharacterObject> AvailableCharacters;

    void Start()
    {
        AvailableCharacters = _availableCharacters;
    }


    public static CharacterObject GetCharacter(string prefabName)
    {
        return AvailableCharacters.FirstOrDefault(e => e.prefabName == prefabName);
    }
}

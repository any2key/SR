using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : MonoBehaviour {
    public Character character = new Character();

    public GameObject prefab;
    public string prefabName, _name, _descriptionKey;
    public int _armor, _weapon, _rof, _commerce, _speed;


    void Awake()
    {
        character.Name = _name;
        character.DescriptionKey = _descriptionKey;
        character.PrefabName = prefabName;
        character._minSkills = new Skills()
        {
            Armor=_armor,
            Commerce=_commerce,
            Rof=_rof,
            Speed=_speed,
            Weapon=_weapon
        };
    }
}

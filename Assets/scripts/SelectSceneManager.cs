using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneManager : MonoBehaviour
{

    public List<Profile> Profiles;

    void Awake()
    {
        Profiles = Game.gameState.Profiles;
        //Game.gameState.AddProfile(new Profile()
        //{
        //    Character = new Character()
        //    {
        //        DescriptionKey = "My New Description",
        //        Name = "My New Name",
        //        Prefab = "My New Prefab"
        //    },
        //    NickName = "My New NickName",
        //    Skills = new Skills()
        //    {
        //        Armor = 5,
        //        Commerce = 5,
        //        Rof = 5,
        //        Speed = 5,
        //        Weapon = 5
        //    }
        //});

        foreach (var item in Profiles)
        {
            Game.gameState.RemoveProfile(item.Guid);
        }
    }
}

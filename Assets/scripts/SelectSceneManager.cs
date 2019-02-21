using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectSceneManager : MonoBehaviour
{
    private int counter = 0;
    public Transform spawn;
    public Text profilesCount;
    public List<Profile> ProfilesToShow = new List<Profile>();
    public GameObject prefab;

    public Text Description;

    public static Profile CurrentProfile;

    void Awake()
    {
        Game.gameState.GameStateChanged += GameStateChange;
        Game.gameState.GameStateChanged += SetProfilesToShow;
    }

    void Start()
    {
        SetProfilesToShow();
        profilesCount.text = "Profiles: " + Game.gameState.Profiles.Count + "/3";
        InstantiatePrefab();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Game.gameState.AddProfile(new Profile() { Character = PrefabPool.GetCharacter("Englishman_Tony").character });
            Game.gameState.AddProfile(new Profile() { Character = PrefabPool.GetCharacter("Redneck").character });
            Game.gameState.AddProfile(new Profile() { Character = PrefabPool.GetCharacter("Redneck_tutorial").character });
            //InstantiatePrefab();
            counter--;
            if (counter < 0)
                counter = ProfilesToShow.Count - 1;
            CurrentProfile = ProfilesToShow[0];
            InstantiatePrefab();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            counter++;
            if (counter >= ProfilesToShow.Count)
                counter = 0;
            CurrentProfile = ProfilesToShow[counter];
            InstantiatePrefab();
            // Game.gameState.RemoveProfile(Game.gameState.Profiles[0].Guid);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
             Game.gameState.RemoveProfile(CurrentProfile.Guid);
            InstantiatePrefab();
        }
    }

    void GameStateChange()
    {
        profilesCount.text = "Profiles: " + Game.gameState.Profiles.Count + "/3";
    }


    void SetProfilesToShow()
    {
        ProfilesToShow = new List<Profile>();
        if (Game.gameState.Profiles.Count < 3)
        {
            ProfilesToShow.Add(new Profile() { Character = PrefabPool.GetCharacter("Default").character, NickName = "", Skills = new Skills() });
        }
        foreach (var item in Game.gameState.Profiles)
        {
            ProfilesToShow.Add(item);
        }
        CurrentProfile = ProfilesToShow[0];
    }

    void OnDestroy()
    {
        Game.gameState.GameStateChanged -= GameStateChange;
        Game.gameState.GameStateChanged -= SetProfilesToShow;
    }

    void InstantiatePrefab()
    {
        Debug.Log("Instantiate!");
        Destroy(prefab);
        prefab = Instantiate(PrefabPool.GetCharacter(CurrentProfile.Character.PrefabName).prefab, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), spawn.rotation) as GameObject;
        Description.text = CurrentProfile.Character.Name;
    }
}

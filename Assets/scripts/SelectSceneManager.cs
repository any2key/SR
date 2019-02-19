using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SelectSceneManager : MonoBehaviour
{
    private int counter = 0;
    public Transform spawn;
    private GameObject prefab;
    public Text profilesCount;

    public List<CharacterObject> prefabs;

    void Awake()
    {
        Game.gameState.GameStateChanged += GameStateChange;
    }

    void Start()
    {
        profilesCount.text = "Profiles: " + Game.gameState.Profiles.Count + "/3";
        prefabs = PrefabPool.AvailableCharacters;
        if (Game.gameState.Profiles.Count >= 3)
        {
            prefabs.Remove(prefabs.FirstOrDefault(e => e._name == "Default"));
        }
        foreach (var item in PrefabPool.AvailableCharacters)
        {
            Debug.Log(item.prefabName);
        }

        prefab = Instantiate(prefabs[counter].prefab, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z),spawn.rotation) as GameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Game.gameState.AddProfile(new Profile());

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Game.gameState.Profiles.Count > 0)
                Game.gameState.RemoveProfile(Game.gameState.Profiles[0].Guid);
        }
    }

    void GameStateChange()
    {
        profilesCount.text = "Profiles: " + Game.gameState.Profiles.Count + "/3";
    }

    void SetPrefab()
    {
        
    }
}

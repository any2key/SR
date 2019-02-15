using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPool : MonoBehaviour {

    public List<Character> _prefabs;
    public static List<Character> prefabs;
    void Awake()
    {
        prefabs = _prefabs;
        DontDestroyOnLoad(this.gameObject);
    }

}

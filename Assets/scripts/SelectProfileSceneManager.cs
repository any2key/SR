using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectProfileSceneManager : MonoBehaviour
{

    public Transform spawn;
    public GameObject instanse;
    private int counter = 0;
    void Start()
    {
        InstanePrefab(counter);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            counter--;
            if (counter < 0)
                counter = (PrefabPool.prefabs.Count - 1);
            Debug.Log(counter);
            InstanePrefab(counter);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            counter++;
            if (counter >= PrefabPool.prefabs.Count)
                counter = 0;

            Debug.Log(counter);
            InstanePrefab(counter);
        }
    }


    void InstanePrefab(int index)
    {
        Destroy(instanse);
       instanse= Instantiate(PrefabPool.prefabs[index].prefabObj, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), spawn.rotation);

    }
}

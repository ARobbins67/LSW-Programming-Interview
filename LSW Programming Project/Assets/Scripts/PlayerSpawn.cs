using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    
    private void Awake()
    {
        GameObject PlayerObj = Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            PlayerObj.name = "IndoorPlayer";
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            PlayerObj.name = "OutdoorPlayer";
        }
        PlayerObj.transform.position = gameObject.transform.position;
    }
}

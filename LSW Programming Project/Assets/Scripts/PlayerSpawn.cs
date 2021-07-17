using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;

    void OnLevelWasLoaded(int level)
    {
        GameObject Player = GameObject.Find("Player");
        Player.transform.position = gameObject.transform.position;
    }    
}

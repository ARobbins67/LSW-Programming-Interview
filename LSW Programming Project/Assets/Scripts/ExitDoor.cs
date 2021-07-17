using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private GameObject PlayerObj;
    private SpriteRenderer Hair;
    private SpriteRenderer Chest;
    private SpriteRenderer Legs;

    private void Start()
    {
        PlayerObj = GameObject.FindWithTag("Player");
        Hair = PlayerObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Chest = PlayerObj.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Legs = PlayerObj.transform.GetChild(2).GetComponent<SpriteRenderer>();
        
        AssignClothes();
    }
    
    private void AssignClothes()
    {
        string hairName = PlayerPrefs.GetString("Hair");
        Sprite[] hairSprites = Resources.LoadAll<Sprite>("Spritesheet/roguelikeChar_transparent");
        for (int i = 0; i < hairSprites.Length-1; i++)
        {
            if (hairSprites[i].name == hairName)
            {
                Hair.sprite = hairSprites[i];
            }
        }
        
        string chestName = PlayerPrefs.GetString("Chest");
        Sprite[] chestSprites = Resources.LoadAll<Sprite>("Spritesheet/roguelikeChar_transparent");
        for (int i = 0; i < chestSprites.Length-1; i++)
        {
            if (chestSprites[i].name == chestName)
            {
                Chest.sprite = chestSprites[i];
            }
        }
        
        string legName = PlayerPrefs.GetString("Legs");
        Sprite[] legSprites = Resources.LoadAll<Sprite>("Spritesheet/roguelikeChar_transparent");
        for (int i = 0; i < legSprites.Length-1; i++)
        {
            if (legSprites[i].name == legName)
            {
                Legs.sprite = legSprites[i];
                Debug.Log("Legs: " + Legs.sprite);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // save clothes and gold amount for next scene
        PlayerPrefs.SetString("Hair", Hair.sprite.name);
        PlayerPrefs.SetString("Chest", Chest.sprite.name);
        PlayerPrefs.SetString("Legs", Legs.sprite.name);
        Debug.Log("Legs sprite: " + Legs.sprite.name);
        PlayerPrefs.SetInt("Gold", Gold.GetGold());
        SceneManager.LoadScene("Outside");
    }
}

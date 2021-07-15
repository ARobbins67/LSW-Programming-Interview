using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject DialogueObject;
    [SerializeField] private GameObject PromptText;
    
    private bool bCanEnterMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanEnterMenu && Input.GetKeyDown(KeyCode.E))
        {
            PromptText.SetActive(false);
            DialogueObject.SetActive(true);
            bCanEnterMenu = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PromptText.SetActive(true);
            bCanEnterMenu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PromptText.SetActive(false);
            bCanEnterMenu = false;
        }
    }
}

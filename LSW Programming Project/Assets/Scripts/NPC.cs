using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject DialogueMenu;
    [SerializeField] private GameObject PromptText;
    
    private bool bCanEnterMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (bCanEnterMenu && Input.GetKeyDown(KeyCode.E))
        {
            PromptText.SetActive(false);
            DialogueMenu.SetActive(true);
            bCanEnterMenu = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
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

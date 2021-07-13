using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingComponent : MonoBehaviour
{
    [SerializeField] private int Price;
    [SerializeField] private SpriteRenderer ClothingSprite;
    [SerializeField] private List<Sprite> Options;

    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextItem()
    {
        index++;
        if (index > Options.Count - 1)
            index = 0;

        ClothingSprite.sprite = Options[index];
    }

    public void PreviousItem()
    {
        index--;
        if (index < 0)
            index = Options.Count - 1;

        ClothingSprite.sprite = Options[index];
    }
}

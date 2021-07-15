using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;

public class ClothingComponent : MonoBehaviour
{
    [SerializeField] private int Price;
    [SerializeField] private List<Sprite> Options = new List<Sprite>();

    [Header("References")] 
    [SerializeField] private GameObject UIOutput;
    [SerializeField] private TextMeshProUGUI PriceText;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private SpriteRenderer PlayerRend;
    [SerializeField] private GameObject ItemAlreadyOwned;
    [SerializeField] private GameObject BuyButton;
    [SerializeField] private GameObject SellButton;
    [SerializeField] private GameObject EquipButton;

    private List<Sprite> PlayerInventory = new List<Sprite>();
    private Sprite currentSprite = null;
    private Image UIImage;
    private int index = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        UIImage = UIOutput.transform.GetComponent<Image>();
        PriceText.text = "Price: " + Price.ToString();
        DescriptionText.text = gameObject.name + " " + index.ToString();
        currentSprite = Options[index];
    }

    void Start()
    {
        CheckInventory();
        //PlayerInventory.Add(PlayerRend.sprite);
        UIImage.sprite = currentSprite;
    }

    private void OnEnable()
    {
        // when menu opens, make preview the player's current clothes
        index = Options.IndexOf(PlayerRend.sprite);
        currentSprite = Options[index];
        CheckInventory();
    }

    public void NextItem()
    {
        index++;
        if (index > Options.Count - 1)
            index = 0;

        CheckInventory();
    }
    
    public void PreviousItem()
    {
        index--;
        if (index < 0)
            index = Options.Count - 1;
        
        CheckInventory();
    }

    private void CheckInventory()
    {
        DescriptionText.text = gameObject.name + " " + index.ToString();
        currentSprite = Options[index];
        UIImage.sprite = currentSprite;
        
        // can sell
        if (PlayerInventory.Contains(Options[index]))
        {
            BuyButton.SetActive(false);
            SellButton.SetActive(true);
            EquipButton.SetActive(true);
            ItemAlreadyOwned.SetActive(true);
        }
        // default clothes
        else if (index == 0)
        {
            ItemAlreadyOwned.SetActive(true);
            BuyButton.SetActive(false);
            SellButton.SetActive(false);
            EquipButton.SetActive(true);
        }
        // can buy 
        else
        {
            ItemAlreadyOwned.SetActive(false);
            BuyButton.SetActive(true);
            SellButton.SetActive(false);
            EquipButton.SetActive(false);
        }
    }

    public void Buy()
    {
        Gold.ChangeGold(-Price);
        PlayerInventory.Add(Options[index]);
        CheckInventory();
    }

    // unequip item and remove from player inventory
    public void Sell()
    {
        if (PlayerRend.sprite == Options[index])
        {
            PlayerRend.sprite = PlayerInventory[0]; // default clothing
        }
        Gold.ChangeGold(Price);
        PlayerInventory.Remove(Options[index]);
        CheckInventory();
    }

    public void Equip()
    {
        PlayerRend.sprite = Options[index];
    }
}

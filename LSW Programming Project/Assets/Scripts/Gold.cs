using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Gold : MonoBehaviour
{
    [SerializeField] private int StartGold = 100;
    
    private static int CurrentAmount;
    private static TextMeshProUGUI textComp;

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMeshProUGUI>();
        textComp.text = StartGold.ToString();
        CurrentAmount = StartGold;
    }
    
    public static void ChangeGold(int amount)
    {
        CurrentAmount += amount;
        textComp.text = CurrentAmount.ToString();
    }

    public static int GetGold()
    {
        return CurrentAmount;
    }
}

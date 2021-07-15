using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject Customization;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        Customization.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}

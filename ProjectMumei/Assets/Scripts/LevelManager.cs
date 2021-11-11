using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {    
        if(MainMenu.instance.LoadingScreen != null)
        {
            Debug.Log("ACTIVE");
            MenuManager.instance.CloseAllMenu();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

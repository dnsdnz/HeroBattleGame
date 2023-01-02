using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public List<HeroProperties> heroesList;
    public List<HeroProperties> selectedHeroesList;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    //TODO save progress in every session
    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("myNumber", 100);
        
        //int loadedNumber = PlayerPrefs.GetInt(myNumber);
    }
}

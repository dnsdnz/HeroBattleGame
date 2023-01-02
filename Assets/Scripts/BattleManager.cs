using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    [SerializeField] public RectTransform gameCompletedPanel;
    
    private void Awake()
    {
        Instance = this;
    }

    public void GameCompleted()
    {
        gameCompletedPanel.gameObject.SetActive(true);
    }
}
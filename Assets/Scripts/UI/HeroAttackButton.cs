using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttackButton : MonoBehaviour
{
    [SerializeField] private string HeroId;

    [SerializeField] public Text heroName;
    [SerializeField] public Image heroImage;
    [SerializeField] private Slider heroHealth;
    
    [SerializeField] private Button attackButton;
    
    private void Start()
    {
        heroName.text = HeroId;
    }

    public void Set(string heroId)
    {
        HeroId = heroId;

        attackButton.onClick.AddListener(() =>
        {
            AttackButton(heroId);
        });
    }

    void AttackButton(string heroId)
    {
        
    }
}
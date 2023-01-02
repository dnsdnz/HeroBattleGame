using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttackButton : MonoBehaviour
{
    [SerializeField] private string HeroId;

    [SerializeField] public Text heroName;
    [SerializeField] public Image heroImage;
    [SerializeField] private Slider heroHealth;
    [SerializeField] private Button attackButton;

    public bool isAttack;
    public bool isAlive;
    
    private void Start()
    {
        heroName.text = HeroId;
    }
    //TODO check status of heroes and enemy after attack, send to battle manager for check their healths are 0

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
        GetComponent<RectTransform>().DOMoveX(800, 1.5f).OnComplete(()=>
        {
            GetComponent<RectTransform>().DORewind();
        });
        //move forward the selected hero while attacks
        isAttack = true;
    }
}
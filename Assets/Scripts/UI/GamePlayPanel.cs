using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class GamePlayPanel : MonoBehaviour
    {
        [SerializeField]
        private RectTransform playerHeroesParent;
        [Header("Hero")] 
        [SerializeField]
        private HeroAttackButton heroAttackButton;
        [SerializeField]
        private List<HeroAttackButton> heroAttackButtonList;
        
        [Header("Enemy")] 
        [SerializeField]
        public Text enemyName;
        public HeroProperties enemyHero;
        
        public List<HeroProperties> playerHeroesList;
        private void Awake()
        {
            heroAttackButtonList = new List<HeroAttackButton>();
            playerHeroesList = GameManager.Instance.selectedHeroesList;
            enemyHero = GameManager.Instance.heroesList[Random.Range(0, GameManager.Instance.heroesList.Count)];
        }
        
        private void Start()
        {
            enemyName.text = enemyHero.heroName;

            SetAttackButtons();
        }

        private void SetAttackButtons()
        {
            List<HeroProperties> heroList = GameManager.Instance.selectedHeroesList;

            foreach (var t in heroAttackButtonList)
            {
                t.gameObject.SetActive(false);
            }

            for (var i = 0; i < heroList.Count; i++)
            {
                HeroAttackButton hab;

                if (i < heroAttackButtonList.Count)
                {
                    hab = heroAttackButtonList[i];
                }
                else
                {
                    hab = Instantiate(heroAttackButton, playerHeroesParent);
                    heroAttackButtonList.Add(hab);
                }
                hab.Set(heroList[i].heroName);
                hab.gameObject.SetActive(true);
            }
        }
    }
}
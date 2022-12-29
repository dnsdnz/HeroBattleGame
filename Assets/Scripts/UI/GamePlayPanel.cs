using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class GamePlayPanel : MonoBehaviour
    {
        [SerializeField]
        private RectTransform playerHeroesParent;
        [SerializeField]
        private RectTransform enemyHeroParent;
        
        [Header("Hero Attack Button")] 
        [SerializeField]
        private HeroAttackButton heroAttackButton;
        [SerializeField]
        private List<HeroAttackButton> heroAttackButtonList;

        public List<HeroProperties> playerHeroesList;
        
        public HeroProperties enemyHero;
        public HeroAttackButton enemy;
        private void Awake()
        {
            heroAttackButtonList = new List<HeroAttackButton>();
            
            playerHeroesList = GameManager.Instance.selectedHeroesList;
                    
            enemyHero = GameManager.Instance.heroesList[Random.Range(0, heroAttackButtonList.Count)];
            
            Instantiate(enemy, enemyHeroParent);
        }
        
        private void Start()
        {
            enemy.heroName.text = enemyHero.heroName;

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
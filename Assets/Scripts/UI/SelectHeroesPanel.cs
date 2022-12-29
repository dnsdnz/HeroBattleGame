using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SelectHeroesPanel : MonoBehaviour
    {
        public Button playBattleButton;

        [Header("Hero Selection Button")] 
        [SerializeField]
        private HeroSelectionButton heroSelectionButton;
        [SerializeField]
        private RectTransform heroesParent;
        [SerializeField]
        private List<HeroSelectionButton> heroSelectionButtonList;
        
        private void Awake()
        {
            heroSelectionButtonList = new List<HeroSelectionButton>();
        }

        private void Start()
        {
            SetHeroButtons();
        }

        private void SetHeroButtons()
        {
            List<HeroProperties> heroList = GameManager.Instance.heroesList;

            foreach (var t in heroSelectionButtonList)
            {
                t.gameObject.SetActive(false);
            }

            for (var i = 0; i < heroList.Count; i++)
            {
                HeroSelectionButton hsb;

                if (i<heroSelectionButtonList.Count)
                {
                    hsb = heroSelectionButtonList[i];
                }
                else
                {
                    hsb = Instantiate(heroSelectionButton, heroesParent);
                    heroSelectionButtonList.Add(hsb);
                }
                hsb.Set(heroList[i].heroName);
                hsb.gameObject.SetActive(true);
            }
        }
        
        private void OnEnable()
        {
            playBattleButton.onClick.AddListener(PlayBattle);
        }

        private void OnDisable()
        {
            playBattleButton.onClick.RemoveAllListeners();
        }
        
        private void PlayBattle()
        {
            if (GameManager.Instance.selectedHeroesList.Count == 3)
            {
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                Debug.Log("Choose 3 character");
                //TODO open error panel   
            }
        }
    }
}
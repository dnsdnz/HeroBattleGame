using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SelectHeroesPanel : MonoBehaviour
    {
        public static SelectHeroesPanel Instance;
        public Button playBattleButton;

        [Header("Hero Selection Button")] 
        public HeroSelectionButton heroSelectionButton;
        [SerializeField]
        private RectTransform heroesParent;
        public List<HeroSelectionButton> heroSelectionButtonList;

        [Header("Warning Area")] 
        [SerializeField] private GameObject warningPanel;
        [SerializeField] private Button closeWarningButton;
        private void Awake()
        {
            Instance = this;
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
            closeWarningButton.onClick.AddListener(() =>
            {
                warningPanel.SetActive(false);
            });
        }

        private void OnDisable()
        {
            playBattleButton.onClick.RemoveAllListeners();
            closeWarningButton.onClick.RemoveAllListeners();
        }
        
        private void PlayBattle()
        {
            if (GameManager.Instance.selectedHeroesList.Count == 3)
            {
                SceneManager.LoadScene("GameScene");
            }
            else
            {
               warningPanel.SetActive(true);
            }
        }
    }
}
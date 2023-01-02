using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HeroSelectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private string HeroId;

        [SerializeField] private Text heroName;
        [SerializeField] private Image heroImage;

        [SerializeField] private Button selectButton;

        [Header("Pop Up Panel")]
        [SerializeField] private RectTransform popUpArea;
        [SerializeField] private Text popUpNameText;
        [SerializeField] private Text popUpLevelText;
        [SerializeField] private Text popUpAttackText;
        [SerializeField] private Text popUpExperienceText;

        public bool buttonStatus;

        public HeroProperties currentHeroProperties;
        private void Start()
        {
            heroName.text = HeroId;
            buttonStatus = false;
            currentHeroProperties = GameManager.Instance.heroesList.Find(h => h.heroName == HeroId);
        }
        public void Set(string heroId)
        {
            HeroId = heroId;

            selectButton.onClick.AddListener(() =>
                {
                    SelectedButton(heroId);
                });
        }

        void SelectedButton(string heroId)
        {
            if (buttonStatus) //selected
            {
                heroImage.color = Color.white;
                buttonStatus = false;
                
                currentHeroProperties = GameManager.Instance.heroesList.Find(h => h.heroName == heroId);
                if (currentHeroProperties)
                {
                    GameManager.Instance.selectedHeroesList.Remove(currentHeroProperties);
                }
            }
            else
            {
                if (GameManager.Instance.selectedHeroesList.Count < 3)
                {
                    heroImage.color = Color.red;
                    buttonStatus = true;
                    
                    if (currentHeroProperties)
                    {
                        GameManager.Instance.selectedHeroesList.Add(currentHeroProperties);
                    }
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            popUpArea.gameObject.SetActive(true);
            popUpNameText.text = "Name:" + currentHeroProperties.heroName;
            popUpLevelText.text = "Level:" + currentHeroProperties.level;
            popUpAttackText.text = "Attack Power:" + currentHeroProperties.attackPower;
            popUpExperienceText.text = "Experience:" + currentHeroProperties.experience;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            popUpArea.gameObject.SetActive(false);
        }
    }
}
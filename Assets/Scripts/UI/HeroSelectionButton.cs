using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeroSelectionButton : MonoBehaviour
    {
        [SerializeField] private string HeroId;

        [SerializeField] private Text heroName;
        [SerializeField] private Image heroImage;

        [SerializeField] private Button selectButton;

        public bool buttonStatus;
        private void Start()
        {
            heroName.text = HeroId;
            buttonStatus = false;
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
                
                var hero = GameManager.Instance.heroesList.Find(h => h.heroName == heroId);
                if (hero)
                {
                    GameManager.Instance.selectedHeroesList.Remove(hero);
                }
            }
            else
            {
                if (GameManager.Instance.selectedHeroesList.Count < 3)
                {
                    heroImage.color = Color.red;
                    buttonStatus = true;
                    
                    var hero = GameManager.Instance.heroesList.Find(h => h.heroName == heroId);
                    GameManager.Instance.selectedHeroesList.Add(hero);
                }
            }
        }
    }
}
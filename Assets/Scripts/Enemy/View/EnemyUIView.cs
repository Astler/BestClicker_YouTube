using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.View
{
    public class EnemyUIView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthText;
        
        public void SetHealth(int health, int maxHealth)
        {
            healthSlider.value = (float) health/maxHealth;
            healthText.text = health.ToString();
        }

        public void ShowUI()
        {
            gameObject.SetActive(true);
        }

        public void HideUI()
        {
            gameObject.SetActive(false);
        }
    }
}

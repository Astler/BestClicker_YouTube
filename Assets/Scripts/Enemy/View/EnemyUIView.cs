using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.View
{
    public class EnemyUIView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthText;

        private RectTransform _transform;
        private float _yBase;

        public void SetHealth(int health, int maxHealth)
        {
            healthSlider.value = (float)health / maxHealth;
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

        public void SetUIShift(float distance)
        {
            Vector2 currentPosition = _transform.anchoredPosition;
            _transform.anchoredPosition = new Vector3(currentPosition.x, _yBase + distance);
        }

        private void Awake()
        {
            _transform = (RectTransform)transform;
            _yBase = _transform.anchoredPosition.y;
        }
    }
}
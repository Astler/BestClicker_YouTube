using System;
using Extensions.UserInterface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private Button clickerButton;
        [SerializeField] private TextMeshProUGUI killsScoreText;
        [SerializeField] private Image respawnProgress;

        public event Action ButtonClicked;

        public void SetKilledScore(int killed) => killsScoreText.SetText(killed);

        public void SetRespawnProgress(float progress) => respawnProgress.fillAmount = progress;

        private void Awake()
        {
            clickerButton.onClick.AddListener(() => ButtonClicked?.Invoke());
        }
    }
}
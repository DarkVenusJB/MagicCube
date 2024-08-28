using UnityEngine;

namespace Assets.Scripts
{
    public class WinPanelToogler : MonoBehaviour
    {
        [SerializeField] private GameObject WinPanel;

        private void OnEnable()
        {
            EventSystem.WinEvent += OnWin;
        }

        private void OnDisable()
        {
            EventSystem.WinEvent -= OnWin;
        }

        private void OnWin()
        {
            WinPanel.SetActive(true);
        }
    }
}
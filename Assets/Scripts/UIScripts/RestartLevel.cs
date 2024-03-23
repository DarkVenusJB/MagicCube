using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
   private Button restartButton;

    private void Start()
    {
        restartButton = GetComponent<Button>();
    }

    public void Restart()
    {
        EventSystem.OnLevelRestarted();
    }
}

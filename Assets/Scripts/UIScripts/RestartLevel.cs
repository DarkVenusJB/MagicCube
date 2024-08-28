using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public void Restart() => EventSystem.OnLevelRestarted();
   
}

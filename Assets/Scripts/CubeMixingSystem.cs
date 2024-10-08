using UnityEngine;

public class CubeMixingSystem : MonoBehaviour
{
    [SerializeField] private Transform[] cubesPosition;

    private Transform currentPosition;

    private void Start() => Mix();
    

    private void OnEnable()
    {
        EventSystem.LevelRestartedEvent += OnLevelRestarted;
    }

    private void OnDisable()
    {
        EventSystem.LevelRestartedEvent -= OnLevelRestarted;
    }  

    private void Mix()
    {
        for (int i = 0; i<cubesPosition.Length; i++)
        {
            currentPosition = cubesPosition[i];

            if (i+1<cubesPosition.Length)
            {
                cubesPosition[i].position = cubesPosition[i + 1].position;
                cubesPosition[i + 1].position = currentPosition.position;
            }

            else
            {
                cubesPosition[i].position = cubesPosition[0].position;
                cubesPosition[0].position = currentPosition.position;
            }
        }
    }

    private void OnLevelRestarted() => Mix();
}

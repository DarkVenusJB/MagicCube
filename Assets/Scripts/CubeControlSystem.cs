using UnityEngine;

public class CubeControlSystem : MonoBehaviour
{
    [SerializeField] CubeChecker[] points;
    
    public static CubeControlSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this.gameObject);
    }

    public void CheckWin()
    {
        for(int i = 0; i<points.Length; i++)
        {
            if (points[i].isTrueObj==false)
            {
                return;
            }
            
            else if (points[i].isTrueObj == true)
            {
                if(i==points.Length-1)
                {
                    Debug.Log("Win");
                }
            }
        }
    }
}

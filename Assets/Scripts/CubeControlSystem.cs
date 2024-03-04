using UnityEngine;

public class CubeControlSystem : MonoBehaviour
{
    [SerializeField] CubeChecker[] points;
    [SerializeField]private Transform[] pointsTransform;

    
    
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

    private void Start()
    {
        pointsTransform = new Transform[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            pointsTransform[i] = points[i].transform;
        }
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

    public void ReturnToNearPoint(GameObject currentObject)
    {
        float minDistance = 100;
        float currentDistance;
        Transform nearPoint=null;
        for(int i =0; i<pointsTransform.Length;i++)
        {
            currentDistance = Vector3.Distance(currentObject.transform.position, pointsTransform[i].position);

            if (currentDistance < minDistance && points[i].isEmptyPoint)
            {
                minDistance = currentDistance;
                nearPoint = pointsTransform[i];
                Debug.Log(points[i].gameObject.name);
            }
        }
        
        currentObject.transform.position = nearPoint.position;

    }
}

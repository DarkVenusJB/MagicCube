using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField] private GameObject trueGameObject;

    [SerializeField ]private bool _isTrueObject = false;
    [SerializeField] private bool _isEmptyPoint =true;

    public bool isTrueObj
    {
        get { return _isTrueObject; }

        private set { _isTrueObject = value; }
    }

    public bool isEmptyPoint
    {
        get { return _isEmptyPoint; }

        private set { _isEmptyPoint = value; }  
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            if (other.gameObject == trueGameObject)
            {              
                isTrueObj = true;
                CubeControlSystem.Instance.CheckWin();
            }          
        }

        isEmptyPoint = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isEmptyPoint = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == trueGameObject)
        {
            isTrueObj = false;
        }

        isEmptyPoint = true;
    }
}

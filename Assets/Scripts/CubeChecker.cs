using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField] private GameObject trueGameObject;

    [SerializeField ]private bool _isTrueObject = false;

    public bool isTrueObj
    {
        get { return _isTrueObject; }

        private set { _isTrueObject = value; }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            if (other.gameObject == trueGameObject)
            {
                //Debug.Log(true);
                isTrueObj = true;
                CubeControlSystem.Instance.CheckWin();
            }

            else
            {
                Debug.Log(false);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == trueGameObject)
        {
            isTrueObj = false;
        }
    }
}

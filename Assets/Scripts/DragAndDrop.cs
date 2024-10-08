using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private InputAction mouseUp;
    [SerializeField] private float mouseDragPhysicsSpeed = 10f;
    [SerializeField] private float mouseDragTransformSpeeed =.1f;

    private Vector3 velocity = Vector3.zero;
    private Camera mainCamera;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private GameObject dragObject;
    

    private void Awake()
    {
        Application.targetFrameRate = 60;
        mainCamera = Camera.main;  
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseUp.Enable();
        mouseClick.performed += MousePressed;
        mouseUp.performed += MouseReleased;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseUp.performed -= MouseReleased;
        mouseClick.Disable();
        mouseUp.Disable();
    } 
    
    private void MousePressed(InputAction.CallbackContext context)
    {        
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            dragObject = hit.collider.gameObject;

            if(hit.collider != null && dragObject.layer == LayerMask.NameToLayer("Draggable"))
            {
                dragObject.GetComponent<Rigidbody>().isKinematic = false;
                StartCoroutine(DragUpdate(hit.collider.gameObject));               
            }
        }        
    }

    private void MouseReleased(InputAction.CallbackContext context)
    {
        if (dragObject.layer == LayerMask.NameToLayer("Draggable"))
        {
            dragObject.GetComponent<Rigidbody>().isKinematic = true;
            CubeControlSystem.Instance.ReturnToNearPoint(dragObject);
            EventSystem.OnBlockMove();
        }
    }  
    

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while(mouseClick.ReadValue<float>()!=0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (rb != null)
            {
                Vector3 delta = new Vector3(0, 0.7f, 0);
                Vector3 direction = ray.GetPoint(initialDistance) - (clickedObject.transform.position - delta);
                rb.velocity = direction * mouseDragPhysicsSpeed;

                yield return waitForFixedUpdate;
            }

            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position,
                ray.GetPoint(initialDistance), ref velocity, mouseDragTransformSpeeed);

                yield return null;
            }           
        }
    }
}

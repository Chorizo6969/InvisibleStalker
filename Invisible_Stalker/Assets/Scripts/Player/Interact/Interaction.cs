using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private int _nombrePhotoSupParPellicules;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) { return; }
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
            {
                switch(hit.transform.gameObject.layer)
                {
                    case (6): //interrupteur
                        hit.transform.gameObject.GetComponent<SwitchLightActive>().SwitchLight();
                        break;
                    case (7): //Pellicules
                        PhotoCapture.Instance.NombreOfPellicule += _nombrePhotoSupParPellicules;
                        Pellicules.Instance.NomberPhotoPossible += _nombrePhotoSupParPellicules;
                        Pellicules.Instance.UpdatePhoto();
                        break;
                    case (10): //Le monstre
                        break;
                    default: //Le reste
                        break;
                }
                Debug.Log(hit.transform.gameObject.layer);
            }
        }
    }
}

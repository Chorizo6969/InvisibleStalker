using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private int _nombrePhotoSupParPellicules;

    public bool ActualItemDrag;

    [SerializeField]
    private GameObject _potentialItem;

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
                    case (8): //Item
                        hit.transform.gameObject.GetComponent<CarryItem>().DragItem();
                        ActualItemDrag = true;
                        break;
                    case (9): //Pupitre
                        if (_potentialItem.transform.childCount == 0) { return; }
                        _potentialItem.GetComponentInChildren<CarryItem>().DropItem(hit.transform.gameObject.transform);
                        ActualItemDrag = false;
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

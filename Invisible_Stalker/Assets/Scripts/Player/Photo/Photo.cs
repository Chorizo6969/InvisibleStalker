using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [SerializeField] private NavMeshInvisibleStalker _monster;
    [SerializeField] private Camera _photoCamera;
    [SerializeField] private RenderTexture _renderTexture;
    [SerializeField] private RawImage _photoDisplay;
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private Pellicules _pellicules;

    private Texture2D _capturedPhoto;
    private bool _appareilOn;

    public int NombreOfPellicule;

    public static PhotoCapture Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (_photoCamera != null)
        {
            _photoCamera.targetTexture = _renderTexture;
        }
        if (_photoDisplay != null)
        {
            _photoDisplay.gameObject.SetActive(false);
        }
    }

    public void TakePhoto(InputAction.CallbackContext context) //E
    {
        if (!context.performed) return;

        PlayerAnimation.Instance.ChangeStatePhoto();
        _appareilOn = true;
    }

    public async void Photo(InputAction.CallbackContext context) //ClicGauche
    {
        if (!context.performed || !_appareilOn) return;

        if (NombreOfPellicule > 0)
        {
            _photoCamera.cullingMask |= 11 << LayerMask.NameToLayer("Monstre");
            PlayerAnimation.Instance.CancelledStatePhoto();
            _appareilOn = false;
            await Task.Delay(50);
            CapturePhoto();

            CheckObjectsInPhoto();
        }
    }

    private void CapturePhoto()
    {
        if (_capturedPhoto != null)
        {
            Destroy(_capturedPhoto);
        }

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = _renderTexture;

        _capturedPhoto = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.RGB24, false);
        _capturedPhoto.ReadPixels(new Rect(0, 0, _renderTexture.width, _renderTexture.height), 0, 0);
        _capturedPhoto.Apply();

        RenderTexture.active = currentRT;

        if (_photoDisplay != null)
        {
            _photoDisplay.texture = _capturedPhoto;
            _photoDisplay.gameObject.SetActive(true);
        }

        Debug.Log("Photo captur�e et affich�e � l'�cran.");
        NombreOfPellicule--;
        _pellicules.UpdatePhoto();
    }

    private void Update()
    {
        if (!_appareilOn) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _appareilOn = false;
            PlayerAnimation.Instance.CancelledStatePhoto();
        }
    }

    private void CheckObjectsInPhoto()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_photoCamera);
        Collider[] objectsInRange = Physics.OverlapSphere(_photoCamera.transform.position, 100f, _detectionLayer);

        foreach (Collider obj in objectsInRange)
        {
            if (GeometryUtility.TestPlanesAABB(planes, obj.bounds))
            {
                Vector3 directionToObject = (obj.bounds.center - _photoCamera.transform.position).normalized;
                float distanceToObject = Vector3.Distance(_photoCamera.transform.position, obj.bounds.center);

                if (!Physics.Raycast(_photoCamera.transform.position, directionToObject, distanceToObject, ~_detectionLayer)) //Si le monstre est pris en photo direct
                {
                    _monster.StunMonster();
                }
            }
        }
        _photoCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Monstre"));
    }

}

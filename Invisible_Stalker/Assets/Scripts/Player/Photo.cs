using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [SerializeField]
    private Camera _photoCamera;

    [SerializeField]
    private RenderTexture _renderTexture;

    [SerializeField]
    private RawImage _photoDisplay;

    [SerializeField]
    private Texture2D _capturedPhoto;

    [SerializeField]
    private bool _appareilOn = false;

    private void Start()
    {
        _photoCamera.targetTexture = _renderTexture;

        if (_photoCamera.targetTexture != _renderTexture)
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
        if (!context.performed) { return; }

        PlayerAnimation.Instance.ChangeStatePhoto();
        _appareilOn = true;
    }

    public void Photo(InputAction.CallbackContext context) //ClicGauche
    {
        if (!context.performed) { return; }
        if (_appareilOn)
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

            Debug.Log("Photo capturée et affichée à l'écran.");
            PlayerAnimation.Instance.CancelledStatePhoto();
            _appareilOn = false;
        }


    }

    private void Update()
    {
        if (!_appareilOn) { return ; }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _appareilOn = false;
            PlayerAnimation.Instance.CancelledStatePhoto();
        }
    }
}

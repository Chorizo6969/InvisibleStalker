using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    public Camera photoCamera;
    public RenderTexture renderTexture;
    public RawImage photoDisplay; 

    private Texture2D capturedPhoto;

    private void Start()
    {
        photoCamera.targetTexture = renderTexture;

        if (photoCamera.targetTexture != renderTexture)
        {
            photoCamera.targetTexture = renderTexture;
        }


        if (photoDisplay != null)
        {
            photoDisplay.gameObject.SetActive(false);
        }
    }

    public void TakePhoto(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }


        // Libérer la mémoire de l'ancienne texture
        if (capturedPhoto != null)
        {
            Destroy(capturedPhoto);
        }


        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = renderTexture;

        capturedPhoto = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        capturedPhoto.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        capturedPhoto.Apply();

        RenderTexture.active = currentRT;


        if (photoDisplay != null)
        {
            photoDisplay.texture = capturedPhoto;
            photoDisplay.gameObject.SetActive(true);
        }

        Debug.Log("Photo capturée et affichée à l'écran.");
    }
}

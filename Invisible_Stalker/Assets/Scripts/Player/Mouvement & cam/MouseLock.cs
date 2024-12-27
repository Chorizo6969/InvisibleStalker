using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 15;

    [SerializeField]
    private Transform _cam;

    private Vector2 _mouseDelta;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    public void OnMouseLookPerformed(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
        if (context.canceled)
        {
            _mouseDelta = Vector2.zero;
        }
    }

    private void Update()
    {
        RotateView();
    }

    private void RotateView()
    {
        // Appliquer la rotation de la souris à la caméra
        float mouseX = _mouseDelta.x * _sensitivity * Time.deltaTime;
        float mouseY = _mouseDelta.y * _sensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Limite pour éviter de regarder "à l'envers"

        _yRotation += mouseX;
        //cam
        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        //player
        _cam.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}

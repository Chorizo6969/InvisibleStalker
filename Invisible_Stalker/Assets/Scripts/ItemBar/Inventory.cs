using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Image> _images = new List<Image>();

    public void SlotInventory(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        foreach (var image in _images)
        {
            image.color = Color.white;
        }

        switch (context.control.name)
        {
            case "1":
                _images[0].color = Color.yellow;
                break;
            case "2":
                _images[1].color = Color.yellow;
                break;
            case "3":
                _images[2].color = Color.yellow;
                break;
            case "4":
                _images[3].color = Color.yellow;
                break;
            case null:
                break;
        }
    }
}

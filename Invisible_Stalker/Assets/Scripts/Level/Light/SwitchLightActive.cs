using System.Collections.Generic;
using UnityEngine;

public class SwitchLightActive : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listOfLightInThisRoom = new List<GameObject>();

    [SerializeField]
    private bool _switch;

    public void SwitchLight()
    {
        if (_switch)
        {
            _switch = false;
            print(_switch);
            OFF();
        }
        else
        {
            _switch = true;
            ON();
        }
    }

    public void ON()
    {
        foreach (GameObject obj in _listOfLightInThisRoom)
        {
            obj.SetActive(true);
        }
    }

    public void OFF()
    {
        foreach (GameObject obj in _listOfLightInThisRoom)
        {
            obj.SetActive(false);
        }
    }
}

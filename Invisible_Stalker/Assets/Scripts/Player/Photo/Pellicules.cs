using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pellicules : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nomberOfPellicules;
    [SerializeField]
    private int _nomberPhotoPossible;
    [SerializeField]
    private PhotoCapture _photoCapture;

    private void Start()
    {
        UpdatePhoto();
    }

    public void UpdatePhoto()
    {
        _nomberPhotoPossible = _photoCapture.NombreOfPellicule;
        _nomberOfPellicules.text = _nomberPhotoPossible.ToString();
    }

    private void AugmentePhoto()
    {

    }
}

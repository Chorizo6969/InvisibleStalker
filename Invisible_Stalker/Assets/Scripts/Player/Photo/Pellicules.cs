using TMPro;
using UnityEngine;

public class Pellicules : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nomberOfPellicules;

    [SerializeField]
    private PhotoCapture _photoCapture;

    [SerializeField]
    private GameObject _outOfPicture;

    public int NomberPhotoPossible;
    public static Pellicules Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdatePhoto();
    }

    public void UpdatePhoto()
    {
        NomberPhotoPossible = _photoCapture.NombreOfPellicule;
        _nomberOfPellicules.text = NomberPhotoPossible.ToString();
        if(NomberPhotoPossible == 0)
        {
            _outOfPicture.SetActive(true);
        }
        else
        {
            _outOfPicture.SetActive(false);
        }
    }
}

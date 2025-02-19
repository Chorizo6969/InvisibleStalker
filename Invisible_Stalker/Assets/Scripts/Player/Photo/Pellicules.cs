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

    }
}

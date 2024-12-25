using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public static PlayerAnimation Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeStatePhoto()
    {
        _animator.SetBool("CanPhoto", true);
    }

    public void CancelledStatePhoto()
    {
        _animator.SetBool("CanPhoto", false);
    }
}

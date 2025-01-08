using UnityEngine;

public class DebugComportementMonstre : MonoBehaviour
{
    [SerializeField]
    private NavMeshInvisibleStalker _parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 11) { return; }
        _parent._potentialSpawn.Remove(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 11) { return; }
        _parent._potentialSpawn.Add(other.gameObject);
    }
}

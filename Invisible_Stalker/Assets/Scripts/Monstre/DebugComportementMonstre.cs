using UnityEngine;

public class DebugComportementMonstre : MonoBehaviour
{
    [SerializeField]
    private NavMeshInvisibleStalker _parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            _parent._potentialSpawn.Remove(other.gameObject);
        }
        else if (other.gameObject.layer == 12)
        {
            other.gameObject.GetComponent<SetDestinationScarabee>().FleeFromPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11) 
        {
            _parent._potentialSpawn.Add(other.gameObject);
        }
        else if (other.gameObject.layer == 12)
        {
            other.gameObject.GetComponent<SetDestinationScarabee>().StopFleeing();
        }
    }
}

using UnityEngine;

public class RoomTracker : MonoBehaviour
{
    private string _currentRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            _currentRoom = other.gameObject.name;
            Debug.Log($"Joueur est dans la pi�ce : {_currentRoom}");
        }
    }

    public string GetCurrentRoom()
    {
        return _currentRoom;
    }
}

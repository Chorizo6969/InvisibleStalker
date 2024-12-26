using UnityEngine;

public class RoomTracker : MonoBehaviour
{
    private string currentRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = other.gameObject.name;
            Debug.Log($"Joueur est dans la pièce : {currentRoom}");
        }
    }

    public string GetCurrentRoom()
    {
        return currentRoom;
    }
}

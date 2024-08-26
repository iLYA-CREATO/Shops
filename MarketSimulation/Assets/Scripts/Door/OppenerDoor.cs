using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppenerDoor : MonoBehaviour
{
    public bool isOpen;

    public Animator DoorController;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorController.Play("Door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorController.Play("Clouse");
        }
    }

}

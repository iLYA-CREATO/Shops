using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAnlock : MonoBehaviour
{
    [SerializeField] private KeyCode AnlockMouseKey;
    [SerializeField] private MoveCamera moveCamera;
    

    private void Update()
    {
        if(Input.GetKey(AnlockMouseKey))
        {
            Cursor.lockState = CursorLockMode.None;
            moveCamera.enabled = false;
        }
        if (Input.GetKeyUp(AnlockMouseKey))
        {
            Cursor.lockState = CursorLockMode.Locked;
            moveCamera.enabled = true;
        }
    }
}

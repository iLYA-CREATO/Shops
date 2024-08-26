using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClouseAllInteface : MonoBehaviour
{
    public GameObject[] allInvetory;
    public void ClouseInterface()
    {
        for(int i = 0; i < allInvetory.Length; i++)
        {
            allInvetory[i].SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class point
{
    public Transform pointTransform;
    public bool pointBusy; // ������ �� �����
}


public class PointMapMoved : MonoBehaviour
{
    
    public List<point> pointMap;
    // ���������������
    //[SerializeField] private List<GameObject> pointer;
    /*public void Awake()
    {
        for(int a = 0; a <= pointer.Count; a++)
        {
            pointMap.Add(new point{ pointTransform = pointer[a].transform});
        }
    }*/


}

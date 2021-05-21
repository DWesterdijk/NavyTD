using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewShip : MonoBehaviour
{
    private DragDropSchip _spawner;
    private int _waterLayer = 1 << 4;

    public void OnSpawn(DragDropSchip spawner)
    {
        _spawner = spawner;
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.layer != _waterLayer)
        {
            Debug.Log("Collision");
            _spawner.SetDropable(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != _waterLayer)
            _spawner.SetDropable(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != _waterLayer)
        {
            _spawner.SetDropable(true);
        }
    }
}

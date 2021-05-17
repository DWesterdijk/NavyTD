using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager current;

    private void Awake()
    {
        if (current == null)
            current = this;
    }

    private List<ShipFire> _towers = new List<ShipFire>();
    private List<GameObject> _enemies = new List<GameObject>();


}

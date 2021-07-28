using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField]
    GameObject BustParticle;

    public void StartBust()
    {
        Instantiate(BustParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

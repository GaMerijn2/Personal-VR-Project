using System;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int ignoreLayer;

    private void Start()
    {
        ignoreLayer = LayerMask.NameToLayer("IgnoreLayer");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Hit something: {other.name}, Layer: {other.gameObject.layer}");

        if (other.gameObject.layer == ignoreLayer) 
        {
            Debug.Log("Hit IgnoreLayer, not destroying");
            return;
        }

        Debug.Log("Destroying bullet");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Hit something: {other.gameObject.name}, Layer: {other.gameObject.layer}");

        if (other.gameObject.layer == ignoreLayer) 
        {
            Debug.Log("Hit IgnoreLayer, not destroying");
            return;
        }

        Debug.Log("Destroying bullet");
        Destroy(gameObject);
    }
}
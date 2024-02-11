using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField] GameObject pinPrefab;

    Pin currentPin;

    private void Start()
    {
        SpawnPin();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentPin != null)
        {
            currentPin.Lannch();
            currentPin = null;
            SpawnPin();
        }
    }

    void SpawnPin()
    {
        GameObject clone = Instantiate(pinPrefab, transform.position, quaternion.identity);
        currentPin = clone.GetComponent<Pin>();
    }
}

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
        if (Input.GetMouseButtonDown(0) && currentPin != null && GameManager.instance.isGameOver == false)
        {
            currentPin.Lannch();
            currentPin = null;
            Invoke("SpawnPin", 0.1f); // 다음핀 준비 및 기존핀과 충돌하지않게 딜레이 주는것 0.1초 
        }
    }

    void SpawnPin()
    {
        if (GameManager.instance.isGameOver == false && GameManager.instance.score > 1) // 마지막 핀이 남았을때 생성 X
        {
            GameObject clone = Instantiate(pinPrefab, transform.position, quaternion.identity);
            currentPin = clone.GetComponent<Pin>();
        }
    }

}

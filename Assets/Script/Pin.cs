using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    bool isPinned;
    bool isLanuch;
    [SerializeField] GameObject pinBar;

    private void Awake()
    {
        pinBar = transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!isPinned && isLanuch)
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            transform.SetParent(other.transform);
            pinBar.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.instance.DecreaseScore();
            isPinned = true;
        }
        else if(other.CompareTag("Pin"))
        {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Lannch()
    {
        isLanuch = true;
    }
}

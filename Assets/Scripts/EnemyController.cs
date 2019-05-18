using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float health;

    private Transform playerTransform;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(playerTransform);
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    public void OnHit()
    {
        health -= 1f;
        if (health <= 0f)
            Destroy(gameObject);
    }

    public void SetPlayer(PlayerController playerController)
    {
        playerTransform = playerController.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OnHit();
            Destroy(gameObject);
        }
    }
}
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float health;

    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private ProjectileController bulletPrefab;

    [SerializeField]
    private Transform bulletSpawnTransform;

    [SerializeField]
    private int spreadCount;

    private const int groundLayer = 1 << 8;

    [SerializeField]
    private float spreadDegree;

    private void Update()
    {
        //RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out var hit, 100f, groundLayer))
        {
            Vector3 lookAtXZ = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            transform.LookAt(lookAtXZ);
        }

        var moveDirectionVector = ((Input.GetAxisRaw("Vertical") * transform.forward) + (Input.GetAxisRaw("Horizontal") * transform.right)).normalized;

        if (moveDirectionVector != Vector3.zero)
        {
            transform.position += Time.deltaTime * speed * moveDirectionVector;
        }

        if (Input.GetButton("Fire1"))
        {
            for (int i = 0; i < spreadCount; ++i)
            {
                float localDegree = Mathf.Lerp(-spreadDegree /2f, spreadDegree / 2f, (float)i / spreadCount);
                Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.Euler(0f, transform.rotation.eulerAngles.y + localDegree, 0f));
            }
        }
    }

    public void OnHit()
    {
        health -= 1f;
        if (health <= 0f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // TODO: @kendo will do the awesome UI later
    }
}
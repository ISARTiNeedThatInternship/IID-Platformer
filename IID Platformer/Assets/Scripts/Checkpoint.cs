using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    void OiggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position; // Déplace le spawn du joueur à la position du checkpoint
            Destroy(gameObject);
        }
    }
}

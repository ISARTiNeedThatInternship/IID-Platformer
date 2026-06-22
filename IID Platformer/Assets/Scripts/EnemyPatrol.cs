using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;

    public int damageOnCollision = 20;
    private Transform target;
    private int destinationPoint = 0;

    void Start()
    {
        target = waypoints[0];
        graphics = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; // Récupérer la direction.
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        // Déplacer l'ennemi par rapport au monde.

        // Si l'ennemi est presque arrivé à sa destination.
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            // Augmente le n° du waypoint par 1 et le remet à zéro si le bout de l'array est atteint.
            destinationPoint = (destinationPoint + 1) % waypoints.Length;
            // Met la cible au waypoint correspondant au point de destination
            target = waypoints[destinationPoint];
            // Flip l'ennemi à l'opposé de sa direction
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}

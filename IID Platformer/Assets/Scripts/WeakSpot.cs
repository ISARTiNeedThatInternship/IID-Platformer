using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Vérifie si la collision est faite par le joueur.
        {
            Destroy(objectToDestroy);
            // Détruit le parent de l'objet WeakSpot (=Ennemi)
        }
    }
}
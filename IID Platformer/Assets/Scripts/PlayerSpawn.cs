using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Awake()
    {
        GameObject.FindWithTag("Player").transform.position = transform.position;
        //         Trouver le joueur et sa position   |   Le déplacer à l'emplacement de PlayerSpawn
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
                                             //      Caméra                  Joueur              Décalage    Vitesse   Décalage (temps) 
    }
}

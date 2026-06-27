using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects; // Crée un array d'objets à ne PAS suppprimer
    void Awake()
    {
        foreach (var element in objects) // Applique une condition pour tous les objets de la liste
        {
            DontDestroyOnLoad(element); // Dit à unity de ne pas supprimer ces éléments
        }
    }
}

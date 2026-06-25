using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance; // Crée un singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scène !");
            return; // = à return 0; en C++ (je crois)
        }

        instance = this; // Définit l'instance
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString(); // Transforme le nombre de pièces en texte + AFFICHAGE
    }
}

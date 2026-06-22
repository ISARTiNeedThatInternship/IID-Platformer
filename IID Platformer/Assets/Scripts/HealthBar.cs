using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill; // Fill est le remplissage de la barre de vie
    public void SetMaxHealth(int health) // Initialisation de la vie max du joueur*
    {
        slider.maxValue = health; // *
        slider.value = health; // *

        fill.color = gradient.Evaluate(1f); // Met la couleur du fill à la valeur la plus haute du dégradé
    }

    public void SetHealth(int health) // Réinitialisation de la vie du joueur
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); // Met à jour la couleur en fonction de la valeur du slider
    }
}
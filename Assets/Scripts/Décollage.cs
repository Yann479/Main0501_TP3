using System.Collections;
using UnityEngine;

public class Décollage : MonoBehaviour
{
    public float vitesseInitiale = 100f; // vitesse au départ de l'hélicoptère
    public float vitesseMaximale = 1000f; // sa vitesse maximale
    public float augmentationVitesse = 50f; // l'incrémentation à faire sur sa vitesse
    public float intervallePalier = 1f; // le temps entre chaque incrémentation de sa vitesse
    public float forceAscensionnelle = 20f; // Force qui va permettre à l'avion de monter
    public GameObject objetPiste; // référence à mon objet Piste, qui réalise le déclenchement du décollage à son contact
    public float multiplicateurForce = 5000f; // multiplicateur de force
    public GameObject hélice; // référence à l'objet hélice de l'hélicoptère
    public float vitesseRotationMaximale = 1000f; // vitesse maximale de rotation des hélices
    public float accélérationRotation = 100f; //incrémentation de la vitesse de rotation des hélices
    public float délaiDécollage = 5f; // temps avant chaque incrémentation de la vitesse des hélices

    private float vitesseActuelle; // vitesse actuel de l'hélicoptère
    private bool peutDécoller = false; //variable booléen pour définir si les conditions de décollage sont remplies (être sur la piste + délais de 3 secondes écoulé)
    private Rigidbody rbAvion;
    private float TempsDernierPalier = 0f; 

    void Start()
    {
        rbAvion = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
        vitesseActuelle = vitesseInitiale;
    }

    void FixedUpdate()
    {
        if (peutDécoller) // si le décollage est autorisé, faire les appels suivants
        {
            AugmenterVitesseParPalier(); 
            AccélérerAvion();
            AppliquerForceAscensionnelle();
        }
    }

    void AugmenterVitesseParPalier() // Méthode pour augmenter la vitesse par palier
    {
        TempsDernierPalier += Time.fixedDeltaTime; // incrémente la variable qui défini le temps
        if (TempsDernierPalier >= intervallePalier) // vérifie si l'interval entre 2 paliers est atteint
        {
            vitesseActuelle = Mathf.Min(vitesseActuelle + augmentationVitesse, vitesseMaximale); // augmente la vitesse
            TempsDernierPalier = 0f; // réinitialise le temps du dernier palier
        }
    }

    void AccélérerAvion() // Methode pour faire accèlérer l'hélicoptère
    {
        rbAvion.AddForce(transform.forward * vitesseActuelle * multiplicateurForce, ForceMode.Force); // applique la force vesr l'avant
        rbAvion.velocity = Vector3.ClampMagnitude(rbAvion.velocity, vitesseMaximale); // Limite la vitesse maximale de celui-ci
    }

    void AppliquerForceAscensionnelle() // méthode pour appliquer la force ascentionnelle
    {
        rbAvion.AddForce(transform.up * forceAscensionnelle * vitesseActuelle, ForceMode.Force); // applique la force ascensionnelle
    }

    private void OnCollisionEnter(Collision collision) // méthode qui va être appelé en cas de collision d'objets
    {
        if (objetPiste != null && collision.gameObject == objetPiste && !peutDécoller) // vérifie si l'hélicoptère est sur la piste de décollage
        {
            StartCoroutine(DémarrerDécollage()); // Appel DémarrerDécollage avec une coroutine pour la gestion du temps de pause de 3 secondes dans DémarrerDécollage()
        }
    }

    IEnumerator DémarrerDécollage()
    {
        Debug.Log("Autorisation de décollage accordée, décollage prévu dans " + délaiDécollage + " secondes"); // affichage d'un message pour prévenir du décollage des hélicoptères
        yield return new WaitForSeconds(délaiDécollage); // réalise un temps d'attente de 3 secondes avant le décollage
        peutDécoller = true; // autorise le décollage
    }
}
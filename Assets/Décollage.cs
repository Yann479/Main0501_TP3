using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// à modifier pour augmenter la  vitesse du futur avion
public class Décollage : MonoBehaviour
{
    public TextMeshPro NbStocke; // déclaration du texte qui affichera le nombre de blcok en stock
    private int NbObjet = 0; // déclaration d une varible pour compter le nombre de cube dans la zone de stockage

    // Start is called before the first frame update    
    void Start()
    {
        UpdateStocke(); // appel de la méthode pour afficher le texte, donc le nombre de bloc en stock
    }

    private void OnTriggerEnter(Collider other)
    {
        NbObjet++; // ajoute un objet dans la zone de stockage
        UpdateStocke(); // appel de la méthode pour mettre à jour l'affichage
    }

    private void OnTriggerExit(Collider other)
    {
        NbObjet--; // supprime un objet dans la zone de stockage
        UpdateStocke(); // appel de la méhode pour mettre à jour l affichage
    }

    void UpdateStocke()
    {
        if (NbStocke != null) // si le texte existe, le mettre à jour
        {
            NbStocke.text = "Blocs " + NbObjet/2; // affichage du texte (suite à une duplication des collider entre les blocks et les zone de stockage la division par 2 permet d'obtenir le nombre réel de block dans la zone)
        }
    }
}

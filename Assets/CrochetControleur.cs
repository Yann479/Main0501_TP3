using UnityEngine;

public enum EtatCrochet { Fixe = 0, Positif = 1, Negatif = -1 }; // Comme dans FlecheControleur, représentation de l'état du crochet (fixe, en descente, en montée)

public class CrochetControleur : MonoBehaviour
{
    public EtatCrochet rotationEtat = EtatCrochet.Fixe;
    public float vitesse = 1.0f; // déclaration d'une variable public pour déterminer la vitesse de mouvement du crochet en descente/montée
    public float maxHeight = 10f; // déclaration d'une variable public pour la hauteur maximal du crochet
    public float minHeight = -10f; //déclaration d'une variable public pour la hauteur minimale du crochet (pour ne pas qu'il descende plus bas que le sol quand la grue est déployée au maximum)

    private ArticulationBody articulationBody;
    private float currentTarget = 0f; // position du crochet au début

    void Start()
    {
        articulationBody = GetComponent<ArticulationBody>(); // Récupération du composant de l'ArcticulationBody
        SetupArticulationDrive(); // appel de la méthode SetupArticulationDrive() pour faire le foncfiguration de l'ArticulationBody
    }

    void SetupArticulationDrive() // configuration des paramètres de mouvement du crochet
    {
        var drive = articulationBody.zDrive; // récupèration du zDrive de l'ArticulationBody
        drive.lowerLimit = minHeight; // récupération de la vitesse minimum du drive
        drive.upperLimit = maxHeight; // récupération de la vitesse maximal du drive
        articulationBody.zDrive = drive; // applications des modifications
    }

    void FixedUpdate() // mise à jour des mouvements du crochet
    {
        if (rotationEtat != EtatCrochet.Fixe) // si le crochet bouge
        {
            float movement = (float)rotationEtat * vitesse * Time.fixedDeltaTime; //calcule le mouvement du crochet
            currentTarget = Mathf.Clamp(currentTarget + movement, minHeight, maxHeight); // mise à jour de la position du crochet
            
            var drive = articulationBody.zDrive; // récupère le zDrive de l'articulationBody
            drive.target = currentTarget; // Mise à jour du drive
            articulationBody.zDrive = drive; // application de la mise à jour sur l'articulationBody
        }
    }
}

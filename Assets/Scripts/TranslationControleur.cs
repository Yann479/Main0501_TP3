using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//on d�finit ici les �tats de mouvement utilis� dans Translation Commande
//Fixe ne fait rien, Positif fait "avancer", Negatif fait "reculer"
public enum EtatTranslation { Fixe = 0, Positif = 1, Negatif = -1 };

public class TranslationControleur : MonoBehaviour
{
    //l'articulation est initialis�e en mode Fixe pour �tre "au repos"
    public EtatTranslation moveState = EtatTranslation.Fixe;
    //vitesse de translation par d�faut, public siginifie qu'elle peut �tre modifi�e dans l'inspecteur
    public float speed = 1.0f;

    private void FixedUpdate() //FixedUpdate est comme Update, mais synchronis� avec le moteur physique d'unity
    {
        if (moveState != EtatTranslation.Fixe)
        {
            ArticulationBody articulation = GetComponent<ArticulationBody>();

            //obtient la position du joint sur l'axe X ([0])
            float xDrivePostion = articulation.jointPosition[0];

            //change la position sur l'axe X
            float targetPosition = xDrivePostion + -(float)moveState * Time.fixedDeltaTime * speed;

            //donne l'ordre au joint de rejoindre la position d�finie par targetPosition
            var drive = articulation.xDrive;
            drive.target = targetPosition;
            articulation.xDrive = drive;
        }
    }
}

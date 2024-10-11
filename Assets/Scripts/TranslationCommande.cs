using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationCommande : MonoBehaviour
{
    public GameObject Translation;
    public string axe ;

    void Update() //envoie l'�tat de mouvement � TranslationControleur
    {
        float input = Input.GetAxis(axe);
        EtatTranslation moveState = MoveStateForInput(input);
        TranslationControleur controller = Translation.GetComponent<TranslationControleur>();
        controller.moveState = moveState;
    }

    //envoie dans quel �tat de mouvement l'articulation devrait �tre
    EtatTranslation MoveStateForInput(float input)
    {
        if (input > 0)
        {
            return EtatTranslation.Positif;
        }
        else if (input < 0)
        {
            return EtatTranslation.Negatif;
        }
        else
        {
            return EtatTranslation.Fixe;
        }
    }
}

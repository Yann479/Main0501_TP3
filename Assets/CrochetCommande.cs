using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrochetCommande : MonoBehaviour
{
    public GameObject Crochet;


    void Update()
    {
        float input = Input.GetAxis("Crochet");
        EtatCrochet rotationEtat = MoveStateForInput(input);
        CrochetControleur controller = Crochet.GetComponent<CrochetControleur>();
        controller.rotationEtat = rotationEtat;

        
    }

    EtatCrochet MoveStateForInput(float input)
    {
        if (input > 0)
        {
            return EtatCrochet.Positif;
        }
        else if (input < 0)
        {
            return EtatCrochet.Negatif;
        }
        else
        {
            return EtatCrochet.Fixe;
        }
    }
}

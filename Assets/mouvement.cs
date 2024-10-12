using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // gestion des déplacements de la grue via les flèches
     if (Input.GetKey(KeyCode.DownArrow)) // pour la flèche du bas
        {
            transform.Translate(0,1* -0.01f,0 ); //réaliser une translation sur l'axe des y afin de faire avant la grue, en multipliant la valeur de l axe des Y par une valeur négative
        }
        if (Input.GetKey(KeyCode.UpArrow)) // pour la flèche du haut
        {
            transform.Translate(0,1  * 0.01f,0 ); // réalisation d une translation toujours sur l axe des Y mais cette fois si, mon multipli la valeur par un nombre négatif pour faire un déplacement dans le sens inverse de la flèche du haut
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // pour la flèche de gauche
        {
            transform.Rotate(0,0,1 * -2); // multiplication de la valeur sur l axe des z par une valeur négative pour réaliser une rotation autour de cette axe
        }
         if (Input.GetKey(KeyCode.RightArrow)) // pour la flèche de droite
        {
            transform.Rotate(0,0,1 * 2); // multiplication de la valeur sur l'axe des Z par une valeur positive cette fois pour réaliser une rotation dans le sens opposé sur l axe des Z également
        }
    }
}

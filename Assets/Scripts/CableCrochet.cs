using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCrochet : MonoBehaviour
{

    public Transform startPoint; // déclare une variable pour le début du câble
    public Transform endPoint; // déclare une variable pour la fin du câble
    private LineRenderer lineRenderer; // déclare une variable  pour la configuration du câble en lui même 
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>(); // mise à jour de la taille (point de début et le point de fin du câble)
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, startPoint.position); // configure le position de départ
        lineRenderer.SetPosition(1, endPoint.position); // configure le position de fin
    }

}

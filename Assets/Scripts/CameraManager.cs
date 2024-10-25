using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras; // création d un tableau pour y insérer les divers caméras
    private int currentCameraIndex = 0; // index de la caméra en cour d utilisation (par défault la 0)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // en cas d'appuis sur le touche C
        {
            SwitchCamera(); // réaliser un appel de la méthode qui réalise le changement de caméra
        }
    }

    void SwitchCamera() // méthode pour réaliser le changement de caméra
    {
        cameras[currentCameraIndex].gameObject.SetActive(false); // désactiver la caméra actuelle, afin de toujours conserver une seul caméra active
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length; // incrémente l'index de la caméra actuelle
        cameras[currentCameraIndex].gameObject.SetActive(true); // réalise l activation de la nouvelle caméra actuelle
    }
}

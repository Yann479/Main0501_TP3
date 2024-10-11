using UnityEngine;

public enum EtatCrochet { Fixe = 0, Positif = 1, Negatif = -1 };

public class CrochetControleur : MonoBehaviour
{
    public EtatCrochet rotationEtat = EtatCrochet.Fixe;
    public float vitesse = 1.0f;
    public float maxHeight = 10f;
    public float minHeight = -10f;

    private ArticulationBody articulationBody;
    private float currentTarget = 0f;

    void Start()
    {
        articulationBody = GetComponent<ArticulationBody>();
        SetupArticulationDrive();
    }

    void SetupArticulationDrive()
    {
        var drive = articulationBody.zDrive;
        drive.stiffness = 10000f;
        drive.damping = 1000f;
        drive.forceLimit = 3.402823e+38f;
        drive.lowerLimit = minHeight;
        drive.upperLimit = maxHeight;
        articulationBody.zDrive = drive;
    }

    void FixedUpdate()
    {
        if (rotationEtat != EtatCrochet.Fixe)
        {
            float movement = (float)rotationEtat * vitesse * Time.fixedDeltaTime;
            currentTarget = Mathf.Clamp(currentTarget + movement, minHeight, maxHeight);
            
            var drive = articulationBody.zDrive;
            drive.target = currentTarget;
            articulationBody.zDrive = drive;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // en cas d'appuis sur la touche espace
        {
            Destroy(this.gameObject.GetComponent<FixedJoint>());// détruire la jointure réalisée avec le bloc, donc le lâcher
        }
    }

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.GetComponent<ArticulationBody>() != null) // vérification du fait que le grappin en bien en contact avec dans notre cas un block
        {
            FixedJoint joint = this.gameObject.AddComponent<FixedJoint>(); // crée une jointure entre le grappin et le block
            joint.connectedArticulationBody = Collision.articulationBody;
        }
    }
}

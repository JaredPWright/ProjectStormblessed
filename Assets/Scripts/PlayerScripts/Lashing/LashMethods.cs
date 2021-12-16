using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LashMethods
{
    //This namespace stores the lash classes. Just didn't want the clutter in my project folder. 
    public class ForwardLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[0];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = transform.forward;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[0] != 0)
                LashData.currentLashings[0]--;

            GetComponent<DirectionalLashing>().lashForces[0] -= lashForce;
            
            MovementBools.lashing = false;
            Destroy(this);
        }
    }

    public class BackwardLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[1];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = -transform.forward;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. 
            //The default max in a direction is 3.
            if(LashData.currentLashings[1] != 0)
                LashData.currentLashings[1]--;

            GetComponent<DirectionalLashing>().lashForces[1] -= lashForce;

            MovementBools.lashing = false;
            Destroy(this);
        }
    }

    public class RightLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[2];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = transform.right;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[2] != 0)
                LashData.currentLashings[2]--;

            GetComponent<DirectionalLashing>().lashForces[2] -= lashForce;

            MovementBools.lashing = false;
            Destroy(this);
        }
    }

    public class LeftLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[3];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = -transform.right;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[3] != 0)
                LashData.currentLashings[3]--;

            GetComponent<DirectionalLashing>().lashForces[3] -= lashForce;

            MovementBools.lashing = false;
            Destroy(this);
        }
    }

    public class UpLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[4];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = transform.up;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[4] != 0)
                LashData.currentLashings[4]--;

            GetComponent<DirectionalLashing>().lashForces[4] -= lashForce;

            MovementBools.lashing = false;
            Destroy(this);
        }
    }

    public class DownLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]float lashForce;
        PController pController;
        CharacterController characterController;
        Vector3 directionOfPull;
        
        void Start()
        {
            MovementBools.lashing = true;
            //Grab player CharacterController, the force of the lashings, and the raycast info. 
            lashForce = GetComponent<DirectionalLashing>().lashForces[5];
            pController = GetComponent<PController>();
            characterController = GetComponent<CharacterController>();
            directionOfPull = -transform.up;

            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void Update()
        {
            //New version- this adjusts the velocity of the character
            //controller midflight as opposed to adding opposing forces
            //directly. 
            //pController._velocity += directionOfPull * lashForce;
            characterController.Move(directionOfPull * lashForce * Time.deltaTime);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[5] != 0)
                LashData.currentLashings[5]--;

            GetComponent<DirectionalLashing>().lashForces[5] -= lashForce;

            MovementBools.lashing = false;
            Destroy(this);
        }
    }
}

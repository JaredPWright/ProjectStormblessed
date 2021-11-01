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
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        RaycastHit raycastHit;
        Vector3 directionOfPull;
        Animator animator;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[0];
            raycastHit = GetComponent<DirectionalLashing>().hits[0];
            
            directionOfPull = transform.forward;

            animator = GetComponentInParent<Animator>();
            animator.SetBool("flyForward", true);
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        { 
            //This throws the player in the opposite direction of the normal that the raycast returned.
            //It means that it's not always a "forward" pull. You might have attached to a surface that
            //is slightly slanted to the right. 
            rgdbdy.AddForce(directionOfPull * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[0] != 0)
                LashData.currentLashings[0]--;

            GetComponent<DirectionalLashing>().lashForces[0] -= lashForce;
            animator.SetBool("flyForward", false);

            Destroy(this);
        }
    }

    public class BackwardLash : MonoBehaviour
    {
        //This class handles forward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        Vector3 directionOfPull;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[0];
            directionOfPull = -transform.forward;
            
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        {
            //This throws the player in the opposite direction of the normal that the raycast returned.
            //This one is a bit more odd. It'll pull in the opposite direction of the camera, not the back
            //of the player model. 
            rgdbdy.AddForce(directionOfPull * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[0] != 0)
                LashData.currentLashings[0]--;

            GetComponent<DirectionalLashing>().lashForces[0] -= lashForce;

            Destroy(this);
        }
    }

    public class RightLash : MonoBehaviour
    {
        //This class handles rightward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        Transform playerTransform;
        Animator animator;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[4];
            playerTransform = GetComponentInParent<Transform>();

            animator = GetComponentInParent<Animator>();
            animator.SetBool("flyRight", true);
            
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        {
            //This throws the player towards their local "right". Basically the direction of their right side.
            //It is more consistent than the forward as it will pull to the actual right. This can be affected by rotation, though.
            rgdbdy.AddForce(transform.right * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[4] != 0)
                LashData.currentLashings[4]--;

            GetComponent<DirectionalLashing>().lashForces[4] -= lashForce;
            animator.SetBool("flyRight", false);

            Destroy(this);
        }
    }

    public class LeftLash : MonoBehaviour
    {
        //This class handles rightward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        Transform playerTransform;
        Animator animator;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[5];
            playerTransform = GetComponentInParent<Transform>();

            animator = GetComponentInParent<Animator>();
            animator.SetBool("flyLeft", true);
            
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        {
            //This throws the player towards their local "left". Basically the direction of their right side.
            //Like the right pull, it actually pulls to the left. This can be affected by rotation, though.
            rgdbdy.AddForce(-transform.right * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[5] != 0)
                LashData.currentLashings[5]--;

            GetComponent<DirectionalLashing>().lashForces[5] -= lashForce;
            animator.SetBool("flyLeft", false);

            Destroy(this);
        }
    }

    public class UpLash : MonoBehaviour
    {
        //This class handles upward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        Transform playerTransform;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[2];
            playerTransform = GetComponentInParent<Transform>();
            
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        {
            //This throws the player towards their local "up". Basically the direction of their head.
            //It will always pull to this direction though. It is not dependent on the normal of the 
            //raycast return.  
            rgdbdy.AddForce(transform.up * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[2] != 0)
                LashData.currentLashings[2]--;

            GetComponent<DirectionalLashing>().lashForces[2] -= lashForce; 

            Destroy(this);
        }
    }

    public class DownLash : MonoBehaviour
    {
        //This class handles upward Lashings. A new instance is generated on the
        //proper key press and destroys itself once its duration is over.
        [SerializeField]Rigidbody rgdbdy;
        [SerializeField]float lashForce;
        Transform playerTransform;
        
        void Start()
        {
            //Grab player Rigidbody, the force of the lashings, and the raycast info. 
            rgdbdy = GetComponentInParent<Rigidbody>();
            lashForce = GetComponent<DirectionalLashing>().lashForces[3];
            playerTransform = GetComponentInParent<Transform>();
            
            //Start the decay countdown.
            Invoke("Decay", 1.5f);
        }

        void FixedUpdate()
        {
            //This throws the player towards their local "up". Basically the direction of their head.
            //It will always pull to this direction though. It is not dependent on the normal of the 
            //raycast return.  
            rgdbdy.AddForce(-transform.up * lashForce, ForceMode.Impulse);
        }

        void Decay()
        {
            //Remove from the list of active lashings. The default max in a direction is 3.
            if(LashData.currentLashings[3] != 0)
                LashData.currentLashings[3]--;

            GetComponent<DirectionalLashing>().lashForces[3] -= lashForce; 

            Destroy(this);
        }
    }
}

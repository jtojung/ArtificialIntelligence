using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class Flee : SteeringBehaviour
    {
        public Transform target;
        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            if(target)
            {
                //get direction to target
                Vector3 direction = owner.transform.position - target.position;
                // normalize direction
                direction.Normalize();
                //Apply force
                force = direction * owner.maxSpeed;

            }
            return force; //return velocity
        }
    }
}

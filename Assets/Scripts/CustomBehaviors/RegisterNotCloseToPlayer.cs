using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("RegisterNotCloseToPlayer")]
    public class RegisterNotClose : GOAction
    {
        private FirstPersonController fpc;

        [InParam("closeDistance")]
        [Help("The maximun distance to consider that the target is close")]
        public float closeDistance;

        private UnityEngine.AI.NavMeshAgent navAgent;

        private Transform targetTransform;

        /// <summary>Initialization Method of MoveToGameObject.</summary>
        /// <remarks>Check if GameObject object exists and NavMeshAgent, if there is no NavMeshAgent, the default one is added.</remarks>
        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            Vector3 curPos = gameObject.transform.position;
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().transform.position;
            float mag = (curPos - playerPos).sqrMagnitude;
            if (mag > closeDistance * closeDistance)
            {
                GameObject.FindObjectOfType<RandomMap>().Free();
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}

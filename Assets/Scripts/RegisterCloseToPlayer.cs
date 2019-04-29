using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("RegisterCloseToPlayer")]
    public class RegisterClose : GOAction
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
            if ((gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().transform.position).sqrMagnitude < closeDistance * closeDistance)
            {
                Debug.Log("Close to player");
                GameObject.FindObjectOfType<RandomMap>().Capture();
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;           
        }
    }
}

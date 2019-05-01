using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/CustomPursueCybotAction")]
    [Help("Moves the game object towards a given target by using a NavMeshAgent")]
    public class CustomPursueCybotAction : GOAction
    {
        private UnityEngine.AI.NavMeshAgent navAgent;

        private Transform targetTransform;
        GameObject toChase;

        /// <summary>Initialization Method of MoveToGameObject.</summary>
        /// <remarks>Check if GameObject object exists and NavMeshAgent, if there is no NavMeshAgent, the default one is added.</remarks>
        public override void OnStart()
        {
            toChase = gameObject.GetComponent<NPCScript>().toChase;

            if(toChase == null)
            {
                Debug.LogWarning("The " + gameObject.name + " has a null object for which it wants to chase", gameObject);
                return;
            }
            targetTransform = toChase.transform;

            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (navAgent == null)
            {
                Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
                navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
            }
            navAgent.SetDestination(targetTransform.position);

#if UNITY_5_6_OR_NEWER
            navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif

            navAgent.speed = Mathf.Max(toChase.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed);

            navAgent.acceleration = navAgent.speed * 5;
        }

        /// <summary>Method of Update of MoveToGameObject.</summary>
        /// <remarks>Verify the status of the task, if there is no objective fails, if it has traveled the road or is near the goal it is completed
        /// y, the task is running, if it is still moving to the target.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
                return TaskStatus.COMPLETED;
            else if (navAgent.destination != targetTransform.position)
                navAgent.SetDestination(targetTransform.position);

            navAgent.speed = Mathf.Max(toChase.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed);

            navAgent.acceleration = navAgent.speed * 5;
            return TaskStatus.RUNNING;
        }
        /// <summary>Abort method of MoveToGameObject </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {
            navAgent.speed = Random.Range(3, 8);


#if UNITY_5_6_OR_NEWER
            if (navAgent != null)
                navAgent.isStopped = true;
#else
            if (navAgent!=null)
                navAgent.Stop();
#endif

        }
    }
}

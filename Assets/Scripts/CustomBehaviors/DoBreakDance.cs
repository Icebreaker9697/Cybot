using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/Dobreakdance")]
    public class DoBreakDance : GOAction
    {
        private FirstPersonController fpc;

        private UnityEngine.AI.NavMeshAgent navAgent;

        private Transform targetTransform;

        private Animator anim;

        float timePassed = 0;

        /// <summary>Initialization Method of MoveToGameObject.</summary>
        /// <remarks>Check if GameObject object exists and NavMeshAgent, if there is no NavMeshAgent, the default one is added.</remarks>
        public override void OnStart()
        {
            fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
            anim = gameObject.GetComponentInChildren<Animator>();

            targetTransform = fpc.transform;

            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (navAgent == null)
            {
                Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
                navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
            }

            navAgent.speed = 0;

            anim.SetBool("IsVictory", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }

        /// <summary>Method of Update of MoveToGameObject.</summary>
        /// <remarks>Verify the status of the task, if there is no objective fails, if it has traveled the road or is near the goal it is completed
        /// y, the task is running, if it is still moving to the target.</remarks>
        public override TaskStatus OnUpdate()
        {
            
            if (timePassed < 3)
            {
                // Code to go left here
                timePassed += Time.deltaTime;
                return TaskStatus.RUNNING;
            }
            return TaskStatus.COMPLETED;
        }
        /// <summary>Abort method of MoveToGameObject </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {

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

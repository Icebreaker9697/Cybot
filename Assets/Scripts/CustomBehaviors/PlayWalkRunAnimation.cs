using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("Animation/PlayWalkRunAnimation")]
    public class PlayWalkRunAnimation : GOAction
    {
        private UnityEngine.AI.NavMeshAgent navAgent;
        private Animator anim;

        private Transform targetTransform;

        /// <summary>Initialization Method of MoveToGameObject.</summary>
        /// <remarks>Check if GameObject object exists and NavMeshAgent, if there is no NavMeshAgent, the default one is added.</remarks>
        public override void OnStart()
        {

            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            anim = gameObject.GetComponentInChildren<Animator>();

            if(navAgent.speed > 0 && navAgent.speed < 8)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsIdle", false);
            } else if(navAgent.speed >= 8)
            {
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
            }
            else
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
            }
        }

        /// <summary>Method of Update of MoveToGameObject.</summary>
        /// <remarks>Verify the status of the task, if there is no objective fails, if it has traveled the road or is near the goal it is completed
        /// y, the task is running, if it is still moving to the target.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (navAgent.speed > 0 && navAgent.speed < 8)
            {
                anim.SetBool("IsWalking", true);
            }
            else if (navAgent.speed >= 8)
            {
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsIdle", true);
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

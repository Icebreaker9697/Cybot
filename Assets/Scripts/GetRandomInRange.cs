using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to obtain a random position of an area.
    /// </summary>
    [Action("Vector3/GetRandomInRange")]
    [Help("Gets a random position from a given area")]
    public class GetRandomInRange : GOAction
    {
        /// <summary>The Name property represents the GameObject Input Parameter that must have a BoxCollider or SphereColider.</summary>
        /// <value>The Name property gets/sets the value of the GameObject field, area.</value>
        [InParam("x")]
        public Vector2 minXmaxX { get; set; }

        [InParam("z")]
        public Vector2 minZmaxZ { get; set; }

        /// <summary>The Name property represents the Output Position randomly parameter taken from the area Parameter.</summary>
        /// <value>The Name property gets/sets the value of the Vector3 field, randomPosition.</value>
        [OutParam("randomPosition")]
        [Help("Position randomly taken from the area")]
        public Vector3 randomPosition { get; set; }

        /// <summary>Initialization Method of GetRandomInArea</summary>
        /// <remarks>Verify if there is an area, showing an error if it does not exist.Check that the area is a box or sphere to differentiate the
        /// calculations when obtaining the random position of those areas. Once differentiated, you get the limits of the area to calculate a
        /// random position.</remarks>
        public override void OnStart()
        {
            if (minXmaxX != null && minZmaxZ != null)
            {
                randomPosition = new Vector3(UnityEngine.Random.Range(minXmaxX.x, minXmaxX.y), 1, UnityEngine.Random.Range(minZmaxZ.x, minZmaxZ.y));
            }
            else
            {
                Debug.LogError("The paramaters are null", gameObject);
            }
        }

        /// <summary>Abort method of GetRandomInArea.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}

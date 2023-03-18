using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;

        float distanceTravelled;

        public float horizontalSpeed = 5;
        float horizontalValue;
        public float horizontalLimit = 2;


        public static PathFollower instance;


        private void Awake()
        {
            instance = this;
        }

        void Start() {
           
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (Input.GetButton("Right"))
            {
                horizontalValue += horizontalSpeed* Time.deltaTime;
            }

            else if (Input.GetButton("Left"))
            {
                horizontalValue -= horizontalSpeed * Time.deltaTime;
            }
            horizontalValue= Mathf.Clamp(horizontalValue, -horizontalLimit, horizontalLimit);

            if (pathCreator != null)
            {

                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.Rotate(0, 0, 90);
                transform.Translate(horizontalValue, 0, 0);
            }
            
        }

        public void ChangePath(PathCreator newPath)
        {
            pathCreator = newPath;
            distanceTravelled = 0;
        }


        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}
using UnityEngine;

public class DucklingMovement : MonoBehaviour
{
    public Transform follow;

    public float maxDistance = 1f;

    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // change this object position only if distance is greater than maxDistance
        float actualDistance = Vector3.Distance(transform.position, follow.position);
        if (actualDistance > maxDistance )
        {
            var followToCurrent = (transform.position - follow.position).normalized;
            followToCurrent.Scale(new Vector3(maxDistance, maxDistance, maxDistance));

            //set the new position
            transform.position = follow.position + followToCurrent;

            //Rotate..
            //Determine which direction to rotate towards
            Vector3 targetDirection = follow.position - transform.position;
            //The step size is equal to speed times frame time
            float singleStep = speed * Time.deltaTime;
            //Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            //Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}

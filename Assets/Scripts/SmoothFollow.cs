using UnityEngine;
using UnityEngine.UI;

public class SmoothFollow : MonoBehaviour
{
    #region Consts
    public float SMOOTH_TIME = 0.3f;
    #endregion

    #region Public Properties
    public int camRotation;
    public bool LockX;
    public bool LockY;
    public bool LockZ;
    public bool useSmoothing;
    public Transform target;
    public float distance;
    public float scrollSpeed;
    float factor;
    public float minDistance;
    public float maxDistance;
    float tempDistance;

 
    public float zoomWhenStoped;
    public float movingDistance;
    public float stopedDistance;
    public float timeToStopedZoom;
    public Transform lookTarget;

    #endregion

    #region Private Properties
    private Transform thisTransform;
    private Vector3 velocity;
    float speed;
    #endregion
    




    private void Awake()
    {
        factor = 1.75f;
        thisTransform = transform;
        velocity = new Vector3(0.5f, 0.5f, 0.5f);
        distance = maxDistance;

        movingDistance = distance;
        stopedDistance = distance * (100 - zoomWhenStoped) / 100;
    }

    void Start()
    {
        //Invoke("SelectSheep", 2);
        //Invoke("SelectBarn", 4);
        //Invoke("SelectDog", 1);
    }

 

    public void SetCamRotation(int value)
    {
        camRotation = value;
    }

    private void LateUpdate()
    {
        var newPos = Vector3.zero;

        if (useSmoothing)
        {
            newPos.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y + distance, ref velocity.y, SMOOTH_TIME);

            if (camRotation == 90)
            {
                newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, SMOOTH_TIME);
                newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x - distance / factor, ref velocity.x, SMOOTH_TIME);
            }
            else if (camRotation == 180)
            {
                newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, SMOOTH_TIME);
                newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z + distance / factor, ref velocity.z, SMOOTH_TIME);
            }
            else if (camRotation == 270)
            {
                newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, SMOOTH_TIME);
                newPos.x = (Mathf.SmoothDamp(thisTransform.position.x, target.position.x + distance / factor, ref velocity.x, SMOOTH_TIME));
            }
            else if (camRotation == 0)
            {
                newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, SMOOTH_TIME);
                newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z - distance / factor, ref velocity.z, SMOOTH_TIME);
            }

           // transform.LookAt(lookTarget);
        }
        #region Locks
        if (LockX)
        {
            newPos.x = thisTransform.position.x;
        }

        if (LockY)
        {
            newPos.y = thisTransform.position.y;
        }

        if (LockZ)
        {
            newPos.z = thisTransform.position.z;
        }
        #endregion

       transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
       
    }

    public void SetZoomMin(Slider value)
    {
        minDistance = value.value;
        if (distance < minDistance)
            distance = minDistance;

        movingDistance = distance;
        stopedDistance = distance * (100 - zoomWhenStoped) / 100;
    }

    public void SetZoomMax(Slider value)
    {
        maxDistance = value.value;
        if (distance > maxDistance)
            distance = maxDistance;

        movingDistance = distance;
        stopedDistance = distance * (100 - zoomWhenStoped) / 100;
    }

    public void SetSmoothTime(Slider value)
    {
        SMOOTH_TIME = value.value;
    }

    bool isStoped = false;
    
   
    public void changeCameraVelocity(float _velocity)
    {
        velocity *= _velocity;
        SMOOTH_TIME /= _velocity;
    }
}


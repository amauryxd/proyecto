using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehaviour : MonoBehaviour
{
    public Transform[] points;
    public Transform shootPoint;
    public GameObject arrowPrefab;

    public float bowCompression;    //Que tanto se comprime el arco(0.75)
    public float arrowMaxSpeed;     //Rapidez maxima de la flecha (50)
    public float arrowMaxDisplacement; //Desplazamiento maximo de la flecha (0.5)
    public float pullSpeed;         //Que tan rapido se tensa el arco (1)
    public float releaseSpeed;      //que tan rapudo se denstensa el arco(30)

    bool aplyingTension;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
        GetComponent<LineRenderer>().positionCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        DrawChord();

        if (Input.GetMouseButtonDown(0))
        {
            aplyingTension = true;
            SetArrow();
        }

        if (aplyingTension)
            PullArrow();
        else
            ReleaseArrow();

        if (Input.GetMouseButtonUp(0))
        {
            aplyingTension = false;
            FireArrow();
        }
    }

    void DrawChord()
    {
        Vector3[] pointPositions = new Vector3[] {points[0].position,
                                                  points[1].position,
                                                  points[2].position};

        GetComponent<LineRenderer>().SetPositions(pointPositions);
    }

    void SetArrow()
    {
        arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        arrow.GetComponent<KinematicArrow>().shootPoint = shootPoint;
    }

    void PullArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = new Vector3(0, 0, -arrowMaxDisplacement);
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, pullSpeed * dt);

        Vector3 newScale = new Vector3(bowCompression, 1, 1);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, pullSpeed * dt);
    }

    void ReleaseArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, releaseSpeed * dt);

        Vector3 newScale = Vector3.one;
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, releaseSpeed * dt);
    }

    void FireArrow()
    {
        float normArrowDisplacement = points[1].localPosition.magnitude / arrowMaxDisplacement;
        arrow.GetComponent<KinematicArrow>().P0 = shootPoint.position;
        arrow.GetComponent<KinematicArrow>().V0 = arrowMaxSpeed * normArrowDisplacement * shootPoint.forward;
        arrow.GetComponent<KinematicArrow>().fired = true;
        arrow.GetComponent<TrailRenderer>().emitting = true;
    }
}

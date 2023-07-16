using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrail : MonoBehaviour
{

    public LineRenderer trailPrefab;

    public Camera cam;

    public float clearSpeed = 1;

    public float distanceFromCamera = 1;

    private LineRenderer currentTrail;
    public List<Vector3> points = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyCurrentTrail();
            CreateCurrentTrail();
            AddPoint();
        }

        if (Input.GetMouseButton(0))
        {
            AddPoint();
        }

        UpdateTrailPoints();

        ClearTrailPoints();
    }

    void DestroyCurrentTrail()
    {
        if(currentTrail != null)
        {
            Destroy(currentTrail.gameObject);
            currentTrail = null;
            points.Clear();
        }
    }

    void UpdateTrailPoints()
    {
        if (currentTrail != null && points.Count > 1)
        {
            currentTrail.positionCount = points.Count;
            currentTrail.SetPositions(points.ToArray());
        }
        else
        {
            DestroyCurrentTrail();
        }
    }

    void ClearTrailPoints()
    {
        float clearDistance = Time.deltaTime * clearSpeed;
        while (points.Count > 1 && clearDistance > 0)
        {
            float distance = (points[1] - points[0]).magnitude;
            if (clearDistance > distance)
            {
                points.RemoveAt(0);
            }
            else
            {
                points[0] = Vector3.Lerp(points[0], points[1], clearDistance / distance);
            }
            clearDistance -= distance;
        }
    }

    void CreateCurrentTrail()
    {
        currentTrail = Instantiate(trailPrefab);
        currentTrail.transform.SetParent(transform, true);
    }

    private void AddPoint()
    {
        Vector3 mousePosition = Input.mousePosition;
        points.Add(cam.ViewportToWorldPoint(new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, distanceFromCamera)));
    }

    private void OnDisable()
    {
        DestroyCurrentTrail();
    }
}

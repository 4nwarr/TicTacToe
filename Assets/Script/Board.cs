using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public bool[,] crossBoard = new bool[3, 3];
    public bool[,] circleBoard = new bool[3, 3];
    [SerializeField] private GameObject square, circle;
    private Collider2D boxCollider;
    [SerializeField] Material lineMaterial;
    bool canPlay = true;

    private void Start()
    {
        boxCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && canPlay)
        {
            TouchClick();
        }
    }

    private void TouchClick()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        if (boxCollider.OverlapPoint(touchPos))
        {
            PlaceImage(touchPos);
        }
    }

    void PlaceImage(Vector2 touchPos)
    {
        int intXTouchPos = Mathf.RoundToInt(touchPos.x);
        int intYTouchPos = Mathf.RoundToInt(touchPos.y);

        if (IsEmptyPlace(intXTouchPos, intYTouchPos))
        {
            if (GameManager.Instance.currentTurn == GameManager.Turn.circle)
            {
                FillMatrix(circleBoard, intXTouchPos, intYTouchPos, circle);
            }
            else
            {
                FillMatrix(crossBoard, intXTouchPos, intYTouchPos, square);
            }

            FindObjectOfType<UIManager>().SwapPlayer();
        }
    }

    void FillMatrix(bool[,] matrix, int x, int y, GameObject obj)
    {
        matrix[x, y] = true;
        Instantiate(obj, new Vector2(x, y), transform.rotation);

        if (Validation.isTris(matrix) != null)
        {
            canPlay = false;
            DrawLine(Validation.isTris(matrix));
        }

        GameManager.Instance.SwapTurn();
    }

    bool IsEmptyPlace(int x, int y)
    {
        if (crossBoard[x, y])
            return false;
        if (circleBoard[x, y])
            return false;

        return true;
    }

    void DrawLine(Vector2[] linePoints)
    {
        Vector2 startPoint = linePoints[0];
        Vector2 endPoint = linePoints[1];

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        Color myColor = new Color(0.3f, 0.3f, 0.3f);
        lineRenderer.material = lineMaterial;
        lineRenderer.startColor = myColor;
        lineRenderer.endColor = myColor;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.numCornerVertices = 10;
        lineRenderer.numCapVertices = 10;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);

        StartCoroutine(AnimateLine(lineRenderer));
    }

    IEnumerator AnimateLine(LineRenderer line)
    {
        float startTime = Time.time, animationDuration = 0.4f;

        Vector2 startPoint = line.GetPosition(0);
        Vector2 endPoint = line.GetPosition(1);

        Vector2 pos = startPoint;
        while (pos != endPoint)
        {
            float t = (Time.time - startTime) / animationDuration;
            pos = Vector2.Lerp(startPoint, endPoint, t);
            line.SetPosition(1, pos);
            yield return null;
        }
    }
}

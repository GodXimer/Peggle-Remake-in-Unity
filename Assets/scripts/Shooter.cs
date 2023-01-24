using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //// Start is called before the first frame update

    //[SerializeField] private Ball ballPrefab;
    //[SerializeField] private float speed;
    //[SerializeField] private bool canShoot = true;
    //[SerializeField] private Transform ballSpawn;

    //public bool reset;

    //Vector2 mousePosition;
    //Vector2 shootDirection;
    //Vector2 shootVector;

    //[SerializeField] private Prediction prediction;

    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (canShoot)
    //    {
    //        Vector2 ballSpawnVector = new Vector2(ballSpawn.transform.position.x, ballSpawn.transform.position.y);
    //        shootDirection = (mousePosition - ballSpawnVector).normalized;
    //        shootVector = shootDirection * speed;

    //        prediction.SimulatreTrajectory(ballPrefab, shootDirection, shootVector);

    //        if (Input.GetMouseButton(0))
    //        {
    //            GetMousePos();

    //            ballPrefab.Init(shootVector, false);
    //            canShoot = false;
    //        }
    //    }

    //    if (reset) { ResetShoot(); reset = false; }
    //}

    //void GetMousePos()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //public void ResetShoot()
    //{
    //    ballPrefab.gameObject.SetActive(false);
    //    Debug.Log("Reset!");
    //    ballPrefab.gameObject.transform.position = transform.position;
    //    canShoot = true;
    //}
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{
    [SerializeField] private int actualScore;
    [SerializeField] private Rigidbody2D _rb;
    private bool _isGhost;
    [SerializeField] private Transform resetPosition;
    [SerializeField] private float timer;
    [SerializeField] private float counter = 3;
    [SerializeField] private Cannon cannon;
    [SerializeField] private Material hittedMaterial;

    public void Init(Vector2 velocity, bool isGhost)
    {
        _isGhost = isGhost;
        _rb.velocity = new Vector2(velocity.x, velocity.y);

        timer = counter;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_isGhost) return;

        if (col.collider.tag == "Obstacle")
        {
            PegsManager.HittedPeg(col);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isGhost) return;

        if (collision.tag == "ResetBall")
        {
            ResetShoot();
        } 
        else if (collision.tag == "Hole")
        {
            cannon.AddBall();
            ResetShoot();
            SoundManager.PlayRandomHole();
        }
    }

    private void Update()
    {
        if (!_isGhost && !Cannon.canShoot && _rb.velocity.magnitude < 3)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                PegsManager.RemoveSelectedPegs();
        }
        else timer = counter;
    }

    public void ResetBall()
    {
        transform.position = resetPosition.position;
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0f;
        _rb.rotation = 0f;
        Cannon.canShoot = true;
    }

    //private void DestroyObstacles()
    //{
    //    //foreach (var obj in gameObjects)
    //    //{
    //    //    _prediction.Obstacles[obj.name + "(Clone)"].SetActive(false);
    //    //    obj.SetActive(false);
    //    //    destroyedPeg++;
    //    //    PegsManager.RemovePegFrom(obj.transform);
    //    //}

    //    //gameObjects.Clear();
    //}

    public void ResetShoot()
    {        
        //TextManager.SendText("Resetted ball");
 
        ResetBall();
        PegsManager.RemoveSelectedPegs();

        if (PegsManager.PointPegs.Count == 0)
        {
            TextManager.SendText("Congratulations, you win!! :)",60);
        }
        else if(cannon.LeftBalls < 1)
        {
            TextManager.SendText("You lose, press R to reset!! :(", 60);
        }
    }
}
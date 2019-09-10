using UnityEngine;

public class CardChainMove : MonoBehaviour
{
    private Vector2 _targetPos;
    public float _inc;
    public float _speed;
    private float _timer;
    public float Timer;
    public bool MovementOff;
    private void Start()
    {
        MovementOff = true;
    }
    private void FixedUpdate()
    {
        MoveBlock();
    }

    void MoveBlock()
    {
        if (_timer <= 0)
        {
            Move();
            _timer = Timer;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    void Move()
    {
        if (MovementOff)
        {
            _targetPos = new Vector2(transform.position.x, transform.position.y - _inc);
            transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        }
    }

}

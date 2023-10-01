using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyAnimator _enemyAnimator;
    private Transform _target;

    private void Start()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        _enemyAnimator.Move(_speed);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        Flip();
    }

    public void GetTarget(Transform target)
    {
        _target = target;
    }

    private void Flip()
    {
        if (transform.position.x <= _target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x >= _target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
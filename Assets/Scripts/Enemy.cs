using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public readonly int Run = Animator.StringToHash(nameof(Run));

    private Animator _animator;
    private Transform _target;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.Play(Run);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        Flip();
    }

    public void SetDirection(Transform target)
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
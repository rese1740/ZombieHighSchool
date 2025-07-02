using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 2f;
    private Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Job"))
        {
            JobType jobType = collision.GetComponent<JobType>();
            SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
            if (jobType != null)
            {
                switch (jobType.job)
                {
                    case PlayerJob.Archer:
                        PlayerSO.Instance.playerJob = PlayerJob.Archer;
                        break;
                    case PlayerJob.Medic:
                        PlayerSO.Instance.playerJob = PlayerJob.Medic;
                        break;
                    case PlayerJob.ChairMan:
                        PlayerSO.Instance.playerJob = PlayerJob.ChairMan;
                        break;
                    case PlayerJob.FireMan:
                        PlayerSO.Instance.playerJob = PlayerJob.FireMan;
                        break;
                }
                // ������ ���õ� ���� �ִٸ� ������� �ʱ�ȭ
                if (PlayerSO.Instance.lastSelectedRenderer != null)
                {
                    PlayerSO.Instance.lastSelectedRenderer.color = Color.white;
                }

                PlayerSO.Instance.playerJob = jobType.job;
                spriteRenderer.color = Color.gray;

                PlayerSO.Instance.lastSelectedRenderer = spriteRenderer;

                Destroy(gameObject);
            }
        }
    }
}

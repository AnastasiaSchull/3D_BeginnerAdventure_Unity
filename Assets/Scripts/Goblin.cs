using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour, IDamageble
{
    [SerializeField] private ParticleSystem damageEffect; 
    [SerializeField] private NavMeshAgent agent; 
    [SerializeField] private float health = 100f; 
    [SerializeField] private float huntStartDistance = 10f; 
    [SerializeField] private float attackDistance = 2f; 
    [SerializeField] private float attackCooldown = 1f; // задержка между атаками

    [SerializeField] private AudioClip runSound; 
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip deathSound; 
    private AudioSource audioSource;

    private Transform target; // цель

    private Transform player;
    private Animator animator;
    private float lastAttackTime = 0f;

    private bool isDead = false;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (isDead) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
       
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
       

        if (distanceToPlayer <= huntStartDistance)
        {
            // гоблин начинает погоню
            animator.SetBool("isHunting", true);
            agent.SetDestination(player.position);
            if (!audioSource.isPlaying)
            {
                PlaySound(runSound); 
            }

            // игрок в радиусе атаки, атакуем
            if (distanceToPlayer <= attackDistance)
            {
                TryAttackPlayer();
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            // останавливаем гоблина, если игрок далеко
            //animator.SetBool("isHunting", false);
            //agent.SetDestination(transform.position);

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            MoveToMainTarget();
        }
    }

    private void TryAttackPlayer()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            // вкл атаку
            animator.SetBool("isAttacking", true);
            PlaySound(attackSound);
            //находится ли игрок в радиусе атаки
            Collider[] hits = Physics.OverlapSphere(transform.position, attackDistance);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Debug.Log("Goblin attacks the player!");        
                    //урон игроку
                    hit.GetComponent<PlayerHealth>()?.TakeDamage(10);
                }
            }
            StartCoroutine(ResetAttack());
        }
    }

    // Reset анимацию атаки
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1f); 
        animator.SetBool("isAttacking", false);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            Debug.Log($"Playing sound: {clip.name}");
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Audio clip is missing!");
        }
    }

    public void ApllyDamage(float value)
    {
        if (isDead) return;
        health -= value;

        // эффект урона
        if (damageEffect != null)
        {
            damageEffect.Play();
        }

        // умер ли гоблин
        if (health <= 0)
        {        
            Die();           
        }
    }
    private void Die()
    {
        if (isDead) return; 
        isDead = true;
       
        PlaySound(deathSound);
        // устанавливаем анимацию смерти
        animator.SetBool("isDead", true);
        // чтобы он перестал двигаться
        agent.enabled = false;

        if (agent.enabled)
        {
            agent.ResetPath(); 
            agent.enabled = false;
        }

        GetComponent<Collider>().enabled = false;
      
        // удаляем гоблина 
        StartCoroutine(RemoveAfterDeath());
    }

    private IEnumerator RemoveAfterDeath()
    {
        // ждем окончания анимации смерти
        yield return new WaitForSeconds(5f);       
        Destroy(gameObject);
    }

    private void MoveToMainTarget()
    {
        animator.SetBool("isHunting", true);

        if (target != null)
        {
            agent.SetDestination(target.position); //  к основной цели
        }

        if (!audioSource.isPlaying)
        {
           // PlaySound(runSound); // звук бега
        }
    }

}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform jogador;
    public float suavizacao = 0.1f;
    public Vector3 offset;
    private Vector3 velocidade = Vector3.zero;

    void LateUpdate()
    {
        Vector3 destino = new Vector3(jogador.position.x, transform.position.y, transform.position.z) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidade, suavizacao);
    }
}

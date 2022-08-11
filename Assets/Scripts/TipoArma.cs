using UnityEngine;

[CreateAssetMenu(fileName = "NuevoTipoArma", menuName = "TipoArma")]
public class TipoArma : ScriptableObject
{
    public bool automatica;
    public int cargador;
    public float fireRate;
    public float tiempoRecarga;
}

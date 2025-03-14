using UnityEngine;

[CreateAssetMenu(fileName = "Scr_Scriptable_PlayerSettings", menuName = "Scriptable Objects/Scr_Scriptable_PlayerSettings")]
public class Scr_SO_PlayerInformations : ScriptableObject
{
    [Header("Movement Settings")] 
        [SerializeField] private float _maxSpeed = 8f;
        [SerializeField] private float _acceleration = 20f;
        [SerializeField] private float _friction = 15f;
        
        [SerializeField] private float _gravity = 25f;
    
    
        public float MaxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }
    
        public float Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }
    
        public float Friction
        {
            get { return _friction; }
            set { _friction = value; }
        }
        
        public float Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }
}

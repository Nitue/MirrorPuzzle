using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class Photon : MonoBehaviour, INotifyPropertyChanged {

        private float wavelength;
        private Color currentColor = Color.black;
        private Vector3 velocity;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler OnDeath;

        public float Wavelength
        {
            get { return wavelength; }
            set
            {
                if(value != wavelength)
                {
                    wavelength = value;
                    DetermineColor();
                    NotifyPropertyChanged("Wavelength");
                }
            }
        }

        public Color Color
        {
            get
            {
                if (currentColor == Color.black) DetermineColor();
                return currentColor;
            }
        }

        public Vector3 Velocity
        {
            get { return velocity; }
            set
            {
                if (value != velocity)
                {
                    velocity = value;
                }
            }
        }

        void Start()
        {
            DetermineColor();
        }

        void Update()
        {
            if(Velocity.magnitude > 0)
            {
                transform.position += velocity * Time.deltaTime;
            }
        }

        private void DetermineColor()
        {
            currentColor = Util.GetColor(Wavelength);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Kill()
        {
            if (OnDeath != null) OnDeath(this, new EventArgs());
            Destroy(gameObject);
        }
    }
}

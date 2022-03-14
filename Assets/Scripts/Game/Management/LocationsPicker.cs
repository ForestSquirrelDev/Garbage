using System;
using System.Collections.Generic;
using Game.Car;
using UnityEngine;

namespace Game.Management {
    public class LocationsPicker : MonoBehaviour {
        [SerializeField] private List<LocationData> _locationDatas = new List<LocationData>();
        [SerializeField] private CarController _player;
        [SerializeField] private Transform _camera;

        public void PickLocation(LocationType type) {
            var location = _locationDatas.Find(location => {
                if (location.Type != type) {
                    location.Parent.SetActive(false);
                    return false;
                }
                location.Parent.SetActive(true);
                return true;
            });
            
            _player.transform.position = location.PlayerPos;
            _player.transform.rotation = Quaternion.Euler(location.PlayerRotation);
            _player.ResetVelocity();
            _player.Reviver.ResetInitialTransformData();
            
            _camera.rotation = Quaternion.Euler(location.CameraRotation);
            _camera.position = location.CameraPos;
        }
    }

    [Serializable]
    public struct LocationData {
        public GameObject Parent;
        public LocationType Type;
        public Vector3 PlayerPos;
        public Vector3 PlayerRotation;
        public Vector3 CameraPos;
        public Vector3 CameraRotation;
    }

    public enum LocationType {
        Sprint,
        Drift,
        Mountains,
        Lake
    }
}
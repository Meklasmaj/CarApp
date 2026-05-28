using CarApp.Core.Models;
using CarApp.Core.Persistence;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CarApp.Wpf.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private readonly ICarRepository _repository;

        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
                (UpdateCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCarCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private string _searchPlate;
        public string SearchPlate
        {
            get => _searchPlate;
            set { _searchPlate = value; OnPropertyChanged(nameof(SearchPlate)); }
        }

        public ICommand AddCarCommand { get; }
        public ICommand FindCarCommand { get; }
        public ICommand UpdateCarCommand { get; }
        public ICommand DeleteCarCommand { get; }

        public CarViewModel(ICarRepository repository)
        {
            _repository = repository;
            Cars = new ObservableCollection<Car>(_repository.GetAll());
            Cars.Add(new FuelCar("Mazda", "3", DateTime.Now.Year, "LD12345", 0, 0, 0, false, FuelType.Benzin, 0));
            Cars.Add(new FuelCar("Ford", "S-Max", DateTime.Now.Year, "DE47803", 0, 0, 0, false, FuelType.Benzin, 0));
            Cars.Add(new FuelCar("Kia", "EV7", DateTime.Now.Year, "AD14532", 0, 0, 0, false, FuelType.Benzin, 0));
            Cars.Add(new FuelCar("Mercedes", "e320", DateTime.Now.Year, "CD45892", 0, 0, 0, false, FuelType.Benzin, 0));
            SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 0, 0, 0, false, FuelType.Benzin, 0);


            AddCarCommand = new RelayCommand(_ => AddCar(), _ => CanAddCar());
            FindCarCommand = new RelayCommand(_ => FindCar(), _ => !string.IsNullOrWhiteSpace(SearchPlate));
            UpdateCarCommand = new RelayCommand(_ => UpdateCar(), _ => CanUpdateOrDelete());
            DeleteCarCommand = new RelayCommand(_ => DeleteCar(), _ => CanUpdateOrDelete());
        }

        // ── I skal implementere disse fire metoder ────────────

        private bool CanAddCar()
        {
            // TODO: Returner true hvis SelectedCar ikke er null og
            //       LicensePlate, Brand og Model ikke er tomme
            return SelectedCar != null &&
                   !string.IsNullOrWhiteSpace(SelectedCar._brand) &&
                   !string.IsNullOrWhiteSpace(SelectedCar._model) &&
                   !string.IsNullOrWhiteSpace(SelectedCar._licensePlate);
        }

        private void AddCar()
        {
            // TODO: Tilføj SelectedCar til _repository og til Cars-listen
            // TODO: Nulstil SelectedCar til en ny tom FuelCar

            _repository.Add(SelectedCar);
            Cars.Add(SelectedCar);
            SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 0, 0, 0, false, FuelType.Benzin, 2000);

        }

        private void FindCar()
        {
            // TODO: Brug _repository.GetByLicensePlate(SearchPlate)
            // TODO: Hvis fundet: sæt SelectedCar = fundet bil, ryd SearchPlate
            // TODO: Hvis ikke fundet: vis MessageBox.Show("Bil ikke fundet")

                Car found = _repository.GetByLicensePlate(SearchPlate);
                if (found != null)
                {
                    SelectedCar = found;
                    SearchPlate = string.Empty;
                }
                else
                {
                    MessageBox.Show("Bil ikke fundet");
                }
        }

        private bool CanUpdateOrDelete()
        {
            // TODO: Returner true hvis SelectedCar har en ikke-tom LicensePlate
            return SelectedCar != null && !string.IsNullOrWhiteSpace(SelectedCar._licensePlate);
        }

        // ── Disse to metoder får I i Øvelse 6 ──────────────
        private void UpdateCar()
        {
            _repository.Update(SelectedCar);
            RefreshCarList();
        }

        private void DeleteCar()
        {
            var result = MessageBox.Show(
                $"Vil du slette {SelectedCar._brand} {SelectedCar._model}?",
                "Bekræft sletning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _repository.Delete(SelectedCar._licensePlate);
                Cars.Remove(SelectedCar);
                SelectedCar = new FuelCar("", "", DateTime.Now.Year, "", 0, 0, 0, false, FuelType.Benzin, 2000);
            }
        }


        private void RefreshCarList()
        {
            Cars.Clear();
            foreach (var car in _repository.GetAll())
                Cars.Add(car);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

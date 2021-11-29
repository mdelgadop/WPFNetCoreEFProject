using Application.Dtos;
using Application.Factories.Services;
using Application.Services;
using MDP_WPFNetCoreProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDP_WPFNetCoreProject.ViewModels
{
    public class CountryViewModel : ViewModelBase
    {
        #region Properties

        private ICountryService _service;
        private ICountryService Service
        {
            get
            {
                if (_service == null)
                    _service = CountryServiceFactory.Create();
                return _service;
            }
        }

        private IList<CountryDto> _countryList;
        public IList<CountryDto> CountryList
        {
            get
            {
                if (_countryList == null)
                {
                    _countryList = Service.GetAll().OrderBy(c => c.Id).ToList();
                }

                return _countryList;
            }
        }

        private CountryDto _selectedCountry;
        public CountryDto SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                UpdateSelectedCountry();
            }
        }

        public int? SelectedRegion
        {
            get { return (SelectedCountry == null || SelectedCountry.Region == null) ? (int?)null : SelectedCountry.Region.Id; }
            set
            {
                SelectedCountry.Region = !value.HasValue ? null : RegionList.Where(r => r.Id == value.Value).FirstOrDefault();
                OnPropertyChanged("SelectedRegion");
            }
        }

        public int? SelectedContact
        {
            get { return (SelectedCountry == null || SelectedCountry.Contact == null) ? (int?)null : SelectedCountry.Contact.Id; }
            set
            {
                SelectedCountry.Contact = !value.HasValue ? null : ContactList.Where(r => r.Id == value.Value).FirstOrDefault();
                OnPropertyChanged("SelectedContact");
            }
        }

        public int? SelectedBackupContact
        {
            get { return (SelectedCountry == null || SelectedCountry.BackupContact == null) ? (int?)null : SelectedCountry.BackupContact.Id; }
            set
            {
                SelectedCountry.BackupContact = !value.HasValue ? null : ContactList.Where(r => r.Id == value.Value).FirstOrDefault();
                OnPropertyChanged("SelectedBackupContact");
            }
        }

        private IList<RegionDto> _regionList;
        public IList<RegionDto> RegionList
        {
            get
            {
                if (_regionList == null)
                {
                    _regionList = Service.GetAllRegions().ToList();
                }

                return _regionList;
            }
        }

        private IList<ContactDto> _contactList;
        public IList<ContactDto> ContactList
        {
            get
            {
                if (_contactList == null)
                {
                    _contactList = Service.GetAllContacts().ToList();
                }

                return _contactList;
            }
        }

        #endregion

        #region Commands

        public ICommand CreateCountry { get; set; }

        public ICommand DeleteCountry { get; set; }

        public ICommand SaveCountry { get; set; }

        public ICommand CreateDataExample { get; set; }

        #endregion Commands

        public CountryViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CreateCountry = new RelayCommand(o => CreateCountryClick(null));
            DeleteCountry = new RelayCommand(o => DeleteCountryClick(null));
            SaveCountry = new RelayCommand(o => SaveCountryClick(null));
            CreateDataExample = new RelayCommand(o => CreateDataExampleClick(null));
        }

        #region Commands Click

        #region Create Country

        private void CreateCountryClick(object sender)
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(CreateCountryClickThread);
            thread1.Start();
        }

        private void CreateCountryClickThread()
        {
            try
            {
                SelectedCountry = CountryDtoFactory.Create();
                UpdateSelectedCountry();
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        #endregion Create Country

        #region Delete Country

        private void DeleteCountryClick(object sender)
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(DeleteCountryClickThread);
            thread1.Start();
        }

        private void DeleteCountryClickThread()
        {
            try
            {
                _service.Delete(_selectedCountry.Id);
                SelectedCountry = null;

                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }

        #endregion Delete Country

        #region Save Country

        private void SaveCountryClick(object sender)
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(SaveCountryClickThread);
            thread1.Start();
        }

        private void SaveCountryClickThread()
        {
            try
            {
                if (SelectedCountry.Id != 0)
                {
                    SelectedCountry = _service.Update(SelectedCountry.Id, SelectedCountry);
                }
                else
                {
                    SelectedCountry = Service.Create(SelectedCountry);
                }

                UpdateSelectedCountry();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }

        #endregion Save Country

        #region Create Data Example

        private void CreateDataExampleClick(object sender)
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(CreateDataExampleClickThread);
            thread1.Start();
        }

        private void CreateDataExampleClickThread()
        {
            try
            {
                Service.GenerateExampleData();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        #endregion Create Data Example

        #endregion Commands Click

        #region Private methods

        private void UpdateList()
        {
            _countryList = null;
            _regionList = null;
            _contactList = null;
            OnPropertyChanged("CountryList");
            OnPropertyChanged("RegionList");
            OnPropertyChanged("ContactList");
        }

        private void UpdateSelectedCountry()
        {
            OnPropertyChanged("SelectedCountry");
            OnPropertyChanged("SelectedRegion");
            OnPropertyChanged("SelectedContact");
            OnPropertyChanged("SelectedBackupContact");
        }

        #endregion Private methods

    }
}

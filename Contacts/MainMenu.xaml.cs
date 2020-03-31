using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Contacts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
  
    public sealed partial class MainPage : Page
    {


        public ObservableCollection<Person> listPeople = new ObservableCollection<Person>();
        private int Index;
        private int HeightLbx = 500;
        Person SelectedPerson;
        public MainPage()
        {
            
            this.InitializeComponent();
            SelectedPerson =new Person("Jan", "Kowalski", "Biała Podlaska");
            SelectedPerson.ProfileImage = "Assets\\pobrane.jpg";
            listPeople.Add(SelectedPerson);
            
            lbxPersons.ItemsSource = listPeople;
            lbxPersons.SelectedIndex=listPeople.Count-1;
            lbxPersons.MaxHeight = HeightLbx;
            this.MaxHeight = HeightLbx;
        }
        private void AddNewPerson(object sender, RoutedEventArgs e)
        {
         
            listPeople.Add(new Person(tbxName.Text, tbxSurname.Text, tbxCity.Text));
            lbxPersons.SelectedIndex = (listPeople.Count-1);
            
        }
        private void RemovePerson(object sender, RoutedEventArgs e)
        {
           Index= lbxPersons.SelectedIndex;
            if (Index>=0)
            {
                listPeople.RemoveAt(Index);
                lbxPersons.SelectedIndex = (listPeople.Count - 1);
            }
        }
        private void ModCurrPerson(object sender, RoutedEventArgs e)
        {
            SelectedPerson = (Person)lbxPersons.SelectedItem;
            SelectedPerson.Name = tbxName.Text;
            SelectedPerson.Surname = tbxSurname.Text;
            SelectedPerson.City = tbxCity.Text;

        }
        private async void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            SelectedPerson = (Person)lbxPersons.SelectedItem;

            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(Details), SelectedPerson);
                Window.Current.Content = frame;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private  void AddImageProfile(object sender, RoutedEventArgs e)
        {
            /* var picker = new Windows.Storage.Pickers.FileOpenPicker();
             picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
             picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
             picker.FileTypeFilter.Add(".jpg");
             picker.FileTypeFilter.Add(".jpeg");
             picker.FileTypeFilter.Add(".png");

             Windows.Storage.StorageFile storageFile = await picker.PickSingleFileAsync();
             Windows.Storage.StorageFile file = storageFile;
             if (file != null)
             {

             }

              // do xaml
              <AppBarButton Icon="Add"  HorizontalAlignment="Right" Click="AddImageProfile"/>
              */
        }

        private void AddPerson_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            addPerson.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void AddPerson_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            addPerson.Background = new SolidColorBrush(Colors.Black);
        }

        private void AddPerson_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            addPerson.Background = new SolidColorBrush(Colors.Aqua);
        }
    
    }
      
            
    
    }


using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using RestaurantMenuCart.Model;
using RestaurantMenuCart.Command;
using System.Collections.ObjectModel;

namespace RestaurantMenuCart.ViewModel
{
    public class CartItemSelectionVM : INotifyPropertyChanged
    {
        CartItemService objCartItemService;


        public CartItemSelectionVM()
        {
            objCartItemService = new CartItemService();
            LoadData();
            SelectedComboBoxItem = new CartItemSelectionModel();
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
  
        }

        public ObservableCollection<CartItemSelectionModel> comboBoxItems = new ObservableCollection<CartItemSelectionModel>
        {
            new CartItemSelectionModel{CartItem="PavBhaji"},
            new CartItemSelectionModel{CartItem="Paneer Tikka Masala"},
            new CartItemSelectionModel{CartItem="Pizza"},
            new CartItemSelectionModel{CartItem="Pasta"},
            new CartItemSelectionModel{CartItem="Hakka Noodles"}
        };

        public ObservableCollection<CartItemSelectionModel> ComboBoxItems
        {
            get { return comboBoxItems; }
            set { comboBoxItems = value; }
        }

        private CartItemSelectionModel selectedComboBoxItem;

        public CartItemSelectionModel SelectedComboBoxItem
        {
            get { return selectedComboBoxItem; }
            set { selectedComboBoxItem = value; NotifyPropertyChanged("SelectedComboBoxItem"); }
        }

        private ObservableCollection<CartItemSelectionModel> cartItemsSelectionList;

        public ObservableCollection<CartItemSelectionModel> CartItemsSelectionList
        {
            get { return cartItemsSelectionList; }
            set { cartItemsSelectionList = value;NotifyPropertyChanged("CartItemsSelectionList"); }
        }

        private void LoadData()
        {
            CartItemsSelectionList = objCartItemService.GetAll();
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value;NotifyPropertyChanged("Message"); }
        }


        //Add Operation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value;NotifyPropertyChanged("SaveCommand"); }
        }

        public void Save()
        {
            var IsSaved = objCartItemService.Add(SelectedComboBoxItem);
            if(IsSaved)
            {
                Message = "Item is Added";
            }
            else
            {
                Message = "Item Is Not Added";
            }
            LoadData();
        }



        //Delete Operation
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value;NotifyPropertyChanged("DeleteCommand"); }
        }

        public void Delete()
        {
            var IsDeleted = CartItemsSelectionList.Remove(SelectedComboBoxItem);
            if(IsDeleted)
            {
                Message = "Item is Removed From Cart";
                LoadData();
            }
            else
            {
                Message = "Item is not in Cart";
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

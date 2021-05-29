using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantMenuCart.Model
{
    public class CartItemSelectionModel : INotifyPropertyChanged
    {
       

        private string cartItem;
        public string CartItem
        {
            get { return cartItem; }
            set { cartItem = value; NotifyPropertyChanged("CartItem"); }
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

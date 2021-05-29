using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RestaurantMenuCart.Model
{
    public class CartItemService
    {
        private static ObservableCollection<CartItemSelectionModel> objItemList;

        public CartItemService()
        {
            objItemList = new ObservableCollection<CartItemSelectionModel>
            {
                new CartItemSelectionModel{ CartItem="Starter Pack(Default)"},
            };
        }

        public ObservableCollection<CartItemSelectionModel> GetAll()
        {
            return objItemList;
        }

        public bool Add(CartItemSelectionModel objNewItem)
        {
            objItemList.Add(objNewItem);
            return true;
        }

        public bool Delete(string CartItemDelete)
        {
            bool IsDeleted = false;
            for (int index = 0; index < objItemList.Count; index++)
            {
                if(objItemList[index].CartItem==CartItemDelete)
                {
                    objItemList.RemoveAt(index);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }
    }
}

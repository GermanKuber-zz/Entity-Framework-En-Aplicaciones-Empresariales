﻿using System;
using Market.Core.Enum;
using Market.Core.Interfaces;

namespace ShoppingCart.Domain
{
    //TODO 02 -  Private Setters & Constructors
    public class CartItem : IStateObject
    {
        private CartItem(int productId, int quantity, decimal displayedPrice, string cartCookie)
        {
            CartCookie = cartCookie;
            ProductId = productId;
            CurrentPrice = displayedPrice;
            Quantity = quantity;
            SelectedDateTime = DateTime.UtcNow;
            State = ObjectState.Added;
        }

        private CartItem(int productId, int quantity, decimal displayedPrice, int cartId)
        {
            ProductId = productId;
            Quantity = quantity;
            CurrentPrice = displayedPrice;
            CartId = cartId;
            SelectedDateTime = DateTime.UtcNow;
            State = ObjectState.Added;
        }

        private CartItem()
        {

        }
        internal static CartItem Create(int productId, int quantity, decimal displayedPrice, string cartCookie)
        {
            return new CartItem(productId, quantity, displayedPrice, cartCookie);
        }
        public static CartItem Create(int productId, int quantity, decimal displayedPrice, int cartId)
        {
            return new CartItem(productId, quantity, displayedPrice, cartId);
        }
        public int CartItemId { get; private set; }
        public string CartCookie { get; private set; }
        public int CartId { get; set; }
        public int ProductId { get; private set; }
        public DateTime SelectedDateTime { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public int Quantity { get; private set; }
        public ObjectState State { get; set; }
        public void UpdateQuantity(int newQuantity)
        {
            if (Quantity != newQuantity)
            {
                Quantity = newQuantity;
                State = ObjectState.Modified;
            }
        }


    }
}
/*
 * 
 * Andrew Larkins
 * Cis-3342-1
 * Bookstore Project
 * 09/19/20
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class OrderedBook
    {

        String isbn;
        String title;
        String author;
        String type;
        String rentBuy;
        String basePrice;
        double price;
        int quantity;
        double totalPrice;

        public OrderedBook()
        {

        }

        public string Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string BasePrice { get => basePrice; set => basePrice = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Type { get => type; set => type = value; }
        public string RentBuy { get => rentBuy; set => rentBuy = value; }
    }
}

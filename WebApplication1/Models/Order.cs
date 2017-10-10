using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int ID { get; set; }
        [DisplayName("Выполнено")]
        [DataType(DataType.DateTime)]
        public DateTime dateComplete { get; set; }
        [DisplayName("Дата К")]
        [DataType(DataType.DateTime)]
        public DateTime dateCustomer { get; set; }
        [DisplayName("Дата П")]
        [DataType(DataType.DateTime)]
        public DateTime dateSeller { get; set; }
        [DisplayName("Цена")]
        public float price { get; set; }
        [DisplayName("Кол-во")]
        public int count { get; set; }
        [DisplayName("E-Mail К")]
        public string EmailCustomer { get; set; }
        [DisplayName("E-Mail П")]
        public string EmailSeller { get; set; }

    }

    public class Seller
    {
        public int ID { get; set; }
        [DisplayName("Цена")]
        public float price { get; set; }
        [DisplayName("Кол-во")]
        public int count { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

    }

    //public class SellerDBContext : DbContext
    //{
    //    public DbSet<Seller> Sellers { get; set; }
    //}

    public class Customer
    {
        public int ID { get; set; }
        [DisplayName("Цена")]
        public float price { get; set; }
        [DisplayName("Кол-во")]
        public int count { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

    }

    //public class CustomerDBContext : DbContext
    //{
    //    public DbSet<Customer> Customers { get; set; }
    //}

    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
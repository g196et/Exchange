using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        #region Order
        private OrderDBContext dbOrder = new OrderDBContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Все текущие завершённые сделки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListOrder()
        {
            return View(dbOrder.Orders.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создание новой завершённой сделки
        /// </summary>
        /// <param name="order">Сделка</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateComplete, DateCustomer, DateSeller, price, counr, EmailCustomer, EmailSeller")] Order order)
        {
            if (ModelState.IsValid)
            {
                dbOrder.Orders.Add(order);
                dbOrder.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Поиск возможных сделок
        /// </summary>
        public void FindOrder()
        {
            //Для каждого покупателя
            foreach (var customer in dbOrder.Customers.OrderByDescending(x=>x.price).ToList())
            {
                //Находим всех продавцов, у которых цена ниже закупочной
                var sellers = dbOrder.Sellers.Where(x => x.price <= customer.price).OrderBy(x=>x.price).ToList();
                //До тех пор пока у покупателя есть желание купить и есть продавцы для него
                while ((customer.count > 0) && (sellers.Count > 0))
                {
                    //Создаём новую сделку
                    //sellers[0] - продавец с минимальной ценой
                    Order order = new Order();
                    order.dateCustomer = customer.date;
                    order.dateSeller = sellers[0].date;
                    order.price = sellers[0].price;
                    order.EmailSeller = sellers[0].email;
                    order.EmailCustomer = customer.email;
                    //Дата сделки, та, кто позже выложил предложение
                    order.dateComplete = (customer.date > sellers[0].date) ? customer.date : sellers[0].date;
                    //Если у продавца пряников больше, чем нужно покупателю
                    if (customer.count < sellers[0].count)
                    {
                        //Покупаем пряники у продавца
                        sellers[0].count -= customer.count;
                        //Записываем кол-во в сделку
                        order.count = customer.count;
                        //Мы купили все пряники, больше не надо
                        customer.count = 0;
                        //Удаляем покупателя
                        dbOrder.Customers.Remove(customer);
                    }
                    else
                    {
                        customer.count -= sellers[0].count;
                        order.count = sellers[0].count;
                        if (customer.count == 0)
                        {
                            dbOrder.Customers.Remove(customer);
                        }
                        dbOrder.Sellers.Remove(sellers[0]);
                        sellers.RemoveAt(0);
                    }
                    Create(order);
                }
            }
        }
        #endregion

        #region Seller
        public ActionResult IndexSeller()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ListSeller()
        {
            return View(dbOrder.Sellers.ToList());
        }

        [HttpGet]
        public ActionResult CreateSeller()
        {
            return View();
        }

        /// <summary>
        /// Создание продавца
        /// </summary>
        /// <param name="seller">Продавец</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSeller([Bind(Include = "ID,price,count,email")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                seller.date = DateTime.Now;
                dbOrder.Sellers.Add(seller);
                dbOrder.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Customer
        public ActionResult IndexCustomer()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ListCustomer()
        {
            return View(dbOrder.Customers.ToList());
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "ID,price,count,email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.date = DateTime.Now;
                dbOrder.Customers.Add(customer);
                dbOrder.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
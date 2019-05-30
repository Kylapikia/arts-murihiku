using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AM1.Data;
using AM1.Models;
using Microsoft.AspNetCore.Identity;

namespace AM1.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Carts1
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));
            // this commented out code is to pass the product to the view 
            //List<Product> products = new List<Product>();
            //foreach (Cart c in userCart)
            //{
            //    Product stuff = await _context.Product.SingleOrDefaultAsync(cart => cart.ProductID.Equals(c.CartID));
            //    products.Add(stuff);
            //}
            //var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));
            return View(userCart);
        }

        // GET: Carts1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .SingleOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }



        public IActionResult Checkout(int? id)
        {
            string userId = _userManager.GetUserId(User);
            var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));

            return View(userCart);
        }
        public async Task<IActionResult> Purchase()
        {
            string userId = _userManager.GetUserId(User);
            var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));
            foreach (Cart c in userCart)
            {
                _context.Cart.Remove(c);
                Product product = await _context.Product.SingleOrDefaultAsync(p => p.ProductID.Equals(c.ProductID));
                _context.Product.Remove(product);
            }
            var userr = await _userManager.FindByIdAsync(userId);
            userr.CartID = 0;
            await _userManager.UpdateAsync(userr);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ThankYou));
            //return View();
        }

        public async Task<IActionResult> ClearCart()
        {

            string userId = _userManager.GetUserId(User);
            var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));
            foreach (Cart c in userCart)
            {
                _context.Cart.Remove(c);
            }
            var userr = await _userManager.FindByIdAsync(userId);
            userr.CartID = 0;
            await _userManager.UpdateAsync(userr);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ThankYou));
        }
        // GET: Carts1/Create
        public async Task<IActionResult> Create(int? id)
        {
            string userId = _userManager.GetUserId(User);
            //double total = 0;
            //m => m.CartID == id
            Product selecteditem = await _context.Product.SingleOrDefaultAsync(p => p.ProductID.Equals(id));
            Cart cart = new Cart();
            cart.ArtistID = _userManager.GetUserId(User);
            cart.ProductID = (int)id;
            cart.ProductName = selecteditem.Name;
            cart.ProductPrice = selecteditem.Price;
            var userCart = _context.Cart.Where(user => user.ArtistID.Equals(userId));

            bool newProd = true;
            bool updateProd = false;
            foreach (Cart c in userCart)
            {
                if (c.ProductID == selecteditem.ProductID)
                {
                    c.Quantity += cart.Quantity;
                    updateProd = true;

                }
                //total += c.ProductPrice;
            }
            if (updateProd)
            {
                //_context.Update(cart);
                //await _context.SaveChangesAsync();
                newProd = false;
            }
            if (userCart == null || newProd)
            {
                //total += cart.ProductPrice;
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }

            var cartT = _context.Cart.Where(car => car.ArtistID.Equals(userId));
            double total = 0;
            foreach (Cart carr in cartT)
            {
                total++;
            }

            var userr = await _userManager.FindByIdAsync(userId);
            userr.CartID = total;
            await _userManager.UpdateAsync(userr);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ThankYou()
        {
            return View();
        }
        // POST: Carts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CartID,ArtistID,ProductID,Quantity")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cart);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cart);
        //}
        public async Task<IActionResult> Create([Bind("CartID,ArtistID,ProductID,Quantity")] Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                //double total = 0;
                //m => m.CartID == id
                Product selecteditem = await _context.Product.SingleOrDefaultAsync(p => p.ProductID.Equals(id));

                cart.ArtistID = _userManager.GetUserId(User);
                cart.ProductID = id;
                cart.ProductName = selecteditem.Name;
                cart.ProductPrice = selecteditem.Price;
                var userCart = _context.Cart.Where(user => user.ArtistID.Equals(userId));

                bool newProd = true;
                bool updateProd = false;
                foreach (Cart c in userCart)
                {
                    if (c.ProductID == selecteditem.ProductID)
                    {
                        c.Quantity += cart.Quantity;
                        updateProd = true;
                    }
                    //total += c.ProductPrice;
                }
                if (updateProd)
                {
                    //_context.Update(cart);
                    //await _context.SaveChangesAsync();
                    newProd = false;
                }
                if (userCart == null || newProd)
                {
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                }

                //List<Product> products = new List<Product>();
                //products.Add(selecteditem);

                //cart.SetProducts(products);

                ////blog id only available after its added to database AKA .SaveChangesAsync()
                //string id = blog.BlogID.ToString();
                //string url = System.Web.HttpContext.Current.Request.Url;
                var cartT = _context.Cart.Where(car => car.ArtistID.Equals(userId));
                double total = 0;
                foreach (Cart carr in cartT)
                {
                    total++;
                }

                var userr = await _userManager.FindByIdAsync(userId);
                userr.CartID = total;
                await _userManager.UpdateAsync(userr);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Carts1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Carts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartID,ArtistID,ProductID,Quantity")] Cart cart)
        {
            if (id != cart.CartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string userId = _userManager.GetUserId(User);
                    //m => m.CartID == id
                    Product selecteditem = await _context.Product.SingleOrDefaultAsync(p => p.ProductID.Equals(id));
                    //cart = await _context.Cart.SingleOrDefaultAsync(m => m.CartID == cart.CartID);                    
                    //var userCart = _context.Cart.Where(cart => cart.ArtistID.Equals(userId));
                    //List<Product> products = await _context.Cart.SingleOrDefaultAsync(p => p.GetProducts.Equals(productID));
                    //List<Product> products = cart.GetProducts();
                    //products.Add(selecteditem);
                    //cart.ArtistID = _userManager.GetUserId(User);
                    //cart.SetProducts(products);
                    //ApplicationUser user = await _userManager.GetUserAsync(User);
                    //var user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
                    //user.CartID = cart.CartID;
                    //foreach(Cart)
                    //var userCart = _context.Cart.SingleOrDefaultAsync(m => m.CartID == car);

                    //var idcontext = ApplicationDbContext<ApplicationUser>(new ApplicationDbContext());

                    //var store = new IUserStore<ApplicationUser>(new DbContext());
                    //var manager = new UserManager(store);
                    //manager.UpdateAsync(user);
                    //var ctx = store.context;
                    //ctx.saveChanges();

                    //var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                    //string email = userr.Email;
                    //await _userManager.SetEmailAsync(userr, email);

                    var userr = await _userManager.FindByIdAsync(userId);
                    userr.CartID = cart.CartID;
                    await _userManager.UpdateAsync(userr);

                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Carts1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .SingleOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.CartID == id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            // update the total
            string userId = _userManager.GetUserId(User);
            var cartT = _context.Cart.Where(car => car.ArtistID.Equals(userId));
            double total = 0;
            foreach (Cart carr in cartT)
            {
                total++;
            }

            var userr = await _userManager.FindByIdAsync(userId);
            userr.CartID = total;
            await _userManager.UpdateAsync(userr);
            // update the total
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartID == id);
        }
    }
}

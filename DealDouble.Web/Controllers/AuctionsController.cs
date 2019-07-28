using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDouble.Services;

namespace DealDouble.Web.Controllers
{
    public class AuctionsController : Controller
    {
        
        // List Auction
        [HttpGet]
        public ActionResult Index()
        {
            AuctionService service = new AuctionService();
            var auctions = service.GetAllAuction();
            if (Request.IsAjaxRequest())
            {
                return PartialView(auctions);
            }
            return View(auctions);
        }
        // Create Auction
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionService service = new AuctionService();
            service.AddAuction(auction);
            return RedirectToAction("Index");
        }
        // Edit Auction
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            AuctionService service = new AuctionService();
            var auction = service.GetAuctionByID(ID);
            return PartialView(auction);
        }
        
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionService service = new AuctionService();
            service.UpdateAuction(auction);
            return RedirectToAction("Index");
        }
      
        // Delete Auction
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AuctionService service = new AuctionService();
            var auction = service.GetAuctionByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            AuctionService service = new AuctionService();
            service.DeleteAuction(auction);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HsDbFirstRealAspNetProject.Models;
using HsDbFirstRealAspNetProject.Models.DbModel;
using HsDbFirstRealAspNetProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HsDbFirstRealAspNetProject.Controllers
{
    [Authorize]
    public class DecksController : Controller
    {
        private readonly HsDbFirstRealAspNetProjectContext _context;
        public DecksController(HsDbFirstRealAspNetProjectContext context)
        {
            _context = context;
        }

        // GET: Decks
        public async Task<IActionResult> Index(
        string sortOrder,
        List<string> cardNames,
        string Hero,
        string currentFilter,
        string searchString,
        int? page,
        int? cost,
        int? parPage)
        {
            List<string> hero = new List<string>() { "Malfurion Stormrage", "Rexxar", "Jaina Proudmoore", "Uther Lightbringer", "Anduin Wrynn", "Valeera Sanguinar", "Thrall", "Gul'dan", "Garrosh HellScream" };
            ViewData["CurrentSort"] = string.IsNullOrEmpty(sortOrder) ? "Sort" : "";
            ViewData["Cost"] = cost != null ? "cost" : "";
            ViewData["Hero"] = string.IsNullOrEmpty(Hero) ? "Hero" : "";
            ViewData["CardSetParm"] = string.IsNullOrEmpty(sortOrder) ? "CardSet_desc" : "";
            ViewData["CurrentFilter"] = string.IsNullOrEmpty(currentFilter) ? currentFilter : "";
            ViewData["CardParPage"] = parPage != null ? "CardParPage" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var card = from cardinfo in _context.CardInfo select cardinfo;
            card = _context.CardInfo.OrderBy(c => c.Class).ThenBy(co => co.AdditionCard.Cost);
            card = card.Where(c => c.AdditionCard != null && c.CardSet != "Tavern Brawl" && c.CardSet != "Missions" && c.CardSet != "Hero Skins" && c.AdditionCard.Collectible == true);
            if (!string.IsNullOrEmpty(searchString))
            {
                card = card.Where(c => c.Name.Contains(searchString) || c.Class.Contains(searchString)).Distinct().OrderBy(c => c.AdditionCard.Cost);
            }
            if (parPage == null || parPage == 0)
            {
                parPage = 20;
            }
            if (string.IsNullOrEmpty(Hero))
            {
                card = card.Where(c => hero.Contains(c.Name));
            }
            if (!string.IsNullOrWhiteSpace(Hero))
            {
                card = card.Where(c => c.Class.Contains(Hero));
            }
            return View(await PaginatedList<CardInfo>.CreateAsync(card, page ?? 1, (int)parPage));
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck
                .SingleOrDefaultAsync(m => m.DeckId == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Decks/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(CardInfo cardInfos)
        {
            if (ModelState.IsValid)
            {
                DeckVsCards deckVsCards = new DeckVsCards
                {
                    Card = cardInfos
                };
                _context.Add(deckVsCards);
                await _context.SaveChangesAsync();
                RedirectToAction(nameof(Index));
                return View();
            }
            return View();


        }
        // GET: Decks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck.SingleOrDefaultAsync(m => m.DeckId == id);
            if (deck == null)
            {
                return NotFound();
            }
            return View(deck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeckId")] Deck deck)
        {
            if (id != deck.DeckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.DeckId))
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
            return View(deck);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck
                .SingleOrDefaultAsync(m => m.DeckId == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deck = await _context.Deck.SingleOrDefaultAsync(m => m.DeckId == id);
            _context.Deck.Remove(deck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
            return _context.Deck.Any(e => e.DeckId == id);
        }
    }
}

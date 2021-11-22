using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Commands;
using Transactions.Database;
using Transactions.Models;

namespace Transactions.Controllers {

    [ApiController]
    [EnableCors]
    [Route("/transactions")]

    public class TransactionsController : ControllerBase {
        private readonly ILogger<TransactionsController> _logger;
        private readonly TransactionsDbContext _context; 

        public TransactionsController(ILogger<TransactionsController> logger, TransactionsDbContext dbContext)
        {
            _context = dbContext;
            _logger = logger;
        }

    
    
        // [HttpGet]
        // public IActionResult GetTransactions(
        //                                      [FromQuery]int? page, [FromQuery] int? page_size, 
        //                                     [FromQuery] SortOrder sort_order)    
        // {
        //    return Ok(_context.transactions.Count());
        // }

        [HttpGet]
        public IActionResult GetTransactions([FromQuery(Name="transaction-kind")] string? transaction_kind = null,            //GET the list of transactions
                                            [FromQuery(Name="start-date")] DateTime? start_date = null, 
                                            [FromQuery(Name="end-date")] DateTime? end_date = null,
                                            [FromQuery] int? page = null,
                                            [FromQuery(Name="page-size")] int? page_size = null, 
                                            [FromQuery(Name="sort-by")] string? sort_by = null,
                                            [FromQuery(Name="sort-order")] SortOrder? sort_order = null)    
        {
            var transactions = from t in _context.transactions select t;
            if (!String.IsNullOrEmpty(transaction_kind))
            {
                transactions = transactions.Where(t => t.kind.Equals(transaction_kind));
            }
            if (!String.IsNullOrEmpty(sort_by))
            {
                switch (sort_by) {
                    case "beneficiary_name":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.beneficiary_name);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.beneficiary_name);
                        }
                        break;
                    case "date":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.date);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.date);
                        }
                        break;
                    case "direction":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.direction);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.direction);
                        }
                        break;
                    case "amount":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.amount);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.amount);
                        }
                        break;
                    case "description":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.description);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.description);
                        }
                        break;
                    case "currency":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.currency);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.currency);
                        }
                        break;
                    case "mcc":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.mcc);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.mcc);
                        }
                        break;
                    case "kind":
                        if (sort_order == SortOrder.Asc){
                            transactions = transactions.OrderBy(t => t.kind);
                        } else if (sort_order == SortOrder.Desc){
                            transactions = transactions.OrderByDescending(t => t.kind);
                        }
                        break;
                }
            }
            if (page != null && page_size != null){
                transactions = transactions.Skip((page.GetValueOrDefault() - 1) * page_size.GetValueOrDefault()).Take(page_size.GetValueOrDefault());
            }
            return Ok(transactions.ToList());
        }


        [HttpPost]
        public IActionResult ImportTransactions([FromBody] ImportTransactionCommand transaction)     //import transactions
        {
        return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult SplitTransactions([FromRoute] SplitTransactionCommand id)         //split transactions by id
        {
        return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult CategorizeTransactions([FromRoute] string id)     //categorize transaction by id
        {
        return Ok();
        }

        [HttpPost]
        public IActionResult AutoCategorizeTransactions()     //autoCategorize  transactions 
        {
        return Ok();
        } 
    }
}

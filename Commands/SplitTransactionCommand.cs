using System;
using System.ComponentModel.DataAnnotations;
using Transactions.Models;

namespace Transactions.Commands

{
public class SplitTransactionCommand {

     
    
     public string? catcode { get; set; }
     public double? amount { get; set; }
  

}
}
using System;
using System.ComponentModel.DataAnnotations;
using Transactions.Models;

namespace Transactions.Commands

{
public class ImportTransactionCommand {

     
    
     public string? beneficiary_name { get; set; }
  
     public string? date { get; set; }
  
     public Direction direction { get; set; } 
 
     public double amount {get; set;}
  
    public string? description { get; set; }

     public string? currency { get; set; }   

     public string mcc { get; set; }

     public string? kind { get; set; }
                                            
                      

  
  

}
}
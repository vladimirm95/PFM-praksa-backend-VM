using Transactions.Models;

namespace Transactions.Database.Entities{

public class TransactionEntity{

    public int? id { get; set; }
    public string? beneficiary_name { get; set; }
    
    public string? date { get; set; }
    
    public string? direction { get; set; } 
  
    public double amount {get; set;}
    
    public string? description { get; set; }

    public string? currency { get; set; }   

    public int? mcc { get; set; }

    public string? kind { get; set; }
}




}
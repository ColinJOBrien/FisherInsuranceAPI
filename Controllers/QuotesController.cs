using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

namespace FisherInsuranceApi.Controllers
{
 [Route("api/quotes")]     
 public class QuotesController : Controller     
    {

            private readonly FisherContext db;
            
            public QuotesController(FisherContext context) {
                db = context;
            }
            //Support for the root collection of Quotes
            [HttpGet] 
            public IActionResult GetQuotes() 
                {  
                    return Ok(db.Quotes); 
                }    

            //Support for getting a single quote by updating the Get Method    
            [HttpGet("{id}")]   
            public IActionResult Get(int id)   
                {    
                    return Ok(db.Quotes.Find(id));  
                } 

            //Support for posting a Quote by updating the Post Method
            [HttpPost] 
            public IActionResult Post([FromBody] Quote quote) 
                {  
                    var newClaim = db.Quotes.Add(quote);             
                    db.SaveChanges();             
                    return CreatedAtRoute("GetClaim", new { id = quote.Id }, quote); 
                }

            //Support for putting an existing quote back in the collection by updating Put Method
            [HttpPut("{id}")] 
            public IActionResult Put(int id, [FromBody] Quote quote) 
                {  
                     var newQuote = db.Quotes.Find(id);             
                     if (newQuote == null) {                 
                         return NotFound();             
                     }       

                     newQuote = quote;             
                     db.SaveChanges();             
                     return Ok(newQuote);  
                } 


            [HttpDelete("{id}")] 
            public IActionResult Delete([FromBody] Quote quote) 
                {          
                    return Ok();
                } 
    } 
}
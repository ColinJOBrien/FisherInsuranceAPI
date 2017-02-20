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
            private IMemoryStore db; 
            public QuotesController(IMemoryStore repo) 
                {  
                    db = repo; 
                } 

            //Support for the root collection of Quotes
            [HttpGet] 
            public IActionResult GetQuotes() 
                {  
                    return Ok(db.RetrieveAllQuotes); 
                }    

            //Support for getting a single quote by updating the Get Method    
            [HttpGet("{id}")]   
            public IActionResult Get(int id)   
                {    
                    return Ok(db.RetrieveQuote(id));  
                } 

            //Support for posting a Quote by updating the Post Method
            [HttpPost] 
            public IActionResult Post([FromBody] Quote quote) 
                {  
                    return Ok(db.CreateQuote(quote)); 
                }

            //Support for putting an existing quote back in the collection by updating Put Method
            [HttpPut("{id}")] 
            public IActionResult Put([FromBody] Quote quote) 
                {  
                    return Ok(db.UpdateQuote(quote)); 
                } 


            [HttpDelete("{id}")] 
            public IActionResult Delete([FromBody] Quote quote) 
                {  
                    db.DeleteQuote(quote.Id);        
                    return Ok();
                } 
    } 
}
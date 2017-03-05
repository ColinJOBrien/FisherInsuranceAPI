using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

namespace FisherInsuranceApi.Controllers
{
 [Route("api/customer/claims")]     
 public class ClaimsController : Controller     
    { 

            private readonly FisherContext db;
            
            public ClaimsController(FisherContext context) {
                db = context;
            }
            //Support for the root collection of Quotes
            [HttpGet] 
            public IActionResult GetClaims() 
                {  
                    return Ok(db.Claims); 
                }    

            //Support for getting a single quote by updating the Get Method    
            [HttpGet("{id}")]   
            public IActionResult Get(int id)   
                {    
                    return Ok(db.Claims.Find(id));  
                } 

            //Support for posting a Quote by updating the Post Method
            [HttpPost] 
            public IActionResult Post([FromBody] Claim claim) 
                {  
                    var newClaim = db.Claims.Add(claim);             
                    db.SaveChanges();             
                    return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim); 
                }

            //Support for putting an existing quote back in the collection by updating Put Method
            [HttpPut("{id}")] 
            public IActionResult Put(int id, [FromBody] Claim claim) 
                {  
                     var newClaim = db.Claims.Find(id);             
                     if (newClaim == null) {                 
                         return NotFound();             
                     }       

                     newClaim = claim;             
                     db.SaveChanges();             
                     return Ok(newClaim);  
                } 

            //Support for deleting an existing claim
            [HttpDelete("{id}")] 
            public IActionResult Delete(int id) 
                {          
                    var claimToDelete = db.Claims.Find(id);             
                    if (claimToDelete == null) {                 
                        return NotFound();             
                    }             
                    db.Claims.Remove(claimToDelete);             
                    db.SaveChangesAsync();             
                    return NoContent(); 
                } 
    } 
}
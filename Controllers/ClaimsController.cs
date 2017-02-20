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
            private IMemoryStore db; 
            public ClaimsController(IMemoryStore repo) 
                {  
                    db = repo; 
                } 

            //Support for the root collection of Quotes
            [HttpGet] 
            public IActionResult GetClaims() 
                {  
                    return Ok(db.RetrieveAllClaims); 
                }    

            //Support for getting a single quote by updating the Get Method    
            [HttpGet("{id}")]   
            public IActionResult Get(int id)   
                {    
                    return Ok(db.RetrieveClaim(id));  
                } 

            //Support for posting a Quote by updating the Post Method
            [HttpPost] 
            public IActionResult Post([FromBody] Claim claim) 
                {  
                    return Ok(db.CreateClaim(claim)); 
                }

            //Support for putting an existing quote back in the collection by updating Put Method
            [HttpPut("{id}")] 
            public IActionResult Put([FromBody] Claim claim) 
                {  
                    return Ok(db.UpdateClaim(claim)); 
                } 

            //Support for deleting an existing claim
            [HttpDelete("{id}")] 
            public IActionResult Delete([FromBody] Claim claim) 
                {  
                    db.DeleteClaim(claim.Id);        
                    return Ok();
                } 
    } 
}
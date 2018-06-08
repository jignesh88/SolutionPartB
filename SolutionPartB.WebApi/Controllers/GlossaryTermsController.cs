using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolutionPartB.Data.Repository;
using SolutionPartB.Data.Entitry;
using SolutionPartB.WebApi.Model;
using AutoMapper;
namespace SolutionPartB.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GlossaryTermsController : ControllerBase
    {
        private readonly IGloassaryTermRepository _repository;

        public GlossaryTermController(IGloassaryTermRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public Task<IActionResult> Get()
        {
            var list = Mapper.Map<IEnumerable<GlossaryTermModel>>(_repository.GetAll());
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public GlossaryTermModel Get(Guid id)
        {
            var result = _repository.GetById(id);
            if(result == null){
                return null;
            } else {
                var output = Mapper.Map<GlossaryTermModel>(result);
                return output;
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]GlossaryTermModel term)
        {
            try
            {
                term.GlossaryTermId = Guid.NewGuid();
                var GlossaryTerm = Mapper.Map<GlossaryTerm>(term);
                _repository.Add(GlossaryTerm);
            }
            catch (Exception)
            {
                return CreatedAtRoute("GlossaryTerm", new { });
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]GlossaryTermModel term)
        {
            try
            {
                var mode = 
                _repository.Update(term);

            }
            catch (Exception ex)
            {
                
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _repository.Delete(null);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

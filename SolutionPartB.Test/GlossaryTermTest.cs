using System;
using SolutionPartB.Data.Entity;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using SolutionPartB.Data.Repository;
using Moq;

namespace SolutionPartB.Test
{
    public class GlossaryTermTest
    {
        private readonly IGloassaryTermRepository repository;
        
        public GlossaryTermTest()
        {
            // create some mock to play with
            List<GlossaryTerm> terms = new List<GlossaryTerm>
                {
                new GlossaryTerm{ GlossaryTermId = Guid.NewGuid(), Term = "Term1", Defination= "Defination1", CreatedDate = DateTime.Now},
                new GlossaryTerm{ GlossaryTermId = Guid.NewGuid(), Term = "Term2", Defination= "Defination2", CreatedDate = DateTime.Now},
                new GlossaryTerm{ GlossaryTermId = Guid.NewGuid(), Term = "Term3", Defination= "Defination3", CreatedDate = DateTime.Now},
                new GlossaryTerm{ GlossaryTermId = Guid.NewGuid(), Term = "Term4", Defination= "Defination4", CreatedDate = DateTime.Now}
            };


            // Mock the Repository using Moq
            Mock<IGloassaryTermRepository> mockRepositoy = new Mock<IGloassaryTermRepository>();

            // Return all the terms
            mockRepositoy.Setup(mr => mr.GetAll()).Returns(terms.AsQueryable());

            // return a term by Id
            mockRepositoy.Setup(mr => mr.GetById(
                It.IsAny<Guid>())).Returns((Guid i) => terms.Where(
                x => x.GlossaryTermId == i).Single());

            // add term
            mockRepositoy.Setup(mr => mr.Add(It.IsAny<GlossaryTerm>())).Callback(
                (GlossaryTerm target) =>
                {
                    DateTime now = DateTime.Now;
                    target.CreatedDate = now;
                    target.GlossaryTermId = Guid.NewGuid();
                    terms.Add(target);

                }).Verifiable();

                // delete term
            mockRepositoy.Setup(mr => mr.Delete(It.IsAny<GlossaryTerm>())).Callback(
                (GlossaryTerm target) =>
                {
                    terms.Remove(target);

                }).Verifiable();

                // add term
                mockRepositoy.Setup(mr => mr.Update(It.IsAny<GlossaryTerm>())).Callback(
                (GlossaryTerm target) =>
                {
                    var item = terms.Where(t => t.GlossaryTermId == target.GlossaryTermId).FirstOrDefault();
                    terms.Remove(target);
                    terms.Add(target);

                }).Verifiable();

            // Complete the setup of our Mock Product Repository
            this.repository = mockRepositoy.Object;
        }

        [Fact]
        public void AddGlossaryTerm_ShouldAddGlossaryTerm()
        {

            repository.Add(new GlossaryTerm { Term = "Term 5", Defination = "Defination 5" });
            var count = this.repository.GetAll().Count();
            Assert.Equal(count, 5);
        }

        [Fact]
        public void EditGlossaryTerm_ShouldUpdateGlossaryTerm()
        {

            var term = repository.GetAll().FirstOrDefault();
            term.Term = "Term Test";
            repository.Update(term);
            var updated = repository.GetById(term.GlossaryTermId);
            Assert.Equal(term.Term, updated.Term);
        }

        [Fact]
        public void DelGlossaryTerm_ShouldDeleteGlossaryTerm()
        {
            var before = repository.GetAll().Count();
            var term = repository.GetAll().FirstOrDefault();
            repository.Delete(term);
            var after = repository.GetAll().Count();
            Assert.NotEqual(before, after);
        }

        [Fact]
        public void GetAllGlossaryTerm_ShouldGetAllGlossaryTerm()
        {
            var count = this.repository.GetAll().Count();
            Assert.Equal(count, 4);

        }
    }
}

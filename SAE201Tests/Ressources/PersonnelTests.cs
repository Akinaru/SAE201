using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE201.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Ressources.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        private Personnel p1;
        [TestInitialize()]
        public void init()
        {
            p1 = new Personnel(1000,"nomTest","prenomTest","email@test.fr");
            p1.Create();
            p1.Id = p1.GetId();
        }
        [TestMethod()]
        public void CreateTest()
        {
            Personnel perso = p1.Read(p1.GetId());
            Assert.AreEqual(p1.Nom, perso.Nom, "Test create nom personnel");
            Assert.AreEqual(p1.Prenom, perso.Prenom, "Test create prenom personnel");
            Assert.AreEqual(p1.Email, perso.Email, "Test create email personnel");
        }

        [TestMethod()]
        public void ReadTest()
        {
            Personnel perso = p1.Read(p1.GetId());
            Assert.AreEqual(p1.Nom, perso.Nom, "Test Read nom personnel");
            Assert.AreEqual(p1.Prenom, perso.Prenom, "Test Read prenom personnel");
            Assert.AreEqual(p1.Email, perso.Email, "Test Read email personnel");
        }

        [TestMethod()]
        public void UpdateTest()
        {
            p1.Nom = "nomTestUpdate";
            p1.Prenom = "prenomTestUpdate";
            p1.Email = "email@Test.Update";

            p1.Update();
            
            Personnel perso = p1.Read(p1.GetId());
            
            Assert.AreEqual(p1.Nom, perso.Nom, "Test update nom personnel");
            Assert.AreEqual(p1.Prenom, perso.Prenom, "Test update prenom personnel");
            Assert.AreEqual(p1.Email, perso.Email, "Test update email personnel");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int id = p1.GetId();
            p1.Delete();
            Assert.AreEqual(null, p1.Read(id), "Test delete personnel");
        }
    }
}
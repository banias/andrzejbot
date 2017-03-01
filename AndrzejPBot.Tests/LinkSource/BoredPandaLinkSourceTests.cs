using AndrzejPBot.LinkSource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrzejPBot.Tests.LinkSource
{
    [TestFixture]
    public class BoredPandaLinkSourceTests
    {
        [Test]
        public void ConstructorDoesNotThrow()
        {
            //Arrange/Act/Assert
            Assert.That(() =>new BoredPandaLinkSource(), Throws.Nothing);
        }

        [Test]
        public void GetRandomLinkReturnsNotNull()
        {
            //Arrange
            var linkSource = new BoredPandaLinkSource();
            //Act
            var result = linkSource.GetRandomLink();
            //Arrange
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetRandomLinkReturnsLinkThatStartsWithHttp()
        {
            //Arrange
            var linkSource = new BoredPandaLinkSource();
            //Act
            var result = linkSource.GetRandomLink();
            //Arrange
            Assert.That(result, Does.StartWith("http://"));
        }
    }
}

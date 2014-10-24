using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBookStore.Domain.Repositories;

namespace MvcBookStore.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_livro
    {
        #region TestContext
        private string invalidBookTitle = "A";
        private string validBookTitle = "The one book!";
        private DateTime validReleaseDate = DateTime.Now.AddDays(1);
        private string invalidBookISBN = "1";
        private string validBookISBN = "12345678910";
        private string invalidImageUrl = "asd";
        private string validImageUrl = "http://booksbybrookie.files.wordpress.com/2012/03/thefellowshipofthering.jpg";
        #endregion

        [TestCategory("Livro - Novo")]
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void O_titulo_deve_conter_mais_que_tres_caracteres()
        {
            var book = new Book(invalidBookTitle, validBookISBN, validImageUrl);
        }

        [TestCategory("Livro - Novo")]
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void O_isbn_deve_conter_entre_dez_e_treze_caracteres()
        {
            var book = new Book(validBookTitle, invalidBookISBN, validImageUrl);
        }

        [TestCategory("Livro - Novo")]
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void A_data_de_lancamento_deve_ser_valida()
        {
            var book = new Book(validBookTitle, DateTime.Now.AddDays(-3), validBookISBN, validImageUrl);
        }
    }
}

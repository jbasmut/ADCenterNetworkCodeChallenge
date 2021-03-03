using ADCenterNetworkCodeChallenge.Service;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace TestADCenterNetworkCodeChallenge
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckSequence_mRNANotNull(string sequence)
        {
            var mock = new Mock<ILogger<Sequence_mRNAService>>();
            ILogger<Sequence_mRNAService> logger = mock.Object;
            Sequence_mRNAService sequence_mRNAService = new Sequence_mRNAService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAService.CheckSequence_mRNA(sequence));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field can not be null. Error at char index 0."));
        }

        [TestCase("C:\\Users\\jbasmut\\OneDrive - Capgemini\\Documents\\Code Challenge\\App\\data\\empty.txt", 0)]
        public void CheckSequence_mRNAStreamNotNull(string path, int counter)
        {
            var mock = new Mock<ILogger<Sequence_mRNAStreamService>>();
            ILogger<Sequence_mRNAStreamService> logger = mock.Object;
            Sequence_mRNAStreamService sequence_mRNAStreamService = new Sequence_mRNAStreamService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAStreamService.CheckSequence_mRNA(path, counter));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field can not be null. Error at char index 0."));
        }

        [TestCase(">NM_001170833 1\ncaaauuuuaa")]
        public void CheckSequence_mRNAIncorrectLenght(string sequence)
        {
            var mock = new Mock<ILogger<Sequence_mRNAService>>();
            ILogger<Sequence_mRNAService> logger = mock.Object;
            Sequence_mRNAService sequence_mRNAService = new Sequence_mRNAService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAService.CheckSequence_mRNA(sequence));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field has an incorrect lenght. Error at char index 25."));
        }

        [TestCase("C:\\Users\\jbasmut\\OneDrive - Capgemini\\Documents\\Code Challenge\\App\\data\\incorrectLenght.txt", 0)]
        public void CheckSequence_mRNAStreamIncorrectLenght(string path, int counter)
        {
            var mock = new Mock<ILogger<Sequence_mRNAStreamService>>();
            ILogger<Sequence_mRNAStreamService> logger = mock.Object;
            Sequence_mRNAStreamService sequence_mRNAStreamService = new Sequence_mRNAStreamService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAStreamService.CheckSequence_mRNA(path, counter));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field has an incorrect lenght. Error at char index 26."));
        }

        [TestCase(">NM_001170833 1\nxaauuuuaa")]
        public void CheckSequence_mRNAIncorrectCharacters(string sequence)
        {
            var mock = new Mock<ILogger<Sequence_mRNAService>>();
            ILogger<Sequence_mRNAService> logger = mock.Object;
            Sequence_mRNAService sequence_mRNAService = new Sequence_mRNAService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAService.CheckSequence_mRNA(sequence));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field must not have different characters than ´A´, ´U´, ´G´ and ´C´. Error at char index 0."));
        }

        [TestCase("C:\\Users\\jbasmut\\OneDrive - Capgemini\\Documents\\Code Challenge\\App\\data\\incorrectCharacters.txt", 0)]
        public void CheckSequence_mRNAStreamIncorrectCharacters(string path, int counter)
        {
            var mock = new Mock<ILogger<Sequence_mRNAStreamService>>();
            ILogger<Sequence_mRNAStreamService> logger = mock.Object;
            Sequence_mRNAStreamService sequence_mRNAStreamService = new Sequence_mRNAStreamService(logger);

            var ex = Assert.Throws<ArgumentException>(() => sequence_mRNAStreamService.CheckSequence_mRNA(path, counter));
            Assert.That(ex.Message, Is.EqualTo("The 'sequence' field must not have different characters than ´A´, ´U´, ´G´ and ´C´. Error at char index 0."));
        }

        [TestCase(">NM_001170833 1\naaauuuuaa")]
        public void CheckSequence_mRNA(string sequence)
        {
            var mock = new Mock<ILogger<Sequence_mRNAService>>();
            ILogger<Sequence_mRNAService> logger = mock.Object;
            Sequence_mRNAService sequence_mRNAService = new Sequence_mRNAService(logger);

            var genes = sequence_mRNAService.CheckSequence_mRNA(sequence).Result;
            Assert.AreEqual(genes[0], "AAAUUUUAA");
        }

        [TestCase("C:\\Users\\jbasmut\\OneDrive - Capgemini\\Documents\\Code Challenge\\App\\data\\test.txt", 0)]
        public void CheckSequence_mRNAStream(string path, int counter)
        {
            var mock = new Mock<ILogger<Sequence_mRNAStreamService>>();
            ILogger<Sequence_mRNAStreamService> logger = mock.Object;
            Sequence_mRNAStreamService sequence_mRNAStreamService = new Sequence_mRNAStreamService(logger);

            var gene = sequence_mRNAStreamService.CheckSequence_mRNA(path, counter).Result;
            Assert.AreEqual(gene, "AAAUUUUAA");
        }
    }
}
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADCenterNetworkCodeChallenge.Service
{
    public class Sequence_mRNAService
    {
        private readonly ILogger<Sequence_mRNAService> _logger;

        public Sequence_mRNAService(ILogger<Sequence_mRNAService> logger)
        {
            _logger = logger;
        }

        public Task<string[]> CheckSequence_mRNA(string sequence)
        {
            _logger.LogDebug($"CheckSequence_mRNA method from service Sequence_mRNAService with value : {sequence}");

            if (string.IsNullOrEmpty(sequence))
            {
                throw new ArgumentException("The 'sequence' field can not be null. Error at char index 0.");
            }

            bool rightLenght = true;
            rightLenght = CheckLenght(sequence);

            if (!rightLenght)
            {
                int index = sequence.Length - 1;
                throw new ArgumentException("The 'sequence' field has an incorrect lenght. Error at char index " + index + ".");
            }

            bool correctChars = true;
            //Clean the sequence
            string cleanSequence = CleanSequence(sequence);
            correctChars = CheckIncorrectChars(cleanSequence.ToUpper()).Item1; //Check if the chars are correct no matter upper or lower case

            if (!correctChars)
            {
                int index = CheckIncorrectChars(cleanSequence.ToUpper()).Item2;
                throw new ArgumentException("The 'sequence' field must not have different characters than ´A´, ´U´, ´G´ and ´C´. Error at char index " + index + ".");
            }

            string[] genes = GetGenes(cleanSequence);

            return Task.FromResult(genes);
        }

        public Tuple<bool, int> CheckIncorrectChars(string inputString)
        {
            bool isMatch = true;
            int index = 0; //Index of the character in the sequence
            foreach (Char s in inputString)
            {
                if (s != 'A' && s != 'U' && s != 'G' && s != 'C')
                {
                    isMatch = false;
                    break;
                }
                
                index++;
            }

            // success
            if (isMatch)
            {
                return Tuple.Create(true, index);
            }
            // no match
            else
            {
                return Tuple.Create(false, index);
            }
        }

        public bool CheckLenght(string sequence)
        {
            bool rightLenght = true;

            //Clean the sequence so we have just codon characters
            string cleanSequence = CleanSequence(sequence);

            int cleanSequenceLenght = 0;

            cleanSequenceLenght = cleanSequence.Length;

            if (cleanSequenceLenght % 3 != 0)
            {
                rightLenght = false;
            }

            return rightLenght;
        }

        public string CleanSequence(string sequence)
        {
            string cleanSequence = sequence;
            cleanSequence = cleanSequence.Trim(); //Remove leading and trailing white spaces

            //If you find > character dismiss everything until next end of line character

            string sequenceComment = string.Empty;
            int index = 0; //Index of the character in the sequence

            foreach (char c in sequence)
            {
                if(c == '>')
                {
                    int charLocation = sequence.IndexOf('\n', StringComparison.Ordinal);
                    if (charLocation > 0)
                    {
                        sequenceComment = sequence.Substring(index, charLocation);
                    }

                    //sequence = sequence - from > ToString Environment.NewLine
                    cleanSequence = cleanSequence.Replace(sequenceComment, string.Empty); //Remove sequence comment
                }

                index++;                
            }

            cleanSequence = cleanSequence.Replace("\r", string.Empty); //Remove end of line character
            cleanSequence = cleanSequence.Replace("\n", string.Empty); //Remove end of line character
            cleanSequence = cleanSequence.Replace(" ", string.Empty); //Remove white spaces
            cleanSequence = cleanSequence.Replace("\t", string.Empty); //Remove tabs
            const string reduceMultiSpace = @"[ ]{2,}";
            cleanSequence = cleanSequence.Replace(reduceMultiSpace, string.Empty); //Remove tabs if they are translated to multiple space characters   

            return cleanSequence;
        }

        public string[] GetGenes(string sequence)
        {
            sequence = sequence.ToUpper(); //Ensure all the chars at in upper case so we have coherence

            string[] genes = null;

            string pattern = "(UAG|UGA|UAA)";

            genes = Regex.Split(sequence, pattern);
            genes = genes.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Remove empty results
            //Remove repeated stop codons
            int index = 0;
            foreach (string g in genes)
            {
                if (index + 1 < genes.Length)
                {
                    if ((g == "UAG" || g == "UGA" || g == "UAA") && (genes[index + 1] == "UAG" || genes[index + 1] == "UGA" || genes[index + 1] == "UAA"))
                    {                    
                        genes[index + 1] = ""; //Change repeated stop codons to empty result                    
                    }
                }
                index++;
            }
            genes = genes.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Remove empty results

            //Add stop codons in the end of the DNA strings
            int index2 = 0;
            foreach (string g in genes)
            {
                if (g == "UAG" || g == "UGA" || g == "UAA")
                {
                    genes[index2 - 1] = genes[index2 - 1] + g;
                    genes[index2] = ""; //Change result with just stop codons to empty result
                }
                index2++;
            }
            genes = genes.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //Remove empty results

            return genes;
        }
    }
}

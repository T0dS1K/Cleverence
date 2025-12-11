using System.Text;

namespace Cleverence.Task_1
{
    public class CompressionUtility
    {
        public void CompressString(string input)
        {
            if (StringValidator.IsValidNativeOriginal(input))
            {
                Console.WriteLine($"Полученная строка:\t{input}\t|\tСжатая строка:\t\t{CompressionAlgorithm(input)}");
            }
            else
            {
                Console.WriteLine("Ошибка валидации исходной строки");
            }
        }

        public void DecompressString(string input)
        {
            if (StringValidator.IsValidNativeCompressed(input))
            {
                Console.WriteLine($"Полученная строка:\t{input}\t|\tИсходная строка:\t{DecompressionAlgorithm(input)}");
            }
            else
            {
                Console.WriteLine("Ошибка валидации сжатой строки");
            }
        }

        private string CompressionAlgorithm(ReadOnlySpan<char> input)
        {
            StringBuilder sb = new();
            sb.Append(input[0]);
            int count = 1;

            foreach (char c in input.Slice(1))
            {
                if (c == sb[sb.Length - 1])
                {
                    ++count;
                }
                else
                {
                    if (count > 1) sb.Append(count);
                    sb.Append(c);
                    count = 1;
                }
            }

            if (count > 1) sb.Append(count);
            return sb.ToString();
        }

        private string DecompressionAlgorithm(ReadOnlySpan<char> input)
        {
            StringBuilder sb = new();
            StringBuilder count = new();

            foreach (char c in input)
            {
                if (c >= 'a' && c <= 'z')
                {
                    ApplyCount();
                    sb.Append(c);
                }
                else if (c >= '0' && c <= '9')
                {
                    count.Append(c);
                }
            }

            void ApplyCount()
            {
                if (count.Length > 0)
                {
                    if (int.TryParse(count.ToString(), out int result))
                    {
                        if (sb.Length > 0)
                        {
                            for (int i = 1; i < result; ++i)
                            {
                                sb.Append(sb[sb.Length - 1]);
                            }
                        }

                        count.Clear();
                    }
                }
            }

            ApplyCount();
            return sb.ToString();
        }
    }
}
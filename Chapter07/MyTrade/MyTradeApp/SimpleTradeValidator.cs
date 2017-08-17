using MyTradeApp.Contracts;
using System.Globalization;

namespace MyTradeApp
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private readonly ILogger logger;

        public SimpleTradeValidator(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Validate(string[] fields)
        {
            if (fields.Length != 3)
            {
                logger.LogWarning("Line malformed. Only {0} field(s) found.", fields.Length);
                return false;
            }

            if (fields[0].Length != 6)
            {
                logger.LogWarning("Trade currencies malformed malformed: '{0}'", fields[0]);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                logger.LogWarning("Trade amount not a valid integer: '{0}'", fields[1]);
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out tradePrice))
            {
                logger.LogWarning("Trade price not a valid decimal: '{0}'", fields[2]);
                return false;
            }

            return true;
        }
    }
}
